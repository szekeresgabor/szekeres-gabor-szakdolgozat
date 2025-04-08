using identity_api.Models;
using identity_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace identity_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserService userService, ITokenService tokenService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = userService.ValidateUser(request.Username, request.Password);
        if (user is null) return Unauthorized("Hibás felhasználónév vagy jelszó");

        var token = tokenService.GenerateToken(user);
        return Ok(new LoginResponse { Token = token });
    }
}