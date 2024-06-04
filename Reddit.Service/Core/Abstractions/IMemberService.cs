using Reddit.Contract.Common;
using Reddit.Contract.Member;

namespace Reddit.Service.Core.Abstractions;
public interface IMemberService
{
    Task<ResultModel> Register(MemberRegisterModel model);
}
