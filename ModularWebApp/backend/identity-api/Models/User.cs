namespace identity_api.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string[] Roles { get; set; } = [];
    public string[] Permissions { get; set; } = [];
}