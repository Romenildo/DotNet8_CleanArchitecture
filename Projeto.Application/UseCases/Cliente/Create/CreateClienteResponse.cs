using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.UseCases.Cliente.Create
{
    public sealed record CreateClienteResponse
    {
        public Guid Id { get; init; }
        public string Nome { get; init; } = string.Empty;
    }
}
