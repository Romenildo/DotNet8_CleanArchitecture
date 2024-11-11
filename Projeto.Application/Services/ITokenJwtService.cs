using Microsoft.Extensions.Configuration;
using Projeto.Application.UseCases.Shared.Dtos.Usuario;
using Projeto.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Services
{
    public interface ITokenJwtService
    {
        Task<string> GerarTokenJwt(IConfiguration configuration, Usuario usuario);
    }
}
