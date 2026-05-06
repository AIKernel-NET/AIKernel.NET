namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく IScheduledJob の契約を定義します。
/// </summary>
public interface IScheduledJob
{
    string JobId { get; }
    string Description { get; }
    DateTime? LastExecutionTime { get; }
    DateTime? NextExecutionTime { get; }
    ScheduleStatus Status { get; }
    int ExecutionCount { get; }
    string? LastError { get; }
}




