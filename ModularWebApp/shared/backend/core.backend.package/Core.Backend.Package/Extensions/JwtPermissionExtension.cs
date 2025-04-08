namespace Core.Backend.Package.Extensions;

using System.IdentityModel.Tokens.Jwt;
using Core.Backend.Package.Middleware;
using Core.Backend.Package.Services;
using Core.Backend.Package.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;

public static class JwtPermissionExtension
{
    /// <summary>
    /// Regisztrálja a JWT alapú jogosultság middleware-t és a hozzá tartozó szolgáltatást.
    /// </summary>
    public static IServiceCollection AddJwtPermission(this IServiceCollection services)
    {
        services.AddSingleton<ITokenAuthorizationService, TokenAuthorizationService>();
        services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    using var serviceProvider = services.BuildServiceProvider();
                    var tokenAuthorizationService = serviceProvider.GetRequiredService<ITokenAuthorizationService>();
                    options.TokenValidationParameters = tokenAuthorizationService.GetTokenValidationParams();
                });
        return services;
    }

    /// <summary>
    /// Beköti a JWT jogosultság middleware-t a feldolgozási pipeline-ba.
    /// </summary>
    public static IApplicationBuilder UseJwtPermission(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        return app.UseMiddleware<JwtPermissionMiddleware>();
    }
}
