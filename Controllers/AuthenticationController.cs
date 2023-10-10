using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationRequester.Data;
using VacationRequester.Models;
using VacationRequester.Models.Dto;
using VacationRequester.Repositories.Interfaces;
using VacationRequester.Services;

namespace VacationRequester.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly IRepository<User> _userRepository;
    private readonly IAuthenticationRepository _authRepository;


    public AuthenticationController(JwtService jwtService, IRepository<User> userRepository, IAuthenticationRepository authRepository)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
        _authRepository = authRepository;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        if(registerDto == null)
        {
            return BadRequest();
        }

        string passwordHash
            = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        var userToRegister = new User
        {
            Email = registerDto.Email,
            PasswordHash = passwordHash,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,

            Role = Role.Employee
        };

        if (userToRegister == null)
        {
            return BadRequest();
        }

        await _userRepository.AddAsync(userToRegister);
       
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto request)
    {
        if(request == null)
        {
            return BadRequest();
        }

        if (!await _authRepository.VerifyEmailAsync(request.Email))
        {
            return Unauthorized();
        }

        if (!await _authRepository.VerifyPasswordAsync(request.Password, request.Email))
        {
            return BadRequest("Wrong password.");
        }
        
        var user = await _authRepository.GetUserByEmailAsync(request.Email);

        var token = _jwtService.GenerateToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;

        await _userRepository.UpdateAsync(user);

        return Ok(new { token, refreshToken });
    }

    [Authorize]
    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken(RefreshToken refreshToken)
    {
        if (refreshToken == null)
        {
            return BadRequest();
        }

        var user = await _authRepository.GetUserByRefreshToken(refreshToken);

        if (user == null || user.RefreshToken.Expires < DateTime.Now)
        {
            return Unauthorized();
        }

        var newAccessToken = _jwtService.GenerateToken(user);
        var newRefreshToken = _jwtService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await _userRepository.UpdateAsync(user);

        return Ok(new { token = newAccessToken, refreshToken = newRefreshToken });
    }
}

