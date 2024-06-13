namespace Reddit.Contract.Task;
public class TaskGetRequest
{
    public Guid MemberId { get; set; }
    public string? SearchValue { get; set; }
    public string? SelectedStatus { get; set; }
}
