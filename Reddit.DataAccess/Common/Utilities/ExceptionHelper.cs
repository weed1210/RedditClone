namespace Reddit.DataAccess.Common.Utilities;
public static class ExceptionHelper
{
    public static string GetErrorMessage(Exception e)
    {
        return e.Message + "\n" + (e.InnerException?.Message ?? string.Empty) + "\n ***Trace*** \n" + e.StackTrace;
    }
}
