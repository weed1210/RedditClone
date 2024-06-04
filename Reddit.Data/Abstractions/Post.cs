using Reddit.Domain.Entities.Abstractions;

namespace Reddit.Domain.Entities;
public class Post : BaseEntity, ISoftDelete
{
    public string? Content { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public Guid MemberId { get; set; }
    public virtual Member? Member { get; set; }
}
