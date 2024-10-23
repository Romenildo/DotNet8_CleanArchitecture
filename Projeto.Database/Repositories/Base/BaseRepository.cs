using Microsoft.EntityFrameworkCore;
using Projeto.Database.Context;
using Projeto.Model.Entities.Base;
using Projeto.Model.Interfaces.Base;

namespace Projeto.Database.Repositories.Base;
/*
    Camada a mais entre o repository e o contexto do entityFramework
 */

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;//context dependendo da entidade

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        entity.CreatedAt = DateTime.Now;
        _context.Add(entity);//funcao do EF
    }
    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.Now;
        _context.Update(entity);//funcao do EF
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);//funcao do EF
    }

    public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        //o Set retorna o contexto da coleção da entidade, a listagem para fazer o find
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public void Inactive(T entity, bool value)
    {
        entity.Ativo = value;
        _context.Update(entity);
    }
}

