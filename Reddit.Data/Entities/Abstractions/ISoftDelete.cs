namespace Reddit.Domain.Entities.Abstractions;
public interface ISoftDelete
{
    public DateTimeOffset? DeletedAt { get; set; }

    public void Restore()
    {
        DeletedAt = null;
    }
}
