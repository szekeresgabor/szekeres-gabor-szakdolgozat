namespace Core.Backend.Package.Models;

public class ErrorResponse
{
    public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
    public string Message { get; set; } = "Ismeretlen hiba történt.";
    public string? Detail { get; set; }

    public ErrorResponse() { }

    public ErrorResponse(string message, string? detail = null, string? correlationId = null)
    {
        Message = message;
        Detail = detail;
        CorrelationId = correlationId ?? Guid.NewGuid().ToString();
    }
}
