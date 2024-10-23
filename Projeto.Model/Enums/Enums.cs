using System.ComponentModel;

namespace Projeto.Model.Enums;

public static class Enums
{
    public enum Acao
    {
        [Description("CADASTRAR")]
        CAD,
        [Description("EDITAR")]
        EDIT,
        [Description("EXCLUIR")]
        EXC,
        [Description("NADA")]
        NOTHING
    }

    /* Transforma a string CAD no Enum de Acao.CAD */
    public static T ParseToEnum<T>(this string value)
    {
        return (T)Enum.Parse(typeof(T), value);
    }

}

