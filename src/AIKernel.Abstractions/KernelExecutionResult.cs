using AIKernel.Abstractions.Execution;

namespace AIKernel.Abstractions;

public sealed class KernelExecutionResult
{
    public bool Success { get; init; }
    public IExecutionOutput? Data { get; init; }
    public string? Error { get; init; }
    public List<FailureMode> FailureModes { get; init; } = new();
    public TimeSpan ExecutionTime { get; init; }
}
