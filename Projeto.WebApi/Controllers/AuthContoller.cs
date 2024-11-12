using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.UseCases.Shared.Dtos.Usuario;
using Projeto.Model.Entities.Identity;
using Projeto.Model.Interfaces.Base;

namespace Projeto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthContoller : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenJwtService _tokenJwtService;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthContoller(
            IMediator mediator,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ITokenJwtService tokenJwtService,
            UserManager<Usuario> userManager)
        {
            _mediator = mediator;
            _roleManager = roleManager;
            _configuration = configuration;
            _tokenJwtService = tokenJwtService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel request, CancellationToken cancellationToken)
        {
            var usuario = await _userManager.FindByNameAsync(request.Cpf!);

            if (usuario is not null && await _userManager.CheckPasswordAsync(usuario, request.Password!))
            {
                var token = await _tokenJwtService.GerarTokenJwt(_configuration, usuario);

                return Ok(new { token });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario
            {
                UserName = request.Cpf,
                Email = request.Email,
                Cpf = request.Cpf
            };

            var result = await _userManager.CreateAsync(usuario, request.Password!);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("register-role")]
        public async Task<IActionResult> RegisterRole([FromBody] string roleName, CancellationToken cancellationToken)
        {
            var role = new IdentityRole
            {
                Name = roleName
            };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        public record class AddRoleModel(string Cpf, string RoleName);
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel request, CancellationToken cancellationToken)
        {
            var usuario = await _userManager.FindByNameAsync(request.Cpf!);

            if (usuario is null)
                return NotFound();

            var result = await _userManager.AddToRoleAsync(usuario, request.RoleName!);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }
    }
}