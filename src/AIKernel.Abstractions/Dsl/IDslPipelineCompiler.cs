namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;

/// <summary>EN: Documentation for public API. JA: IDslPipelineCompiler contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IDslPipelineCompiler']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IDslPipelineCompiler']" />
public interface IDslPipelineCompiler
{
    /// <summary>EN: Executes the CompileAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CompileAsync 操作を実行します。</summary>
    Task<IKernelPipeline> CompileAsync(
        DslDocument document,
        CancellationToken cancellationToken = default);
}
