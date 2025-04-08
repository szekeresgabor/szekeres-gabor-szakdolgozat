using NSwag.CodeGeneration.TypeScript;
using Winton.Extensions.Configuration.Consul;

var builder = WebApplication.CreateBuilder(args);

// Szolgáltatások regisztrációja
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Identity API Dokumentáció";
    options.Version = "v1";
    options.PostProcess = apiDocument =>
    {
        var clientGenerator = new TypeScriptClientGenerator(apiDocument,
            new TypeScriptClientGeneratorSettings { GenerateDtoTypes = true, GenerateClientClasses = false });

        var outputPath = Path.Combine(
            AppContext.BaseDirectory,
            "..", "..", "..", "..", "..", "shared", "frontend", "projects",
            "core-frontend-package", "src", "lib", "generated", "indentity-api.ts");

        var fullPath = Path.GetFullPath(outputPath);

        File.WriteAllText(fullPath, clientGenerator.GenerateFile());
    };
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
    app.MapOpenApi();
}

builder.Configuration.AddConsul(
    "appsettings/indentity-api",
    options =>
    {
        options.ConsulConfigurationOptions =
            cco => { cco.Address = new Uri("http://localhost:8500"); };

        options.Optional = false;
        options.ReloadOnChange = true;
        options.Parser = new Winton.Extensions.Configuration.Consul.Parsers.SimpleConfigurationParser();
    });

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
