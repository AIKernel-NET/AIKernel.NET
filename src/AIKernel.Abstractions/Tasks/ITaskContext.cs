namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく ITaskContext の契約を定義します。
/// JA: ITaskContext の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskContext']" />
public interface ITaskContext
{
    /// <summary>Gets the ExecutionId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutionId 値を取得します。</summary>
    string ExecutionId { get; }
    /// <summary>Gets the PipelineId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PipelineId 値を取得します。</summary>
    string PipelineId { get; }
    /// <summary>Gets the ContextContract value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ContextContract 値を取得します。</summary>
    UnifiedContextDto? ContextContract { get; }
    /// <summary>Executes the GetInputParameters operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetInputParameters 操作を実行します。</summary>
    IReadOnlyDictionary<string, string?> GetInputParameters();
    /// <summary>Executes the SetInputParameter operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SetInputParameter 操作を実行します。</summary>
    void SetInputParameter(string key, string? value);
    /// <summary>Executes the GetDependencyOutput operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetDependencyOutput 操作を実行します。</summary>
    ITaskExecutionResult? GetDependencyOutput(string taskId);
    /// <summary>Executes the GetVariable operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetVariable 操作を実行します。</summary>
    string? GetVariable(string key);
    /// <summary>Executes the SetVariable operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SetVariable 操作を実行します。</summary>
    void SetVariable(string key, string? value);
    /// <summary>Gets the ExecutionTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutionTime 値を取得します。</summary>
    DateTime ExecutionTime { get; }
    /// <summary>Gets the TimeoutMs value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TimeoutMs 値を取得します。</summary>
    int? TimeoutMs { get; }
}




