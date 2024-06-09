using Reddit.DataAccess.Repositories.Abstractions;
using Reddit.Domain.Database;
using Task = Reddit.Domain.Entities.Task;

namespace Reddit.DataAccess.Repositories;
public class TaskRepository(RedditDbContext dbContext) : BaseRepository<Task>(dbContext), ITaskRepository
{
}
