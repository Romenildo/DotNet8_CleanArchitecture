using MediatR;

namespace Projeto.Application.UseCases.Cliente.Delete
{
    public sealed record DeleteClienteRequest(Guid Id) : IRequest<DeleteClienteResponse>
    {
    }
}
