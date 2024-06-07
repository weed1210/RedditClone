using Reddit.Domain.Enums.Paging;
using System.Linq.Expressions;

namespace Reddit.DataAccess.Common.Paging;

public static class SortingHelper
{
    public static IQueryable<TObject> GetWithSorting<TObject>(this IQueryable<TObject> source,
        string sortKey, OrderCriteria sortOrder)
        where TObject : class
    {
        if (source == null) return Enumerable.Empty<TObject>().AsQueryable();

        if (sortKey != null)
        {
            var param = Expression.Parameter(typeof(TObject), "p");
            var prop = Expression.Property(param, sortKey);
            var exp = Expression.Lambda(prop, param);
            string method = sortOrder switch
            {
                OrderCriteria.ASC => "OrderBy",
                _ => "OrderByDescending",
            };
            Type[] types = [source.ElementType, exp.Body.Type];
            var mce = Expression.Call(typeof(Queryable), method, types, source.Expression, exp);
            return source.Provider.CreateQuery<TObject>(mce);
        }
        return source;
    }
}