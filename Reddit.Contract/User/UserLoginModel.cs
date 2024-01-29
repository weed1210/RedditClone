using System.ComponentModel.DataAnnotations;

namespace Reddit.Contract.User;
public class UserLoginModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    public UserLoginModel(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}
