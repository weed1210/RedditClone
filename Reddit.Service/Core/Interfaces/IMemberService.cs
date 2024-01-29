using Reddit.Contract.Common;
using Reddit.Contract.Member;

namespace Reddit.Service.Core.Interfaces;
public interface IMemberService
{
    Task<ResultModel> Register(MemberRegisterModel model);
}
