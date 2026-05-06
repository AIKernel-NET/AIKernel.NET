namespace AIKernel.Dtos.Sandbox;

/// <summary>
/// SandboxExecutionResult の契約を定義します。
/// </summary>
public sealed class SandboxExecutionResult
{
    public required bool Success { get; init; }
    public string? Result { get; init; }
    public string? ErrorMessage { get; init; }
    public long ExecutionTimeMs { get; init; }
    public string? StdOut { get; init; }
    public string? StdErr { get; init; }
}




