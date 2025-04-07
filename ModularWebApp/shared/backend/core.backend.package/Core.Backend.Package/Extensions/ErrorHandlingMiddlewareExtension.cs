namespace Core.Backend.Package.Extensions;

using Core.Backend.Package.Middleware;
using Microsoft.AspNetCore.Builder;

public static class ErrorHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
