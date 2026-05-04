namespace AIKernel.Abstractions.Exceptions;

public class AttentionPollutionException : Exception
{
    public AttentionPollutionException(string message) : base(message) { }

    public AttentionPollutionException(string message, Exception innerException)
        : base(message, innerException) { }
}
