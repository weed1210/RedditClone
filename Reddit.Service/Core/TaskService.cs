using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reddit.Contract.Task;
using Reddit.DataAccess.Common.Paging;
using Reddit.DataAccess.Common.Utilities;
using Reddit.DataAccess.UnitOfWork;
using Reddit.Domain.Enums.Paging;
using Reddit.Service.Core.Abstractions;
using Task = Reddit.Domain.Entities.Task;

namespace Reddit.Service.Core;
public class TaskService(
    IUnitOfWork repo,
    IMapper mapper) : ITaskService
{
    private readonly IUnitOfWork _repo = repo;
    private readonly IMapper _mapper = mapper;

    public List<TaskResponse> Get(PagingParam<TaskSortCriteria> pagingParam, TaskGetRequest request)
    {
        var searchValue = request.SearchValue ?? "";
        var posts = _repo.Tasks.Get()
            .Where(x => x.MemberId == request.MemberId
                && ((x.Description ?? "").Contains(searchValue) || (x.Title ?? "").Contains(searchValue))
                && (request.SelectedStatus == null || (x.Status ?? "").Contains(request.SelectedStatus)));
        pagingParam.PageSize = int.MaxValue;
        //return new PagingResponse<TaskResponse>(pagingParam.PageIndex, pagingParam.PageSize, posts.Count())
        //{
        //    Data = _mapper.Map<List<TaskResponse>>(posts.Paginate(pagingParam))
        //};
        return _mapper.Map<List<TaskResponse>>(posts.Paginate(pagingParam));
    }

    public async Task<TaskResponse> GetOneAsync(int taskId) => _mapper.Map<TaskResponse>(await GetTaskAsync(taskId));

    private async Task<Task> GetTaskAsync(int taskId) => await _repo.Tasks.Get()
            .FirstAsync(x => x.Id == taskId)
            ?? throw new Exception("Task not exist");

    public async Task<TaskResponse> CreateAsync(TaskCreateRequest request)
    {
        var task = _mapper.Map<Task>(request);
        _repo.Tasks.Create(task);
        await _repo.SaveAsync();

        return _mapper.Map<TaskResponse>(task);
    }

    public async Task<TaskResponse> UpdateAsync(TaskUpdateRequest request)
    {
        var task = await GetTaskAsync(request.Id);
        _mapper.Map(request, task);
        _repo.Tasks.Update(task);
        await _repo.SaveAsync();

        return _mapper.Map<TaskResponse>(task);
    }

    public async Task<int> DeleteAsync(int taskId)
    {
        _repo.Tasks.Delete(await GetTaskAsync(taskId));
        await _repo.SaveAsync();

        return taskId;
    }
}
