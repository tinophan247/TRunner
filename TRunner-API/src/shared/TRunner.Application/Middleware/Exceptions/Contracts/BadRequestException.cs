using System.Net;
using TRunner.Core.Common.Exceptions;

namespace TRunner.Application.Middleware.Exceptions.Contracts;

/// <summary>
/// Thrown when a 400 http status response.
/// </summary>
public sealed class BadRequestException : MessageAppException
{
    /// <summary>
    /// Designated ctor.
    /// </summary>
    /// <param name="badRequestResponse">The bad exception response.</param>
    public BadRequestException(BadRequestResponse badRequestResponse)
        : base(
            "The underlying service received an unexpected response.",
            HttpStatusCode.BadRequest,
            "The request generated a 400 bad request {@Response}",
            badRequestResponse)
    {
        BadRequestResponse = badRequestResponse;
    }

    /// <summary>
    /// Contains the bad request context.
    /// </summary>
    public BadRequestResponse BadRequestResponse { get; }
}