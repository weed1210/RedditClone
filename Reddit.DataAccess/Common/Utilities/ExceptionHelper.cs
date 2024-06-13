using Reddit.Contract.Common.Error;

namespace Reddit.DataAccess.Common.Utilities;
public static class ExceptionHelper
{
    public static ErrorResult GetErrorMessage(Exception e)
    {
        return new ErrorResult
        {
            Message = e.Message + "\n" + (e.InnerException?.Message ?? string.Empty),
            Trace = e.StackTrace
        };
    }
}
