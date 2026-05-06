namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく ISchedulerExecutionResult の契約を定義します。
/// </summary>
public interface IExecutionResult
{
    string ExecutionId { get; }
    string JobId { get; }
    DateTime StartTime { get; }
    DateTime? EndTime { get; }
    bool Success { get; }
    string? Error { get; }
    string? Log { get; }
}




