using identity_api.Data;
using Microsoft.EntityFrameworkCore;
using NSwag.CodeGeneration.TypeScript;

namespace identity_api.Extensions;

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
                    "core-frontend-package", "src", "lib", "generated", "identity-api.ts");

                var fullPath = Path.GetFullPath(outputPath);

                File.WriteAllText(fullPath, clientGenerator.GenerateFile());
            };
        });

        // Consul konfiguráció
        builder.Configuration.AddConsulConfiguration();

        //DB Context beállítása
        builder.Services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

        //Seedek futtatása az alkalmazás indulásakor 
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
            await db.Database.MigrateAsync();
            await UserSeeder.SeedAsync(db);
        }

        return app;
    }
}