using identity_api.Data;

namespace identity_api.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}