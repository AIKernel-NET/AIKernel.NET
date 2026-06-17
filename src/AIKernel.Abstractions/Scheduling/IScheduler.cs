namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく契約です。
/// EN: Scheduled job を参照する capability interface です。
/// [EN] Documents this public package API member. [JA] IScheduledJobReader の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledJobReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledJobReader']" />
public interface IScheduledJobReader
{
    /// <summary>EN: Executes the GetJobAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetJobAsync 操作を実行します。</summary>
    Task<IScheduledJob?> GetJobAsync(string jobId);

    /// <summary>EN: Executes the ListJobsAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ListJobsAsync 操作を実行します。</summary>
    Task<IReadOnlyList<IScheduledJob>> ListJobsAsync();
}

/// <summary>
/// UC-28 に基づく契約です。
/// EN: Job を schedule する capability interface です。
/// [EN] Documents this public package API member. [JA] IJobScheduler の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IJobScheduler']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IJobScheduler']" />
public interface IJobScheduler
{
    /// <summary>EN: Executes the ScheduleAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ScheduleAsync 操作を実行します。</summary>
    Task<IScheduledJob> ScheduleAsync(IScheduleSpec job);
}

/// <summary>
/// UC-28 に基づく契約です。
/// EN: Scheduled job を cancel する capability interface です。
/// [EN] Documents this public package API member. [JA] IScheduledJobCanceller の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledJobCanceller']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledJobCanceller']" />
public interface IScheduledJobCanceller
{
    /// <summary>EN: Executes the CancelAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CancelAsync 操作を実行します。</summary>
    Task<bool> CancelAsync(string jobId);
}

/// <summary>
/// UC-28 に基づく契約です。
/// EN: Scheduled job の実行結果を参照する capability interface です。
/// [EN] Documents this public package API member. [JA] IScheduledExecutionResultReader の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledExecutionResultReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledExecutionResultReader']" />
public interface IScheduledExecutionResultReader
{
    /// <summary>EN: Executes the GetExecutionResultAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetExecutionResultAsync 操作を実行します。</summary>
    Task<IScheduledExecutionResult?> GetExecutionResultAsync(string jobId);
}

/// <summary>
/// EN: UC-28 に基づく IScheduler の互換合成 contract を定義します。
/// [EN] Documents this public package API member. [JA] IScheduler の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduler']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduler']" />
public interface IScheduler :
    IProvider,
    IScheduledJobReader,
    IJobScheduler,
    IScheduledJobCanceller,
    IScheduledExecutionResultReader
{
}
