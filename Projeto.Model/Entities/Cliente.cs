using Projeto.Model.Entities.Base;

namespace Projeto.Model.Entities;

public class Cliente : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public Endereco? Endereco { get; set; }
}

