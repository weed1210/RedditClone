namespace Reddit.DataAccess.Common.Paging;

public static class PagingHelper
{
    public static IQueryable<TObject> GetWithPaging<TObject>(this IQueryable<TObject> source, int page, int pageSize)
        where TObject : class
    {
        if (source == null)
        {
            return Enumerable.Empty<TObject>().AsQueryable();
        }

        pageSize = pageSize < 1 ? 1 : pageSize;
        page = page < 1 ? 1 : page;

        return source
            .Skip(page == 1 ? 0 : pageSize * (page - 1))
            .Take(pageSize);
    }
}