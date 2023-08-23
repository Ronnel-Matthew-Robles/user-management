using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Services;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserService _userService;

    public UserController(ILogger<UserController> logger, UserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<User>> AddUser(User user)
    {
        try
        {
            var newUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        try
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id:length(24)}", Name = "GetUserById")]
    public async Task<ActionResult<User>> GetUserById(string id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateUser(string id, User updatedUser)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.UpdateUserAsync(id, updatedUser);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
