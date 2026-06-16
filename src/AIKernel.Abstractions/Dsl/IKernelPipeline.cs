namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;

/// <summary>EN: Documentation for public API. JA: IKernelPipeline contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IKernelPipeline']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IKernelPipeline']" />
public interface IKernelPipeline
{
    /// <summary>EN: Executes the ExecuteAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExecuteAsync 操作を実行します。</summary>
    Task<DslPipelineExecutionResult> ExecuteAsync(
        DslPipelineExecutionContext context,
        CancellationToken cancellationToken = default);
}
