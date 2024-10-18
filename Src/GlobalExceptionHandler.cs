using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace GFTGrovelorDeveloperCodeChallenge;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not NotImplementedException)
        {

            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

            Log.Error(
                exception,
                "Could not process a request on machine {MachineName}. TraceId: {traceId}",
                Environment.MachineName,
                traceId
            );

            var (statusCode, title) = MapException(exception);

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(new Dictionary<string, object?>{
                {"title", title},
                {"traceId", traceId}
            }, cancellationToken);

            return true;
        }

        return false;
    }

    private static (int StatusCode, string Title) MapException(Exception exception)
    {
        return exception switch
        {
            ApplicationException => (StatusCodes.Status400BadRequest, exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "Something went wrong but we are working on it!")
        };
    }
}