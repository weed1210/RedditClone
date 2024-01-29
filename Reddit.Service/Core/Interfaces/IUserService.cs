using Reddit.Contract.Common;
using Reddit.Contract.User;

namespace Reddit.Service.Core.Interfaces;
public interface IUserService
{
    Task<ResultModel> Login(UserLoginModel model);
}
