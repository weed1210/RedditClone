namespace Reddit.Contract.Common;
public class ResultModel
{
    public string? ErrorMessage { get; set; }
    public object? Data { get; set; }
    public bool Succeed { get; set; } = true;
    public int Code { get; set; }

    public void SetError(string errorMessage)
    {
        Succeed = false;
        ErrorMessage = errorMessage;
    }
}
