using Microsoft.Extensions.Configuration;
using Projeto.Model.Entities.Identity;

namespace Projeto.Model.Interfaces.Base
{
    public interface ITokenJwtService
    {
        Task<string> GerarTokenJwt(IConfiguration configuration, Usuario usuario);
    }
}
