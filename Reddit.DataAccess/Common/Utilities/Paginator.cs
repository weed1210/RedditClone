using Reddit.DataAccess.Common.Paging;

namespace Reddit.DataAccess.Common.Utilities;
public static class Paginator
{
    public static IQueryable<T> Paginate<T, P>(this IQueryable<T> entities, PagingParam<P> pagingParam)
        where T : class
        where P : Enum
    {
        return entities
            .GetWithSorting(pagingParam.SortKey?.ToString() ?? string.Empty, pagingParam.SortOrder)
            .GetWithPaging(pagingParam.PageIndex, pagingParam.PageSize);
    }
}
