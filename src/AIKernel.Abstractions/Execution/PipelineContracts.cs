namespace AIKernel.Abstractions.Execution;

/// <summary>
/// EN: IPipelineStep の契約を定義します。
/// EN: Documentation for public API. JA: IPipelineStep の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPipelineStep']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPipelineStep']" />
public interface IPipelineStep
{
    /// <summary>EN: Gets the StepId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される StepId 値を取得します。</summary>
    string StepId { get; }
    /// <summary>EN: Gets the DependsOn value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される DependsOn 値を取得します。</summary>
    IReadOnlyList<string> DependsOn { get; }
    /// <summary>EN: Executes the ExecuteAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExecuteAsync 操作を実行します。</summary>
    Task<AIKernel.Dtos.Execution.ExecutionResult> ExecuteAsync(Hosting.IKernelContext context, CancellationToken ct = default);
}




