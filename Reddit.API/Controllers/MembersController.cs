using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reddit.Contract.Member;
using Reddit.Service.Core.Abstractions;

namespace Reddit.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class MembersController(IMemberService memberService) : ControllerBase
{
    private readonly IMemberService _memberService = memberService;

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<ActionResult> Register([FromBody] MemberRegisterModel model)
    {
        var result = await _memberService.Register(model);
        if (result.Succeed) return Ok(result.Data);
        return BadRequest(result.ErrorMessage);
    }
}
