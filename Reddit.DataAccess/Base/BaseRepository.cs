using Reddit.Domain.Database;

namespace Reddit.DataAccess.Base;
public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected RedditDbContext DbContext { get; set; }

    protected BaseRepository(RedditDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public IQueryable<T> Get() => DbContext.Set<T>().AsQueryable();

    public void Create(T entity) => DbContext.Set<T>().Add(entity);

    public void Update(T entity) => DbContext.Set<T>().Update(entity);

    public void Delete(T entity) => DbContext.Set<T>().Remove(entity);
}
