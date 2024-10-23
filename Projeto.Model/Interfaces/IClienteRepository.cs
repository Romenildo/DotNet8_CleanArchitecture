using Projeto.Model.Entities;
using Projeto.Model.Interfaces.Base;

/*
    Criação das interfaces que o repository de cliente vai implementar
na camada de database
 */
namespace Projeto.Model.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
    }
}
