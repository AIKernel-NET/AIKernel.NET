namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく IScheduleSpec の契約を定義します。
/// </summary>
public interface IScheduleSpec
{
    string JobId { get; }
    string Description { get; }
    string WorkId { get; }
    string? CronExpression { get; }
    int? TimeoutMs { get; }
    int MaxRetries { get; }
}




