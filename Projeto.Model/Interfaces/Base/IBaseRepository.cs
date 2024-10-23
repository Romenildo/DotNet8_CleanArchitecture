using Projeto.Model.Entities.Base;

/*
    Criação base que todos os repositorys vao herdar para ter as funcoes basicas de um repository
de crud
 
 */
namespace Projeto.Model.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> Get(Guid id, CancellationToken cancellationToken);
        Task<List<T>> GetAll(CancellationToken cancellationToken);
        void Inactive(T entity, bool value);
    }
}
