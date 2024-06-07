using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Reddit.Contract.Common;
using Reddit.Contract.Member;
using Reddit.Data.Enums;
using Reddit.DataAccess.Common.Utilities;
using Reddit.DataAccess.UnitOfWork;
using Reddit.Domain.Constant.Logging;
using Reddit.Domain.Entities;
using Reddit.Domain.Enums.Logging;
using Reddit.Service.Core.Abstractions;

namespace Reddit.Service.Core;
public class MemberService(
    IUnitOfWork repo, 
    IMapper mapper, 
    UserManager<User> userManager, 
    ILogger<MemberService> logger) : IMemberService
{
    private readonly IUnitOfWork _repo = repo;
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;
    private readonly ILogger<MemberService> _logger = logger;

    public async Task<ResultModel> Register(MemberRegisterModel model)
    {
        var result = new ResultModel();

        try
        {
            var member = _mapper.Map<Member>(model);
            var createUserResult = await _userManager.CreateAsync(member, model.Password);

            if (!createUserResult.Succeeded)
            {
                throw new Exception(string.Join(". ", createUserResult.Errors.Select(x => x.Description)));
            }
            else
            {
                var memberRole = _repo.Roles.Get()
                    .First(x => x.Name == nameof(RoleType.Member))
                    ?? throw new Exception("Role not exist");

                _repo.UserRoles.Create(new UserRole
                {
                    RoleId = memberRole.Id,
                    UserId = member.Id,
                });

                await _repo.SaveAsync();
                result.Data = _mapper.Map<MemberModel>(member);
            }
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
