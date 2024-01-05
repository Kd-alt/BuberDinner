using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        if(_userRepository.GetUserByEmail(Email) != null) 
        {
            throw new DuplicateEmailException();
        }
        var user = new User(FirstName,LastName,Email,Password);
        _userRepository.Add(user);
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user,token);
    }
    public AuthenticationResult Login(string Email, string Password)
    {
        if (_userRepository.GetUserByEmail(Email) is not User user)
        {
            throw new Exception("User with given email doesn't exists.");
        }
        if (user.Password != Password)
        {
            throw new Exception("Invalid Password.");
        }
        var token=_jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user,token);
    }
}