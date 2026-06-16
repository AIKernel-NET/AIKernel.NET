namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// EN: UC-29 に基づく ITask の契約を定義します。
/// EN: Documentation for public API. JA: ITask の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITask']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITask']" />
public interface ITask
{
    /// <summary>EN: Gets the TaskId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TaskId 値を取得します。</summary>
    string TaskId { get; }
    /// <summary>EN: Gets the Name value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Name 値を取得します。</summary>
    string Name { get; }
    /// <summary>EN: Gets the Description value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Description 値を取得します。</summary>
    string? Description { get; }
    /// <summary>EN: Gets the TaskType value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TaskType 値を取得します。</summary>
    TaskType TaskType { get; }
    /// <summary>EN: Executes the ExecuteAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExecuteAsync 操作を実行します。</summary>
    Task<string?> ExecuteAsync(ITaskContext context, CancellationToken cancellationToken = default);
    /// <summary>EN: Executes the GetInputSchema operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetInputSchema 操作を実行します。</summary>
    IReadOnlyDictionary<string, string>? GetInputSchema();
    /// <summary>EN: Executes the GetOutputSchema operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetOutputSchema 操作を実行します。</summary>
    IReadOnlyDictionary<string, string>? GetOutputSchema();
    /// <summary>EN: Executes the CanExecute operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CanExecute 操作を実行します。</summary>
    bool CanExecute(ITaskContext context);
}




