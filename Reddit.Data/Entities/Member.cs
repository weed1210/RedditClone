namespace Reddit.Domain.Entities;
public class Member : User
{
    public string? Name { get; set; }

    public virtual ICollection<Post>? Posts { get; set; }

    public virtual ICollection<Task>? Tasks { get; set; }

    public virtual ICollection<Task>? CoperatingTasks { get; set; }
}
