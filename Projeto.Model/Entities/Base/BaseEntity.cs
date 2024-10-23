namespace Projeto.Model.Entities.Base;
/*
        Abstract é uma classe que nao pode ser instanciada diretamento,
    Deve ser somente herdadas por outras classes
*/
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime InativedAt { get; set; }
    public bool Ativo { get; set; }
}