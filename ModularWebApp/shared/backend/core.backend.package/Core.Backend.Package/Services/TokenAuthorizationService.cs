namespace Core.Backend.Package.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Core.Backend.Package.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class TokenAuthorizationService : ITokenAuthorizationService
{
    private readonly IConfiguration _configuration;

    public TokenAuthorizationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = GetTokenValidationParams();
        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            return principal;
        }
        catch
        {
            return null;
        }
    }

    public TokenValidationParameters GetTokenValidationParams()
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = GetPublicKey(),
            ValidateIssuer = true,
            ValidIssuer = "identity-api.local",
            ValidateAudience = true,
            ValidAudience = "all-services",
            ClockSkew = TimeSpan.Zero
        };
    }

    public bool HasAnyPermission(ClaimsPrincipal user, IEnumerable<string> permissions)
    {
        return permissions.Any(p =>
            user.Claims.Any(c => c.Type == "permissions" && c.Value == p)
        );
    }

    public bool HasAnyRole(ClaimsPrincipal user, IEnumerable<string> roles)
    {
        return roles.Any(r => user.IsInRole(r));
    }

    private SecurityKey GetPublicKey()
    {
        var publicKeyPath = _configuration["Jwt:PublicKeyPath"];
        if (string.IsNullOrEmpty(publicKeyPath))
            throw new Exception("Hiányzó konfiguráció: Jwt:PublicKeyPath");

        var rsa = RsaKeyLoader.LoadPublicKey(publicKeyPath);
        return new RsaSecurityKey(rsa);
    }
}
