namespace Projeto.Model.Interfaces.Base;

/*
    Criação da interface do padrão UnitOfWork que controla a persistencia dos dados no banco
e controla o saveChanges do create/update/delete
 */
public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}
