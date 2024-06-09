using System.ComponentModel.DataAnnotations;

namespace Reddit.Contract.Member;
public class MemberRegisterRequest(string password, string email, string name, string phoneNumber)
{
    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$", ErrorMessage = "Password must be atleast 8 character and have lowercase, uppercase and special character")]
    public string Password { get; set; } = password;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = email;

    [Required]
    public string Name { get; set; } = name;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = phoneNumber;
}
