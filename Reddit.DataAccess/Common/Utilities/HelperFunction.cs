using Reddit.DataAccess.Common.Paging;

namespace Reddit.DataAccess.Common.Utilities;
public static class HelperFunction
{
    public static string GetErrorMessage(Exception e)
    {
        return e.Message + "\n" + (e.InnerException?.Message ?? string.Empty) + "\n ***Trace*** \n" + e.StackTrace;
    }

    public static IQueryable<T> Paginate<T, P>(this IQueryable<T> entities, PagingParam<P> pagingParam)
        where T : class
        where P : Enum
    {
        return entities
            .GetWithSorting(pagingParam.SortKey?.ToString() ?? string.Empty, pagingParam.SortOrder)
            .GetWithPaging(pagingParam.PageIndex, pagingParam.PageSize);
    }
}
