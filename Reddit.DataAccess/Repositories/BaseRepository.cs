using Reddit.DataAccess.Repositories.Abstraction;
using Reddit.Domain.Database;

namespace Reddit.DataAccess.Repositories;
public abstract class BaseRepository<T>(RedditDbContext dbContext) : IBaseRepository<T> where T : class
{
    protected RedditDbContext DbContext { get; set; } = dbContext;

    public virtual IQueryable<T> Get() => DbContext.Set<T>().AsQueryable();

    public virtual void Create(T entity) => DbContext.Set<T>().Add(entity);

    public virtual void Update(T entity) => DbContext.Set<T>().Update(entity);

    public virtual void Delete(T entity) => DbContext.Set<T>().Remove(entity);
}
