namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく scheduled execution result の契約を定義します。
/// </summary>
public interface IScheduledExecutionResult
{
    string ExecutionId { get; }
    string JobId { get; }
    DateTime StartTime { get; }
    DateTime? EndTime { get; }
    bool Success { get; }
    string? Error { get; }
    string? Log { get; }
}




