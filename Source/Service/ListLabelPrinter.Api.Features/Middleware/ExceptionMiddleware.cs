using System.Net;
using System.Text.Json;
using ListLabelPrinter.Api.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ListLabelPrinter.Api.Features.Middleware;

public sealed class ExceptionMiddleware : IMiddleware
{
    private const string ResponseContentType = "application/json";
    private const string ServerError = "Server error";
    private const string NotFound = "Not found";
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "");
            await HandleExceptionAsync(context, ex);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        ProblemDetails problemDetails = GetProblemDetails(exception);
        context.Response.ContentType = ResponseContentType;
        context.Response.StatusCode = problemDetails.Status.Value;
        string json = JsonSerializer.Serialize(problemDetails);
        await context.Response.WriteAsync(json);
    }

    private static ProblemDetails GetProblemDetails(Exception exception)
    {
        return exception switch
        {
            MissingRequiredConfigurationException missingRequiredConfigurationException => new ProblemDetails
            {
                Status = (int) HttpStatusCode.InternalServerError,
                Type = ServerError,
                Title = ServerError,
                Detail = missingRequiredConfigurationException.Message
            },
            FileNotFoundException fileNotFoundException => new ProblemDetails
            {
                Status = (int) HttpStatusCode.NotFound,
                Type = NotFound,
                Title = NotFound,
                Detail = fileNotFoundException.Message
            },
            _ => new ProblemDetails
            {
                Status = (int) HttpStatusCode.InternalServerError,
                Type = ServerError,
                Title = ServerError,
                Detail = exception.Message
            }
        };
    }
}