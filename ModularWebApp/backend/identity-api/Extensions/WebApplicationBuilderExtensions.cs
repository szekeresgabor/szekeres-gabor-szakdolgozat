using NSwag.CodeGeneration.TypeScript;
using Winton.Extensions.Configuration.Consul;

namespace identity_api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplication BuildApi(this WebApplicationBuilder builder)
    {
        // Swagger + OpenAPI
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddOpenApiDocument(options =>
        {
            options.Title = "Identity API Dokumentáció";
            options.Version = "v1";

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
                    "..", "..", "..", "..", "..", "shared", "frontend", "projects",
                    "core-frontend-package", "src", "lib", "generated", "indentity-api.ts");

                var fullPath = Path.GetFullPath(outputPath);

                File.WriteAllText(fullPath, clientGenerator.GenerateFile());
            };
        });

        // Consul konfiguráció
        builder.Configuration.AddConsul(
            "appsettings/indentity-api",
            options =>
            {
                options.ConsulConfigurationOptions = cco =>
                {
                    cco.Address = new Uri("http://localhost:8500");
                };
                options.Optional = false;
                options.ReloadOnChange = true;
                options.Parser = new Winton.Extensions.Configuration.Consul.Parsers.SimpleConfigurationParser();
            });

        // Saját szolgáltatások regisztrálása
        builder.Services.AddApplicationServices();

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

        return app;
    }
}