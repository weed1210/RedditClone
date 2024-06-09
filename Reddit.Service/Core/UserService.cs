using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Reddit.Contract.Common.Auth;
using Reddit.Contract.User;
using Reddit.DataAccess.UnitOfWork;
using Reddit.Domain.Entities;
using Reddit.Domain.Enums;
using Reddit.Service.Core.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reddit.Service.Core;
public class UserService(
    IUnitOfWork repo,
    IConfiguration config,
    SignInManager<User> signInManager) : IUserService
{
    private readonly IUnitOfWork _repo = repo;
    private readonly IConfiguration _config = config;
    private readonly SignInManager<User> _signInManager = signInManager;

    public async Task<TokenResponse> LoginAsync(UserLoginRequest model)
    {
        try
        {
            var user = _repo.Users.Get().First(x => x.UserName == model.UserName);

            var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!check.Succeeded)
            {
                throw new Exception();
            }
            else
            {
                var userRoles = _repo.UserRoles.Get().Where(ur => ur.UserId == user.Id).ToList();
                var roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = _repo.Roles.Get().FirstOrDefault(x => x.Id == userRole.RoleId);
                    if (role != null) roles.Add(role.Name!);
                }
                return GetAccessToken(user, roles);
            }
        }
        catch (Exception)
        {
            throw new Exception("Username or password is not valid"); ;
        }
    }

    private TokenResponse GetAccessToken(User user, List<string> roles)
    {
        List<Claim> claims = [];
        switch (user.Type)
        {
            case UserType.Member:
                claims = GetClaims((Member)user, roles);
                break;
            case UserType.Staff:
                claims = GetClaims((Staff)user, roles);
                break;
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
          _config["Jwt:Issuer"],
        claims,
          expires: DateTime.Now.AddDays(int.Parse(_config["Jwt:ExpireTimes"]!)),
          //int.Parse(_configuration["Jwt:ExpireTimes"]) * 3600
          signingCredentials: creds);

        var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);

        return new TokenResponse
        {
            Access_token = serializedToken,
            Token_type = "Bearer",
            Expires_in = int.Parse(_config["Jwt:ExpireTimes"]!) * 60 * 60 * 24,
            UserID = user.Id.ToString(),
            UserName = user.UserName ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty,
            Roles = roles
        };
    }

    private static List<Claim> GetClaims(Member user, List<string> roles)
    {
        //IdentityOptions _options = new();
        var claims = new List<Claim> {
            new("UserId", user.Id.ToString()),
            new("Email", user.Email!),
            new("UserName", user.UserName ?? string.Empty)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        if (!string.IsNullOrEmpty(user.PhoneNumber)) claims.Add(new Claim("PhoneNumber", user.PhoneNumber));
        return claims;
    }

    private static List<Claim> GetClaims(Staff user, List<string> roles)
    {
        //IdentityOptions _options = new();
        var claims = new List<Claim> {
            new("UserId", user.Id.ToString()),
            new("Email", user.Email!),
            new("UserName", user.UserName ?? string.Empty)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        if (!string.IsNullOrEmpty(user.PhoneNumber)) claims.Add(new Claim("PhoneNumber", user.PhoneNumber));
        return claims;
    }
}
