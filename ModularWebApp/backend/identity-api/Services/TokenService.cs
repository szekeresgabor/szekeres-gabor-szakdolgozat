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
            new("roles", string.Join(",", user.Roles)),
            new("permissions", string.Join(",", user.Permissions))
        };

        var privateKeyPath = config["Jwt:PrivateKeyPath"];
        if (string.IsNullOrEmpty(privateKeyPath))
            throw new Exception("Hiányzó konfiguráció: Jwt:PrivateKeyPath");

        var rsa = RsaKeyLoader.LoadPrivateKey(privateKeyPath);
        var creds = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);

        var token = new JwtSecurityToken(
            issuer: "identity-api.local",
            audience: "all-services",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}