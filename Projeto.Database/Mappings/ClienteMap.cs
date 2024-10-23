using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Database.Mappings.Base;
using Projeto.Model.Entities;

namespace Projeto.Database.Mappings;

public class ClienteMap : BaseMap<Cliente>
{
    public override void Configure(EntityTypeBuilder<Cliente> builder)
    {
        base.Configure(builder);
        builder.ToTable("cliente");

        builder.Property(x => x.Nome)
            .HasColumnName("nome")
            .IsRequired();

        //Relacionamento um para um Cliente tem um endereco
        builder.Property(x => x.EnderecoId)
            .HasColumnName("endereco_id");

        builder.HasOne(x => x.Endereco)
               .WithMany().HasForeignKey(x => x.EnderecoId);
    }
}