using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reddit.API.Controllers.Abstractions;
using Reddit.Contract.Task;
using Reddit.DataAccess.Common.Paging;
using Reddit.Domain.Enums.Paging;
using Reddit.Service.Core.Abstractions;

namespace Reddit.API.Controllers;
public class TasksController(ITaskService taskService) : BaseApiController
{

    private readonly ITaskService _taskService = taskService;

    [HttpGet]
    public ActionResult Get([FromQuery] PagingParam<BaseSortCriteria> pagingParam, [FromQuery] TaskGetRequest request)
    {
        var result = _taskService.Get(pagingParam, request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetOneAsync([FromRoute] int id)
    {
        var result = await _taskService.GetOneAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(TaskCreateRequest request)
    {
        var result = await _taskService.CreateAsync(request);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync(TaskUpdateRequest request)
    {
        var result = await _taskService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await _taskService.DeleteAsync(id);
        return Ok(result);
    }
}
