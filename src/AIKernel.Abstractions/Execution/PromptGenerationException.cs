namespace AIKernel.Abstractions.Execution;

public abstract class PromptGenerationException : Exception
{
    protected PromptGenerationException(string message)
        : base(message)
    {
    }
}
