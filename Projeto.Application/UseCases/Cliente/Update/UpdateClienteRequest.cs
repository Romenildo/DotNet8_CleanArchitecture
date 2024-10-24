using MediatR;

namespace Projeto.Application.UseCases.Cliente.Update
{
    public record UpdateClienteRequest(Guid Id, string Nome) : IRequest<UpdateClienteResponse>;
}
