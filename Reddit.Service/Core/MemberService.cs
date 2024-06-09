using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reddit.Contract.Member;
using Reddit.Data.Enums;
using Reddit.DataAccess.UnitOfWork;
using Reddit.Domain.Entities;
using Reddit.Service.Core.Abstractions;

namespace Reddit.Service.Core;
public class MemberService(
    IUnitOfWork repo,
    IMapper mapper,
    UserManager<User> userManager) : IMemberService
{
    private readonly IUnitOfWork _repo = repo;
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<MemberResponse> RegisterAsync(MemberRegisterRequest model)
    {
        var member = _mapper.Map<Member>(model);
        var createUserResult = await _userManager.CreateAsync(member, model.Password);

        if (!createUserResult.Succeeded)
        {
            throw new Exception(string.Join(". ", createUserResult.Errors.Select(x => x.Description)));
        }
        else
        {
            var memberRole = await _repo.Roles.Get()
                .FirstAsync(x => x.Name == nameof(RoleType.Member))
                ?? throw new Exception("Role not exist");

            _repo.UserRoles.Create(new UserRole
            {
                RoleId = memberRole.Id,
                UserId = member.Id,
            });

            await _repo.SaveAsync();
        }

        return _mapper.Map<MemberResponse>(member);
    }
}
