using MediatR;

namespace Projeto.Application.UseCases.Cliente.Create
{
    public sealed record CreateClienteRequest(string Nome) : IRequest<CreateClienteResponse>;
}

//record é imutavel, ou seja, não pode ser alterado depois de criado
//sealed é para que não possa ser herdado
//ou s