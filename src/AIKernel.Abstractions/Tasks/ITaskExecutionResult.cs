namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// EN: UC-29 に基づく ITaskExecutionResult の契約を定義します。
/// [EN] Documents this public package API member. [JA] ITaskExecutionResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskExecutionResult']" />
public interface ITaskExecutionResult
{
    /// <summary>EN: Gets the TaskId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TaskId 値を取得します。</summary>
    string TaskId { get; }
    /// <summary>EN: Gets the Success value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Success 値を取得します。</summary>
    bool Success { get; }
    /// <summary>EN: Gets the Output value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Output 値を取得します。</summary>
    string? Output { get; }
    /// <summary>EN: Gets the Error value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Error 値を取得します。</summary>
    string? Error { get; }
    /// <summary>EN: Gets the DurationMs value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される DurationMs 値を取得します。</summary>
    long DurationMs { get; }
    /// <summary>EN: Gets the RetryCount value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RetryCount 値を取得します。</summary>
    int RetryCount { get; }
}




