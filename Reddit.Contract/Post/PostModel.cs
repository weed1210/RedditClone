namespace Reddit.Contract.Post;
public class PostModel
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public string? Content { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public Guid MemberId { get; set; }
}
