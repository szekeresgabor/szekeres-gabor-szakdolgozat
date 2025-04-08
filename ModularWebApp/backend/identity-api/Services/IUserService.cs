namespace identity_api.Services;

using identity_api.Models;

public interface IUserService
{
    User? ValidateUser(string username, string password);
}
