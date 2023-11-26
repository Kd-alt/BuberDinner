using BuberDinner.Application.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController:ControllerBase
{
    private readonly IAuthenticationService _authservice;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authservice = authenticationService;
    }
    [Route("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authresponse =_authservice.Register(request.FirstName,request.LastName,request.Email,request.Password);
        var response = new AuthenticationResponse(
            authresponse.Id,
            authresponse.FirstName,
            authresponse.LastName,
            authresponse.Email,
            authresponse.Token
        );
        return Ok(response);
    }

    [Route("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authresponse =_authservice.Login(request.Email,request.Password);
        var response = new AuthenticationResponse(
            authresponse.Id,
            authresponse.FirstName,
            authresponse.LastName,
            authresponse.Email,
            authresponse.Token
        );
        return Ok(response);
    }
}