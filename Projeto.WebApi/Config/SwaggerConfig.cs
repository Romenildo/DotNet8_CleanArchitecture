using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

/*
 * Padrão da documentação so Swagger so precisa modificar os nomes
 * */
namespace Projeto.WebApi.Config
{
    public static class SwaggerConfig
    {
        private static bool isDocDefined { get; set; } = false;
        private static bool isSecurityDefined { get; set; } = false;

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction
                    .AddSwaggerDoc()
                    .AddSwaggerSecurity();
            });


            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, bool isDevelopment)
        {
            if (!isDevelopment)
                return app;

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto V1");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            
            return app;
        }

        public static SwaggerGenOptions MapBuilder<TFrom, TTo>(this SwaggerGenOptions _this)
        {
             _this.MapType<TFrom>(() => new OpenApiSchema { Type = typeof(TTo).Name.ToLower() });
            return _this;
        }

        public static SwaggerGenOptions AddSwaggerDoc(this SwaggerGenOptions _this)
        {
            if (isDocDefined)
                return _this;

            isDocDefined = true;
            _this.SwaggerDoc("v1", 
                new OpenApiInfo
                {
                    Title = "Treino projeto Titulo X1",
                    Version = "v1",
                    Description = "Documentação da API para auxiliar desenvolvedores durante o desenvolvimento das funcionalidades do sistema."
                });
            return _this;
        }

        public static SwaggerGenOptions AddSwaggerSecurity(this SwaggerGenOptions _this)
        {
            if (isSecurityDefined)
                return _this;

            isSecurityDefined = true;

            var security = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                        Scheme = "apiKey",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    }, new List<string>()
                }
            };

            _this.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Primeiro é necessário gerar o 'token' via login no Usuario/Login em seguida insira 'Bearer ' + token no campo Value",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            _this.AddSecurityRequirement(security);

            return _this;
        }


    }
}
