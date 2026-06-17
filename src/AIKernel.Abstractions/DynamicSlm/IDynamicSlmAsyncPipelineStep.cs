namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] IDynamicSlmAsyncPipelineStep contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmAsyncPipelineStep']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmAsyncPipelineStep']" />
public interface IDynamicSlmAsyncPipelineStep<TInput, TOutput>
{
    /// <summary>EN: Gets the Stage value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Stage 値を取得します。</summary>
    DynamicSlmPipelineStage Stage { get; }

    /// <summary>EN: Executes the ExecuteAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExecuteAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmPipelineResult<TOutput>> ExecuteAsync(
        TInput input,
        CancellationToken cancellationToken = default);
}
