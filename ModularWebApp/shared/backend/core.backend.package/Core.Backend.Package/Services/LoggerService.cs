namespace Core.Backend.Package.Services;

using System.Text;
using System.Text.Json;

public class LoggerService : ILoggerService
{
    private readonly HttpClient _httpClient;
    private readonly string _elasticUri;

    public LoggerService(IConfiguration configuration)
    {
        //TODO: Consul-ba fel kell venni az Elastic címét
        _elasticUri = configuration["ElasticConfiguration:Uri"];
        _httpClient = new HttpClient();
    }

    public async Task LogInfoAsync(string message, string correlationId, object? data = null)
    {
        await SendLogAsync("info", message, correlationId, data);
    }

    public async Task LogErrorAsync(string message, string correlationId, Exception? ex = null, object? data = null)
    {
        var errorDetails = new
        {
            exception = ex?.ToString(),
            data
        };

        await SendLogAsync("error", message, correlationId, errorDetails);
    }

    private async Task SendLogAsync(string level, string message, string correlationId, object? data)
    {
        var logEntry = new
        {
            timestamp = DateTime.UtcNow,
            level,
            message,
            correlationId,
            data
        };

        var json = JsonSerializer.Serialize(logEntry);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await _httpClient.PostAsync($"{_elasticUri}/logs/_doc", content);
    }
}