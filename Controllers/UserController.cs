using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VacationRequester.Models;
using VacationRequester.Models.Dto;
using VacationRequester.Repositories.Interfaces;

namespace VacationRequester.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public UserController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    [Authorize]
    [HttpGet, Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        if (users == null || !users.Any())
        {
            return NotFound("No users found.");
        }

        var dtoUsers = new List<UserResponseDto>();
        foreach (var user in users)
        {
            dtoUsers.Add(new UserResponseDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
            });
        }

        return Ok(dtoUsers);
    }

    [Authorize]
    [HttpGet("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid ID.");
        }

        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound($"No user found with ID: {id}");
        }

        return Ok(user);
    }

    [Authorize]
    [HttpPut, Route("SetUserRole"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> SetRole(Guid id, int role)
    {
        if (id == Guid.Empty)
        {
            return BadRequest();
        }

        if (role != 1 || role != 2)
        {
            return NotFound("RoleId not found.");
        }

        var existingUser = await _userRepository.GetByIdAsync(id);

        if (existingUser == null)
        {
            return NotFound("No user found.");
        }
        existingUser.Role = (Role)role;

        await _userRepository.UpdateAsync(existingUser);

        return Ok();
    }

}
