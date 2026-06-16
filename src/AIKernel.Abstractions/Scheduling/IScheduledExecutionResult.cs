namespace AIKernel.Abstractions.Scheduling;

/// <summary>
/// EN: UC-28 に基づく scheduled execution result の契約を定義します。
/// [EN] Documents this public package API member. [JA] IScheduledExecutionResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Scheduling.IScheduledExecutionResult']" />
public interface IScheduledExecutionResult
{
    /// <summary>EN: Gets the ExecutionId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutionId 値を取得します。</summary>
    string ExecutionId { get; }
    /// <summary>EN: Gets the JobId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される JobId 値を取得します。</summary>
    string JobId { get; }
    /// <summary>EN: Gets the StartTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される StartTime 値を取得します。</summary>
    DateTime StartTime { get; }
    /// <summary>EN: Gets the EndTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される EndTime 値を取得します。</summary>
    DateTime? EndTime { get; }
    /// <summary>EN: Gets the Success value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Success 値を取得します。</summary>
    bool Success { get; }
    /// <summary>EN: Gets the Error value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Error 値を取得します。</summary>
    string? Error { get; }
    /// <summary>EN: Gets the Log value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Log 値を取得します。</summary>
    string? Log { get; }
}




