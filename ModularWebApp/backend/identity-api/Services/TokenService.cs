using identity_api.Models;
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

        //TODO: Fel kell venni a JWT:PrivateKey-t a Consulba
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:PrivateKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

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