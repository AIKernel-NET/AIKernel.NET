namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// EN: UC-29 に基づく ITaskContext の契約を定義します。
/// [EN] Documents this public package API member. [JA] ITaskContext の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskContext']" />
public interface ITaskContext
{
    /// <summary>EN: Gets the ExecutionId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutionId 値を取得します。</summary>
    string ExecutionId { get; }
    /// <summary>EN: Gets the PipelineId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PipelineId 値を取得します。</summary>
    string PipelineId { get; }
    /// <summary>EN: Gets the ContextContract value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ContextContract 値を取得します。</summary>
    UnifiedContextDto? ContextContract { get; }
    /// <summary>EN: Executes the GetInputParameters operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetInputParameters 操作を実行します。</summary>
    IReadOnlyDictionary<string, string?> GetInputParameters();
    /// <summary>EN: Executes the SetInputParameter operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SetInputParameter 操作を実行します。</summary>
    void SetInputParameter(string key, string? value);
    /// <summary>EN: Executes the GetDependencyOutput operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetDependencyOutput 操作を実行します。</summary>
    ITaskExecutionResult? GetDependencyOutput(string taskId);
    /// <summary>EN: Executes the GetVariable operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetVariable 操作を実行します。</summary>
    string? GetVariable(string key);
    /// <summary>EN: Executes the SetVariable operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SetVariable 操作を実行します。</summary>
    void SetVariable(string key, string? value);
    /// <summary>EN: Gets the ExecutionTime value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutionTime 値を取得します。</summary>
    DateTime ExecutionTime { get; }
    /// <summary>EN: Gets the TimeoutMs value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TimeoutMs 値を取得します。</summary>
    int? TimeoutMs { get; }
}




