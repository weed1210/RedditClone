using Microsoft.AspNetCore.Mvc;
using Reddit.API.Controllers.Abstractions;
using Reddit.DataAccess.Common.Paging;
using Reddit.Domain.Enums.Paging;
using Reddit.Service.Core.Abstractions;

namespace Reddit.API.Controllers;
public class PostsController(IPostService postService) : BaseApiController
{
    private readonly IPostService _postService = postService;

    [HttpGet]
    public ActionResult Get([FromQuery] PagingParam<BaseSortCriteria> pagingParam)
    {
        var result = _postService.Get(pagingParam);
        return Ok(result);
    }
}
