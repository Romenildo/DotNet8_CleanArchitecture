namespace Projeto.Model.Exceptions;

/**
    Classe de exceção para quando um objeto não é encontrado
É Recomendado para não lançar uma exceção do tipo Exception, mas sim criar uma exceção personalizada
 
 */
public class NotFoundException : Exception
{
    public NotFoundException(string entity) : base($"{entity} não foi encontrado.")
    {
        HResult = 404;
    }
}

