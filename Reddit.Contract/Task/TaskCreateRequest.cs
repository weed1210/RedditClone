namespace Reddit.Contract.Task;
public class TaskCreateRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public string? Status { get; set; }
    public int Priority { get; set; }

    public Guid MemberId { get; set; }
    public Guid? CoperatorId { get; set; }
}
