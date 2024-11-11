using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Projeto.Model.Entities.Identity;
using Projeto.Model.Interfaces.Base;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projeto.WebApi.Services
{
    public class TokenJwtService : ITokenJwtService
    {
        public Task<string> GerarTokenJwt(IConfiguration configuration, Usuario usuario)
        {
            var secretKey = configuration["Jwt:SecretKey"];
            var issuer = configuration["Jwt:Emissor"];
            var audience = configuration["Jwt:ValidoEm"];
            int expiracaoHoras = Int32.Parse(configuration["Jwt:TokenExpiration"]!);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>();

            if (usuario.Cpf != null)
                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Cpf));


            var token = new JwtSecurityToken(issuer,
              audience,
              claims,
              expires: DateTime.UtcNow.AddHours(expiracaoHoras),
              signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
