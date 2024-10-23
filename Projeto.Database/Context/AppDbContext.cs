using Microsoft.EntityFrameworkCore;
using Projeto.Model.Entities;
using System.Reflection;

namespace Projeto.Database.Context;

/*
        Precisa instalar os pacores do EntityFrameworkCore
    -- Microsoft.EntityFrameworkCore
    -- Microsoft.EntityFrameworkCore.Postgress
     */
public class AppDbContext : DbContext//DbContext é uma classe do entityframeworkcore
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /* Representação da tabela no banco, podendo criar, atualizar, deletar ,...*/
    /*Como Cliente não existe no Persistence é preciso colocar a referencia do Domain no Peristence*/

    //public DbSet<Cliente> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //permitir que possamos mapear as entidades(EntityTypeBuilder) antes de salvar no banco
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}