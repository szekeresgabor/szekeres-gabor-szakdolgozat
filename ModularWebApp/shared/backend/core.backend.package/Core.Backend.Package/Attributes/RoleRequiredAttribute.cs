namespace Core.Backend.Package.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]

/// <summary>
/// Meghatározza, hogy a vezérlő vagy action metódus csak meghatározott szerepkör(ök) birtokában érhető el.
/// Több szerepkör megadása esetén elegendő, ha a felhasználó legalább egy szerepkörrel rendelkezik (OR kapcsolat).
/// </summary>
public class RoleRequiredAttribute : Attribute
{
    public string[] Roles { get; }

    public RoleRequiredAttribute(params string[] roles)
    {
        Roles = roles;
    }
}