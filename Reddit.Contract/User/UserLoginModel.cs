using System.ComponentModel.DataAnnotations;

namespace Reddit.Contract.User;
public class UserLoginModel(string userName, string password)
{
    [Required]
    public string UserName { get; set; } = userName;

    [Required]
    public string Password { get; set; } = password;
}
