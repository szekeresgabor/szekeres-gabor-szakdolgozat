namespace Core.Backend.Package.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]

/// <summary>
/// Megjelöli az adott action metódust mint kivételt a jogosultságkezelés alól.
/// Akkor használandó, ha a vezérlő alapértelmezés szerint védett, de egy adott végpontot szeretnénk nyilvánossá tenni.
/// </summary>
public class AllowAnonymousPermissionAttribute : Attribute
{
}