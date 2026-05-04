namespace AIKernel.Abstractions.Exceptions;

public class QuarantineFailedException : Exception
{
    public QuarantineFailedException(string message) : base(message) { }

    public QuarantineFailedException(string message, Exception innerException)
        : base(message, innerException) { }

    public QuarantineFailedException(string message, string? fragmentId, string? reason)
        : base(message)
    {
        FragmentId = fragmentId;
        Reason = reason;
    }

    public string? FragmentId { get; }
    public string? Reason { get; }
}
