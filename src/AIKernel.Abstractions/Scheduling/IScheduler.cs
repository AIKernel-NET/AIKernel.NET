namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく契約です。
/// Scheduled job を参照する capability interface です。
/// </summary>
public interface IScheduledJobReader
{
    Task<IScheduledJob?> GetJobAsync(string jobId);

    Task<IReadOnlyList<IScheduledJob>> ListJobsAsync();
}

/// <summary>
/// UC-28 に基づく契約です。
/// Job を schedule する capability interface です。
/// </summary>
public interface IJobScheduler
{
    Task<IScheduledJob> ScheduleAsync(IScheduleSpec job);
}

/// <summary>
/// UC-28 に基づく契約です。
/// Scheduled job を cancel する capability interface です。
/// </summary>
public interface IScheduledJobCanceller
{
    Task<bool> CancelAsync(string jobId);
}

/// <summary>
/// UC-28 に基づく契約です。
/// Scheduled job の実行結果を参照する capability interface です。
/// </summary>
public interface IScheduledExecutionResultReader
{
    Task<IExecutionResult?> GetExecutionResultAsync(string jobId);
}

/// <summary>
/// UC-28 に基づく IScheduler の互換合成 contract を定義します。
/// </summary>
public interface IScheduler :
    IProvider,
    IScheduledJobReader,
    IJobScheduler,
    IScheduledJobCanceller,
    IScheduledExecutionResultReader
{
}
