namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// UC-28 に基づく scheduled execution result の契約を定義します。
/// JA: IScheduledExecutionResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledExecutionResult']" />
public interface IScheduledExecutionResult
{
    /// <summary>Gets the ExecutionId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutionId 値を取得します。</summary>
    string ExecutionId { get; }
    /// <summary>Gets the JobId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される JobId 値を取得します。</summary>
    string JobId { get; }
    /// <summary>Gets the StartTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される StartTime 値を取得します。</summary>
    DateTime StartTime { get; }
    /// <summary>Gets the EndTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される EndTime 値を取得します。</summary>
    DateTime? EndTime { get; }
    /// <summary>Gets the Success value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Success 値を取得します。</summary>
    bool Success { get; }
    /// <summary>Gets the Error value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Error 値を取得します。</summary>
    string? Error { get; }
    /// <summary>Gets the Log value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Log 値を取得します。</summary>
    string? Log { get; }
}




