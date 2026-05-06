namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく IScheduler の契約を定義します。
/// </summary>
public interface IScheduler : IProvider
{
    Task<IScheduledJob?> GetJobAsync(string jobId);
    Task<IScheduledJob> ScheduleAsync(IScheduleSpec job);
    Task<bool> CancelAsync(string jobId);
    Task<IReadOnlyList<IScheduledJob>> ListJobsAsync();
    Task<IExecutionResult?> GetExecutionResultAsync(string jobId);
}




