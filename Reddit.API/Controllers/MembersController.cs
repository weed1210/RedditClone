using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reddit.API.Controllers.Abstractions;
using Reddit.Contract.Member;
using Reddit.Service.Core.Abstractions;

namespace Reddit.API.Controllers;
public class MembersController(IMemberService memberService) : BaseApiController
{
    private readonly IMemberService _memberService = memberService;

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<ActionResult> Register([FromBody] MemberRegisterRequest model)
    {
        var result = await _memberService.RegisterAsync(model);
        return Ok(result);
    }
}
