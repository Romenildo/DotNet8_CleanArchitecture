using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Projeto.Model.Entities.Base;

namespace Projeto.Database.Mappings.Base;

/*
    Mapeamento base de todas em entidades herdadas de BaseEntity
 */
public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("data_criacao")
            .HasDefaultValue(null)
            .HasColumnType("timestamp without time zone");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("data_atualizacao")
            .HasDefaultValue(null)
            .HasColumnType("timestamp without time zone");

        builder.Property(x => x.InativedAt)
            .HasColumnName("data_inativacao")
            .HasDefaultValue(null)
            .HasColumnType("timestamp without time zone");
    }
}