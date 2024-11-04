using Projeto.Database.Services;
using Projeto.Application.Services;
using Microsoft.AspNetCore.Identity;
using Projeto.Database.Context;

//configuracao do postgress salvar datetime
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

//extens�es
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureDatabaseApp(builder.Configuration);

//token jwt
builder.Services.AddAuthentication();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

//identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>().
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
