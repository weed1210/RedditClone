namespace Reddit.Domain.Entities.Base;
public interface ISoftDelete
{
    public DateTimeOffset? DeletedAt { get; set; }

    public void Restore()
    {
        DeletedAt = null;
    }
}
