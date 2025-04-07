namespace Core.Backend.Package.Services;

public interface ILoggerService
{
    Task LogInfoAsync(string message, string correlationId, object? data = null);
    Task LogErrorAsync(string message, string correlationId, Exception? ex = null, object? data = null);
}
