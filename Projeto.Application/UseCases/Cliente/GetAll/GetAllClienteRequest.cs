using MediatR;

namespace Projeto.Application.UseCases.Cliente.GetAll
{
    public sealed record GetAllClienteRequest() : IRequest<List<GetAllClienteReponse>>
    {
    }
}
