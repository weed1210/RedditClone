using Reddit.Contract.Common.Auth;
using Reddit.Contract.User;

namespace Reddit.Service.Core.Abstractions;
public interface IUserService
{
    Task<TokenResponse> LoginAsync(UserLoginRequest model);
}
