using identity_api.Models;

namespace identity_api.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}