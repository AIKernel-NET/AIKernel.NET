namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// EN: UC-29 に基づく IPipelineExecutionResult の契約を定義します。
/// EN: Documentation for public API. JA: IPipelineExecutionResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipelineExecutionResult']" />
public interface IPipelineExecutionResult
{
    /// <summary>EN: Gets the ExecutionId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutionId 値を取得します。</summary>
    string ExecutionId { get; }
    /// <summary>EN: Gets the PipelineId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PipelineId 値を取得します。</summary>
    string PipelineId { get; }
    /// <summary>EN: Gets the StartTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される StartTime 値を取得します。</summary>
    DateTime StartTime { get; }
    /// <summary>EN: Gets the EndTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される EndTime 値を取得します。</summary>
    DateTime? EndTime { get; }
    /// <summary>EN: Gets the Success value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Success 値を取得します。</summary>
    bool Success { get; }
    /// <summary>EN: Gets the FinalOutput value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FinalOutput 値を取得します。</summary>
    string? FinalOutput { get; }
    /// <summary>EN: Gets the TaskResults value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TaskResults 値を取得します。</summary>
    IReadOnlyDictionary<string, ITaskExecutionResult> TaskResults { get; }
    /// <summary>EN: Gets the Error value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Error 値を取得します。</summary>
    string? Error { get; }
    /// <summary>EN: Gets the ExecutionLog value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutionLog 値を取得します。</summary>
    string? ExecutionLog { get; }
}




