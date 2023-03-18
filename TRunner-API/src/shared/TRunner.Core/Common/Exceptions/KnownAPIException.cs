namespace TRunner.Core.Common.Exceptions;

public class KnownAPIException : ApplicationException
{
    public KnownAPIException(string? message, int statusCode, Exception? innerException = null)
        : base(message ?? "An unexpected fault happened. Try again later.", innerException)
    {
        StatusCode = statusCode;
    }

    public int StatusCode { get; set; }
}
