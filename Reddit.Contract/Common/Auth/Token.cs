namespace Reddit.Contract.Common.Auth;
public class Token
{
    public string? Access_token { get; set; }
    public string? Token_type { get; set; }
    public string? UserID { get; set; }
    public int Expires_in { get; set; }
    public string? UserName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserAva { get; set; }
    public int CurrenNoticeCount { get; set; }
    public List<string> Roles { get; set; } = [];
}
