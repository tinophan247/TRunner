using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TRunner.Application.Middleware.Exceptions.Contracts;
using TRunner.Core.Common.Exceptions;

namespace TRunner.Application.Middleware.Exceptions;

/// <summary>
/// A middleware to handle exceptions thrown.
/// </summary>
public sealed class ExceptionHandlingMiddleware
{
    /// <summary>
    /// The default error response when an exception occurs.
    /// </summary>
    internal static readonly string DefaultErrorMessage =
        $"An error occured during the request. See {nameof(ProblemDetail.Message)} for additional detail.";

    /// <summary>
    /// Settings for the JSON serialization.
    /// </summary>
    private readonly JsonSerializerOptions _jsonSettings;

    /// <summary>
    /// The application logger.
    /// </summary>
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    /// <summary>
    /// A delegate used to invoke the next step in the web pipeline.
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware" /> class.
    /// </summary>
    /// <param name="next">A delegate used to invoke the next step in the web pipeline.</param>
    /// <param name="logger">The application logger.</param>
    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;

        _jsonSettings = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        _jsonSettings.Converters.Add(new JsonStringEnumConverter());
    }

    /// <summary>
    /// High level exception handler for exceptions thrown for requests sent down the pipeline.
    /// </summary>
    /// <param name="httpContext"><see cref="T:Microsoft.AspNetCore.Http.HttpContext" />HttpContext delegate.</param>
    /// <returns>A <see cref="Task" /> representing the result of the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(exception, httpContext);
        }
    }

    /// <summary>
    /// Generates a <see cref="ProblemDetail" /> for the response with information about the exception thrown.
    /// </summary>
    /// <param name="exception">The exception that has been caught.</param>
    /// <param name="httpContext"><see cref="T:Microsoft.AspNetCore.Http.HttpContext" />HttpContext delegate.</param>
    private BaseErrorResponse GenerateProblemDetailResponse(Exception exception, HttpContext httpContext)
    {
        var message = exception.Message;
        var statusCode = HttpStatusCode.InternalServerError;
        var traceId = Activity.Current?.Id;

        if (exception is AggregateException aggregateException)
        {
            var firstMessageAppException =
                aggregateException.InnerExceptions.FirstOrDefault(e => e is MessageAppException) as MessageAppException;
            message = firstMessageAppException?.Message ?? message;
            statusCode = firstMessageAppException?.StatusCode ?? statusCode;
        }

        if (exception is MessageAppException httpException)
        {
            message = httpException.Message;
            statusCode = httpException.StatusCode;
            _logger.LogError(exception, httpException.LoggedMessage, httpException.Args!);

            if (exception is BadRequestException badRequestException)
            {
                return badRequestException.BadRequestResponse;
            }
        }
        else if (exception is KnownAPIException knownApiException)
        {
            _logger.LogError(exception, message);
            return new ProblemDetail(
                DefaultErrorMessage,
                httpContext.TraceIdentifier,
                knownApiException.StatusCode,
                knownApiException.Message,
                traceId!);
        }
        else
        {
            _logger.LogError(exception, "An exception was thrown");
        }

        var response = new ProblemDetail(
            DefaultErrorMessage,
            httpContext.TraceIdentifier,
            (int)statusCode,
            message,
            traceId!);

        return response;
    }

    /// <summary>
    /// Handles exceptions thrown.
    /// </summary>
    /// <param name="exception">The exception thrown from the application.</param>
    /// <param name="httpContext"><see cref="T:Microsoft.AspNetCore.Http.HttpContext" />HttpContext delegate.</param>
    /// <returns>An awaitable task.</returns>
    private Task HandleExceptionAsync(Exception exception, HttpContext httpContext)
    {
        // We can't do anything if the response has already started, just abort.
        if (httpContext.Response.HasStarted)
        {
            _logger.LogError(
                exception,
                "The response has already started, the error handler will not be executed");
            exception.Rethrow();
        }

        var response = GenerateProblemDetailResponse(exception, httpContext);
        var result = JsonSerializer.Serialize(response, response.GetType(), _jsonSettings);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = response.Status;
        return httpContext.Response.WriteAsync(result);
    }
}