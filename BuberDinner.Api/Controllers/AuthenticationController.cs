using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController:ControllerBase
{
    [Route("register")]
    public IActionResult Register()
    {
        return Ok();
    }

    [Route("login")]
    public IActionResult Login()
    {
        return Ok();
    }
}