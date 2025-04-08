namespace identity_api.Services;

using identity_api.Models;

public class UserService : IUserService
{
    private static readonly List<User> dummy =
    [
        new User
        {
            Id = Guid.NewGuid(),
            Username = "admin",
            Password = "password",
            Roles = ["admin"],
            Permissions = ["user.read", "user.write"]
        }
    ];

    public User? ValidateUser(string username, string password)
        => dummy.FirstOrDefault(u => u.Username == username && u.Password == password);
}