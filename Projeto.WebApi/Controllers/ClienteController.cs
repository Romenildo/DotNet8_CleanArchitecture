using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.UseCases.Cliente.Create;
using Projeto.Application.UseCases.Cliente.Delete;
using Projeto.Application.UseCases.Cliente.GetAll;
using Projeto.Application.UseCases.Cliente.Update;

namespace Projeto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreateClienteRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllClienteReponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllClienteRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateClienteRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteClienteRequest(id), cancellationToken);
            return Ok(response);
        }
    }
}
