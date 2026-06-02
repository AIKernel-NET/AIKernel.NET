namespace AIKernel.Dtos.Execution;

public enum PromptOverflowPolicy
{
    FailClosed = 0,

    TruncateLowestPriorityContext = 1
}
