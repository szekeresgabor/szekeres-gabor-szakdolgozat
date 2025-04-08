namespace Core.Backend.Package.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Core.Backend.Package.Services;
using Core.Backend.Package.Middleware;

public static class LoggerExtensions
{
    public static IServiceCollection AddElasticLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerService, LoggerService>();
        return services;
    }

    public static IApplicationBuilder UseElasticLogger(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LoggerMiddleware>();
    }
}