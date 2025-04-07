namespace Core.Backend.Package.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]

/// <summary>
/// Meghatározza, hogy a vezérlő vagy action metódus csak az adott jogosultság(ok) birtokában érhető el.
/// Több jogosultság megadása esetén elegendő, ha a felhasználó legalább egy jogosultsággal rendelkezik (OR kapcsolat).
/// </summary>
public class PermissionRequiredAttribute : Attribute
{
    public string[] Permissions { get; }

    public PermissionRequiredAttribute(params string[] permissions)
    {
        Permissions = permissions;
    }
}
