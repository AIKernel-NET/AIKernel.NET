namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく ITaskExecutionResult の契約を定義します。
/// </summary>
public interface ITaskExecutionResult
{
    string TaskId { get; }
    bool Success { get; }
    string? Output { get; }
    string? Error { get; }
    long DurationMs { get; }
    int RetryCount { get; }
}




