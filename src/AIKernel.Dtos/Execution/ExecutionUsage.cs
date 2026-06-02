namespace AIKernel.Dtos.Execution;

public sealed record ExecutionUsage(
    int InputTokens,
    int OutputTokens,
    int TotalTokens);
