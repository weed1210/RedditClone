using Microsoft.AspNetCore.Diagnostics;
using Reddit.DataAccess.Common.Utilities;
using Reddit.Domain.Constant.Logging;
using Reddit.Domain.Enums.Logging;
using System.Net;
using System.Text.Json;

namespace Reddit.API.Extensions;

public static class ExceptionExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var error = contextFeature.Error;
                    var errorMessage = ExceptionHelper.GetErrorMessage(error);
                    logger.LogError(LogEvent.ERROR, error, LogTemplate.ERROR, errorMessage);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));
                }
            });
        });
    }
}
