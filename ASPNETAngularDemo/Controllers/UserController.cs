using Microsoft.AspNetCore.Mvc;

namespace ASPNETAngularDemo.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger) {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet("get-details-dto")]
    public async Task<ActionResult<List<User>>> GetAllUserDetails()
    {   
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpPost("register-dto")]
    public async Task<ActionResult<Dictionary<string, string>>> Register(User user)
    {
        var response = await _userService.Register(user);
        _logger.LogInformation("Response from Register Method: {Response}", response);
        var mapResponse = new Dictionary<string, string> {
            { "message", response }
        };
        return Ok(mapResponse);
    }

    [HttpPut("update-dto")]
    public async Task<ActionResult<Dictionary<string, string>>> UpdateUser(User user) {
        var response = await _userService.UpdateUser(user);
        var mapResponse = new Dictionary<string, string> {
            { "message", response }
        };
        return Ok(mapResponse);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Dictionary<string, string>>> DeleteUser(int id) {
        var response = await _userService.DeleteUser(id);
        var mapResponse = new Dictionary<string, string> {
            { "message", response }
        };
        return Ok(mapResponse);
    }
}
