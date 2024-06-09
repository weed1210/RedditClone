using AutoMapper;
using Reddit.Contract.Common.Paging;
using Reddit.Contract.Post;
using Reddit.DataAccess.Common.Paging;
using Reddit.DataAccess.Common.Utilities;
using Reddit.DataAccess.UnitOfWork;
using Reddit.Domain.Enums.Paging;
using Reddit.Service.Core.Abstractions;

namespace Reddit.Service.Core;
public class PostService(
    IUnitOfWork repo,
    IMapper mapper) : IPostService
{
    private readonly IUnitOfWork _repo = repo;
    private readonly IMapper _mapper = mapper;

    public PagingResponse<PostResponse> Get(PagingParam<BaseSortCriteria> pagingParam)
    {
        var posts = _repo.Posts.Get();
        return new PagingResponse<PostResponse>(pagingParam.PageIndex, pagingParam.PageSize, posts.Count())
        {
            Data = _mapper.Map<List<PostResponse>>(posts.Paginate(pagingParam))
        };
    }
}
