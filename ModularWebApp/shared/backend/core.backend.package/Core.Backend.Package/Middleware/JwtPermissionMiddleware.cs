namespace Core.Backend.Package.Middleware;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Core.Backend.Package.Attributes;
using Core.Backend.Package.Services;
using Microsoft.AspNetCore.Http.Features;

public class JwtPermissionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<JwtPermissionMiddleware> _logger;

    public JwtPermissionMiddleware(RequestDelegate next, ILogger<JwtPermissionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, ITokenAuthorizationService tokenService)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;

        if (endpoint == null)
        {
            await _next(context);
            return;
        }

        var permissionAttr = endpoint.Metadata.GetMetadata<PermissionRequiredAttribute>();
        var roleAttr = endpoint.Metadata.GetMetadata<RoleRequiredAttribute>();

        // Nincs megadva se jogosultság, se szerepkör, nincs teendő?
        if (permissionAttr == null && roleAttr == null)
        {
            await _next(context);
            return;
        }

        // használjuk a már validált HttpContext.User-t
        var principal = context.User;
        if (principal?.Identity?.IsAuthenticated != true)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Nincs hitelesítve a felhasználó.");
            return;
        }

        var hasPermission = permissionAttr != null &&
            tokenService.HasAnyPermission(principal, permissionAttr.Permissions);

        var hasRole = roleAttr != null &&
            tokenService.HasAnyRole(principal, roleAttr.Roles);

        if (!(hasPermission || hasRole))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Nincs jogosultság a művelethez.");
            return;
        }

        await _next(context);
    }
}