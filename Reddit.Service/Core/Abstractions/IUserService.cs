using Reddit.Contract.Common;
using Reddit.Contract.User;

namespace Reddit.Service.Core.Abstractions;
public interface IUserService
{
    Task<ResultModel> Login(UserLoginModel model);
}
