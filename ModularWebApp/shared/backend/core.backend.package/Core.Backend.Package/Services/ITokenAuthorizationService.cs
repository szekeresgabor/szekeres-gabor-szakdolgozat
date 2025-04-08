using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Core.Backend.Package.Services;

public interface ITokenAuthorizationService
{
    TokenValidationParameters GetTokenValidationParams();

    bool HasAnyPermission(ClaimsPrincipal user, IEnumerable<string> permissions);

    bool HasAnyRole(ClaimsPrincipal user, IEnumerable<string> roles);
}
