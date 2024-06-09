namespace Reddit.Domain.Entities;
public class Task
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public string? Status { get; set; }

    public Guid MemberId { get; set; }
    public virtual Member? Member { get; set; }
}
