using Reddit.DataAccess.Repositories.Abstraction;
using Task = Reddit.Domain.Entities.Task;

namespace Reddit.DataAccess.Repositories.Abstractions;
public interface ITaskRepository : IBaseRepository<Task>
{
}
