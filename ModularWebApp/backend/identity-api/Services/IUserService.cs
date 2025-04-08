namespace identity_api.Services;

using identity_api.Data;

public interface IUserService
{
    Task<User?> ValidateUserAsync(string username, string password);
}
