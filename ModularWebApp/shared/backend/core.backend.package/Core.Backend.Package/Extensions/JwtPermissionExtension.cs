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
    public static IServiceCollection AddJwtPermission(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<TokenAuthorizationService>();
        services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    var publicKeyPath = config["Jwt:PublicKeyPath"];
                    if (string.IsNullOrEmpty(publicKeyPath))
                        throw new Exception("Hiányzó konfiguráció: Jwt:PublicKeyPath");
                    var rsa = RsaKeyLoader.LoadPublicKey(publicKeyPath!);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new RsaSecurityKey(rsa),
                        ValidateIssuer = true,
                        ValidIssuer = "identity-api.local",
                        ValidateAudience = true,
                        ValidAudience = "all-services",
                        ClockSkew = TimeSpan.Zero
                    };
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
