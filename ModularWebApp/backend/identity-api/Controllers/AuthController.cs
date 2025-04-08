using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using identity_api.Data;
using identity_api.Models;
using identity_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace identity_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserService userService, ITokenService tokenService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await userService.ValidateUserAsync(request.Username, request.Password);
        if (user is null) return Unauthorized("Hibás felhasználónév vagy jelszó");

        var token = tokenService.GenerateToken(user);
        return Ok(new LoginResponse { Token = token });
    }

    [Authorize]
    [HttpPost("renew")]
    public async Task<IActionResult> Renew()
    {
        var identity = HttpContext.User;
        if (identity?.Identity is not { IsAuthenticated: true })
            return Unauthorized("Token érvénytelen vagy hiányzik");

        var userIdClaim = identity.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized("Hiányzó vagy hibás azonosító");

        var user = await userService.GetById(userId);

        if (user is null) return Unauthorized("Ismertetlen felhasználó!");

        var newToken = tokenService.GenerateToken(user);
        return Ok(new LoginResponse { Token = newToken });
    }
}