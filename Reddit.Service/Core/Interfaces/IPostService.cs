using Reddit.Contract.Common;
using Reddit.DataAccess.Common.Paging;
using Reddit.Domain.Enums.Paging;

namespace Reddit.Service.Core.Interfaces;
public interface IPostService
{
    ResultModel Get(PagingParam<BaseSortCriteria> pagingParam);
}
