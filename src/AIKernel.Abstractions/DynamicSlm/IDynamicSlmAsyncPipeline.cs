namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: IDynamicSlmAsyncPipeline contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmAsyncPipeline']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmAsyncPipeline']" />
public interface IDynamicSlmAsyncPipeline
{
    /// <summary>EN: Executes the ExecuteAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExecuteAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmPipelineResult<DynamicSlmPipelineContext>> ExecuteAsync(
        DynamicSlmPipelineContext context,
        CancellationToken cancellationToken = default);
}
