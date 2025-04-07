namespace Core.Backend.Package.Middleware;

using Core.Backend.Package.Models;

using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";

            var errorResponse = new ErrorResponse(
                    message: "Hiba történt a feldolgozás során.",
                    detail: ex.Message,
                    correlationId: context.Request.Headers["X-CorrelationID"].FirstOrDefault() ?? Guid.NewGuid().ToString()
                );

            var result = JsonSerializer.Serialize(errorResponse);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(result);
        }
    }
}
