namespace szerzodeskezelo_api.Extensions;

using Microsoft.EntityFrameworkCore;
using NSwag.CodeGeneration.TypeScript;

using szerzodeskezelo_api.Data;
using Core.Backend.Package.Extensions;

public static class WebApplicationBuilderExtensions
{
    public async static Task<WebApplication> BuildApi(this WebApplicationBuilder builder)
    {
        // Swagger + OpenAPI
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddOpenApiDocument(options =>
        {
            options.Title = "Szerzodeskezelo API Dokumentáció";
            options.Version = "v1";

            options.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
            {
                Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                Description = "Add meg a JWT tokent így: Bearer {token}"
            });

            options.OperationProcessors.Add(new NSwag.Generation.Processors.Security.AspNetCoreOperationSecurityScopeProcessor("JWT"));

            options.PostProcess = apiDocument =>
            {
                var clientGenerator = new TypeScriptClientGenerator(apiDocument,
                    new TypeScriptClientGeneratorSettings
                    {
                        GenerateDtoTypes = true,
                        GenerateClientClasses = false
                    });

                var outputPath = Path.Combine(
                   AppContext.BaseDirectory,
                   "..", "..", "..", "..", "..", "frontend", "szerzodeskezelo", "src", "app", "generated", "szerzodeskezelo-api.ts");
                var fullPath = Path.GetFullPath(outputPath);

                File.WriteAllText(fullPath, clientGenerator.GenerateFile());
            };
        });

        // Consul konfiguráció
        builder.Configuration.AddConsulConfiguration();

        //DB Context beállítása
        builder.Services.AddDbContext<SzerzodeskezeloDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Saját szolgáltatások regisztrálása
        builder.Services.AddApplicationServices();

        //FluentValidation szabályok hozzáadása az alkalmazáshoz
        builder.Services.AddValidation();

        //GenericRepository hozzáadása az alkalmazáshoz
        builder.Services.AddGenericRepository<Szerzodes, SzerzodeskezeloDbContext>();

        //Elastic log service hozzáadása
        builder.Services.AddElasticLogger();

        //JWT kezelést segítő szolgáltatások hozzáadása
        builder.Services.AddJwtPermission();

        var app = builder.Build();

        // Middleware pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        //Hiba kezelés hozzádása
        app.UseErrorHandling();

        //Elastic log middleware hozzádása
        app.UseElasticLogger();

        //JWT kezelés add
        app.UseJwtPermission();

        return app;
    }
}