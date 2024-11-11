using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Database.Context;
using Projeto.Database.Repositories.Base;
using Projeto.Database.Repositories;
using Projeto.Model.Interfaces.Base;
using Projeto.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Projeto.WebApi.Services;

/*
 *  Arquivo de extensão para conectar ao banco de dados a partir da webAPi
 *  
 */

namespace Projeto.Database.Services;

public static class ServiceExtensions
{
    public static void ConfigureDatabaseApp(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("dbTeste");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<ITokenJwtService, TokenJwtService>();
    }

}
