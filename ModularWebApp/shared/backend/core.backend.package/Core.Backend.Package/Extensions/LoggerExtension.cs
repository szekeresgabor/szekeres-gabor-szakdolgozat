namespace Core.Backend.Package.Middleware;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Core.Backend.Package.Services;

public static class LoggerExtensions
{
    public static IServiceCollection AddElasticLogger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ILoggerService, LoggerService>();
        return services;
    }

    public static IApplicationBuilder UseElasticLogger(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LoggerMiddleware>();
    }
}