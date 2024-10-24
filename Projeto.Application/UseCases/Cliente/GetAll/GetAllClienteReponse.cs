
namespace Projeto.Application.UseCases.Cliente.GetAll
{
    public sealed record GetAllClienteReponse
    {
        public Guid Id { get; init; }
        public string Nome { get; init; } = string.Empty;
    }
}