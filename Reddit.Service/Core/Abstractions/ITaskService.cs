using Reddit.Contract.Common.Paging;
using Reddit.Contract.Task;
using Reddit.DataAccess.Common.Paging;
using Reddit.Domain.Enums.Paging;

namespace Reddit.Service.Core.Abstractions;
public interface ITaskService
{
    List<TaskResponse> Get(PagingParam<BaseSortCriteria> pagingParam);
    Task<TaskResponse> GetOneAsync(int taskId);
    Task<TaskResponse> CreateAsync(TaskCreateRequest request);
    Task<TaskResponse> UpdateAsync(TaskUpdateRequest request);
    Task<int> DeleteAsync(int taskId);
}
