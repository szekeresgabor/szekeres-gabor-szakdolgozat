namespace Core.Backend.Package.Middleware;

using Core.Backend.Package.Services;

public class LoggerMiddleware
{
    private readonly RequestDelegate _next;

    public LoggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILoggerService loggerService)
    {
        var correlationId = context.Request.Headers["X-CorrelationID"].FirstOrDefault()
            ?? Guid.NewGuid().ToString();

        context.Items["CorrelationID"] = correlationId;
        context.Response.Headers.TryAdd("X-CorrelationID", correlationId);

        var requestInfo = new
        {
            Path = context.Request.Path,
            Method = context.Request.Method,
            Query = context.Request.QueryString.ToString()
        };

        await loggerService.LogInfoAsync("Request started", correlationId, requestInfo);

        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await _next(context);

            responseBody.Seek(0, SeekOrigin.Begin);
            var responseText = await new StreamReader(responseBody).ReadToEndAsync();
            responseBody.Seek(0, SeekOrigin.Begin);

            var responseInfo = new
            {
                StatusCode = context.Response.StatusCode,
                Body = responseText
            };

            await loggerService.LogInfoAsync("Request finished", correlationId, responseInfo);

            await responseBody.CopyToAsync(originalBodyStream);
        }
        catch (Exception ex)
        {
            await loggerService.LogErrorAsync("Unhandled exception", correlationId, ex);
            throw;
        }
    }
}