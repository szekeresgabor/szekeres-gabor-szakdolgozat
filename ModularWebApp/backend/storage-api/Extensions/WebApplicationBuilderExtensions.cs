namespace storage_api.Extensions;

using Microsoft.EntityFrameworkCore;

using storage_api.Data;
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
            options.Title = "Storage API Dokumentáció";
            options.Version = "v1";

            options.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
            {
                Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                Description = "Add meg a JWT tokent így: Bearer {token}"
            });

            options.OperationProcessors.Add(new NSwag.Generation.Processors.Security.AspNetCoreOperationSecurityScopeProcessor("JWT"));

        });

        // CORS policy beállítás
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        // Consul konfiguráció
        builder.Configuration.AddConsulConfiguration();

        //DB Context beállítása
        builder.Services.AddDbContext<StorageDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // Saját szolgáltatások regisztrálása
        builder.Services.AddApplicationServices();

        //GenericRepository hozzáadása az alkalmazáshoz
        builder.Services.AddGenericRepository<StoredFile, StorageDbContext>();

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

        //Cors engedélyezése
        app.UseCors("AllowFrontend");

        return app;
    }
}