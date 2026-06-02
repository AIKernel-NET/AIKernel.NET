namespace AIKernel.Abstractions.Execution;

public sealed class UnsupportedPromptCapabilityException : PromptGenerationException
{
    public UnsupportedPromptCapabilityException(string message)
        : base(message)
    {
    }
}
