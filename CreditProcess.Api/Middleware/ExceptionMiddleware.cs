using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net;

/// <summary>
/// Golbal Exception midleware to haldle error in request pipeline.
/// <example>
///  exception will reise it return exception message  
/// <code>
/// Exception will prcess inside HandleExceptionAsync method
/// </code>
/// </example>
/// </summary>

namespace CreditProcess.Api;
[ExcludeFromCodeCoverage]
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

        var _errorDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "Internal Server Error",
            Status = (int)statusCode,
            Instance = httpContext.Request.Path,
            Detail = ex.Message,
        };
        await httpContext.Response.WriteAsJsonAsync(_errorDetails);
    }
}
