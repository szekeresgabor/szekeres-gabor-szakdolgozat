using NSwag.CodeGeneration.TypeScript;

var builder = WebApplication.CreateBuilder(args);

// Szolgáltatások regisztrációja
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Storage API Dokumentáció";
    options.Version = "v1";
    options.PostProcess = apiDocument =>
    {
        var clientGenerator = new TypeScriptClientGenerator(apiDocument,
            new TypeScriptClientGeneratorSettings { GenerateDtoTypes = true, GenerateClientClasses = false });

        var outputPath = Path.Combine(
            AppContext.BaseDirectory,
            "..", "..", "..", "..", "..", "shared", "frontend", "projects",
            "core-frontend-package", "src", "lib", "generated", "storage-api.ts");

        var fullPath = Path.GetFullPath(outputPath);

        File.WriteAllText(fullPath, clientGenerator.GenerateFile());
    };
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(); // NSwag saját Swagger UI-t használ
    app.MapOpenApi();
}

app.MapControllers();

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
