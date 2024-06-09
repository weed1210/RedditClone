﻿namespace Reddit.Contract.Task;
public class TaskResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public string? Status { get; set; }

    public Guid MemberId { get; set; }
}
