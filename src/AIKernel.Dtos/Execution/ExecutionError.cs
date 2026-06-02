namespace AIKernel.Dtos.Execution;

public sealed record ExecutionError(
    string Code,
    string Message,
    string? Detail = null);
