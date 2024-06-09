using Reddit.Contract.Member;

namespace Reddit.Service.Core.Abstractions;
public interface IMemberService
{
    Task<MemberResponse> RegisterAsync(MemberRegisterRequest model);
}
