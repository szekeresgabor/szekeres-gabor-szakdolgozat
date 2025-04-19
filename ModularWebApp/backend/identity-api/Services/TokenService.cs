using Core.Backend.Package.Utils;
using identity_api.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace identity_api.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Name, user.Username.ToString())
        };

        claims.AddRange(user.Roles.Select(r => new Claim("roles", r)));
        claims.AddRange(user.Permissions.Select(p => new Claim("permissions", p)));

        var privateKeyPath = config["Jwt:PrivateKeyPath"];
        if (string.IsNullOrEmpty(privateKeyPath))
            throw new Exception("Hiányzó konfiguráció: Jwt:PrivateKeyPath");

        var rsa = RsaKeyLoader.LoadPrivateKey(privateKeyPath);
        var creds = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);

        var token = new JwtSecurityToken(
            issuer: "identity-api",
            audience: "all-services",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}