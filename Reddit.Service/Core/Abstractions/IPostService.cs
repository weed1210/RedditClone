using Reddit.Contract.Common.Paging;
using Reddit.Contract.Post;
using Reddit.DataAccess.Common.Paging;
using Reddit.Domain.Enums.Paging;

namespace Reddit.Service.Core.Abstractions;
public interface IPostService
{
    PagingResponse<PostResponse> Get(PagingParam<BaseSortCriteria> pagingParam);
}
