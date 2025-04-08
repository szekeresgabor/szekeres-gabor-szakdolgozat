namespace identity_api.Services;

using Core.Backend.Package.Data;
using identity_api.Data;

public class UserService(IGenericRepository<User> userRepository) : IUserService
{
    public async Task<User?> ValidateUserAsync(string username, string password)
    {
        var users = await userRepository.FindAsync(u => u.Username == username && u.Password == password);
        return users.FirstOrDefault();
    }
}