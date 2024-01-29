﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Reddit.Contract.Common;
using Reddit.Contract.Common.Paging;
using Reddit.Contract.Post;
using Reddit.DataAccess.Common.Paging;
using Reddit.DataAccess.Common.Utilities;
using Reddit.DataAccess.UnitOfWork;
using Reddit.Domain.Constant.Logging;
using Reddit.Domain.Enums.Logging;
using Reddit.Domain.Enums.Paging;
using Reddit.Service.Core.Interfaces;

namespace Reddit.Service.Core;
public class PostService : IPostService
{
    private readonly IUnitOfWork _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<PostService> _logger;

    public PostService(IUnitOfWork repo, IMapper mapper, ILogger<PostService> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public ResultModel Get(PagingParam<BaseSortCriteria> pagingParam)
    {
        var result = new ResultModel();

        try
        {
            var posts = _repo.Posts.Get();
            result.Data = new PagingModel(pagingParam.PageIndex, pagingParam.PageSize, posts.Count())
            {
                Data = _mapper.Map<List<PostModel>>(posts.Paginate(pagingParam))
            };
            result.Succeed = true;
        }
        catch (Exception e)
        {
            var errorMessage = HelperFunction.GetErrorMessage(e);
            _logger.LogError(LogEvent.ERROR, e, LogTemplate.ERROR, errorMessage);
            result.SetError(errorMessage);
        }

        return result;
    }
}