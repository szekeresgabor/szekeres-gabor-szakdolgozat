using System.ComponentModel.DataAnnotations.Schema;
using Core.Backend.Package.Data;

namespace identity_api.Data;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string RolesRaw { get; set; } = string.Empty;
    public string PermissionsRaw { get; set; } = string.Empty;

    [NotMapped]
    public string[] Roles
    {
        get => RolesRaw.Split(',', StringSplitOptions.RemoveEmptyEntries);
        set => RolesRaw = string.Join(",", value);
    }

    [NotMapped]
    public string[] Permissions
    {
        get => PermissionsRaw.Split(',', StringSplitOptions.RemoveEmptyEntries);
        set => PermissionsRaw = string.Join(",", value);
    }
}