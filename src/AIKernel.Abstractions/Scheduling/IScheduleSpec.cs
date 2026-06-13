namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく IScheduleSpec の契約を定義します。
/// JA: IScheduleSpec の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduleSpec']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduleSpec']" />
public interface IScheduleSpec
{
    /// <summary>Gets the JobId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される JobId 値を取得します。</summary>
    string JobId { get; }
    /// <summary>Gets the Description value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Description 値を取得します。</summary>
    string Description { get; }
    /// <summary>Gets the WorkId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される WorkId 値を取得します。</summary>
    string WorkId { get; }
    /// <summary>Gets the CronExpression value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CronExpression 値を取得します。</summary>
    string? CronExpression { get; }
    /// <summary>Gets the TimeoutMs value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TimeoutMs 値を取得します。</summary>
    int? TimeoutMs { get; }
    /// <summary>Gets the MaxRetries value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される MaxRetries 値を取得します。</summary>
    int MaxRetries { get; }
}




