using System.ComponentModel.DataAnnotations;

namespace Reddit.Contract.Member;
public class MemberRegisterModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$", ErrorMessage = "Password must be atleast 8 character and have lowercase, uppercase and special character")]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    public MemberRegisterModel(string userName, string password, string email, string name, string phoneNumber)
    {
        UserName = userName;
        Password = password;
        Email = email;
        Name = name;
        PhoneNumber = phoneNumber;
    }
}
