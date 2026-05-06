using AIKernel.Enums;

namespace AIKernel.Dtos.Kernel;

/// <summary>
/// KernelExecutionResult の契約を定義します。
/// </summary>
public sealed record KernelExecutionResult
{
    public required bool Success { get; init; }
    public string? Data { get; init; }
    public string? Error { get; init; }
    public IReadOnlyList<FailureMode> FailureModes { get; init; } = new List<FailureMode>();
    public required TimeSpan ExecutionTime { get; init; }
}



