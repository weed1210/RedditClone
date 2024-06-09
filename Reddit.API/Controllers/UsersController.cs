using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reddit.API.Controllers.Abstractions;
using Reddit.Contract.User;
using Reddit.Service.Core.Abstractions;

namespace Reddit.API.Controllers;
public class UsersController(IUserService userService) : BaseApiController
{
    private readonly IUserService _userService = userService;

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody] UserLoginRequest model)
    {
        var result = await _userService.LoginAsync(model);
        return Ok(result);
    }
}
