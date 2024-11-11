using Projeto.Database.Services;
using Projeto.Application.Services;
using Microsoft.AspNetCore.Identity;
using Projeto.Database.Context;
using Projeto.WebApi.Config;
using Projeto.Model.Entities.Identity;

//configuracao do postgress salvar datetime
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

//extensões
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureDatabaseApp(builder.Configuration);

//token jwt
builder.Services.AddJwt(builder.Configuration);

//identity
builder.Services.AddIdentity<Usuario, IdentityRole>().
    AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
