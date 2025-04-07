namespace Core.Backend.Package.Extensions;

using Core.Backend.Package.Middleware;
using Core.Backend.Package.Services;
using Microsoft.AspNetCore.Builder;

public static class JwtPermissionMiddlewareExtension
{
    /// <summary>
    /// Regisztrálja a JWT alapú jogosultság middleware-t és a hozzá tartozó szolgáltatást.
    /// </summary>
    public static IServiceCollection AddJwtPermissionAuthorization(this IServiceCollection services)
    {
        services.AddSingleton<TokenAuthorizationService>();
        return services;
    }

    /// <summary>
    /// Beköti a JWT jogosultság middleware-t a feldolgozási pipeline-ba.
    /// </summary>
    public static IApplicationBuilder UseJwtPermissionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<JwtPermissionMiddleware>();
    }
}
