namespace Reddit.DataAccess.Base;
internal interface IBaseRepository<T>
{
    IQueryable<T> Get();
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
