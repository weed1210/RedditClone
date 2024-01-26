namespace Reddit.DataAccess.Base;
public interface IBaseRepository<T>
{
    IQueryable<T> Get();
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
