namespace AIKernel.Abstractions.Context;

public class ContextAssemblyException : Exception
{
    public ContextAssemblyException(string message)
        : base(message)
    {
    }

    public ContextAssemblyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
