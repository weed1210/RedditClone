using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reddit.DataAccess.Common.Paging;
using Reddit.Domain.Enums.Paging;
using Reddit.Service.Core.Interfaces;

namespace Reddit.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public ActionResult Get([FromQuery] PagingParam<BaseSortCriteria> pagingParam)
    {
        var result = _postService.Get(pagingParam);
        if (result.Succeed) return Ok(result.Data);
        return BadRequest(result.ErrorMessage);
    }
}
