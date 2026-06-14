namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく IScheduledJob の契約を定義します。
/// JA: IScheduledJob の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledJob']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledJob']" />
public interface IScheduledJob
{
    /// <summary>Gets the JobId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される JobId 値を取得します。</summary>
    string JobId { get; }
    /// <summary>Gets the Description value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Description 値を取得します。</summary>
    string Description { get; }
    /// <summary>Gets the LastExecutionTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される LastExecutionTime 値を取得します。</summary>
    DateTime? LastExecutionTime { get; }
    /// <summary>Gets the NextExecutionTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される NextExecutionTime 値を取得します。</summary>
    DateTime? NextExecutionTime { get; }
    /// <summary>Gets the Status value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Status 値を取得します。</summary>
    ScheduleStatus Status { get; }
    /// <summary>Gets the ExecutionCount value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutionCount 値を取得します。</summary>
    int ExecutionCount { get; }
    /// <summary>Gets the LastError value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される LastError 値を取得します。</summary>
    string? LastError { get; }
}




