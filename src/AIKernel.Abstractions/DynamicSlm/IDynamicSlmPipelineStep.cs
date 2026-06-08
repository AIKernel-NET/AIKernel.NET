namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Enums;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmPipelineStep']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmPipelineStep']" />
public interface IDynamicSlmPipelineStep<TInput, TOutput>
{
    /// <summary>Gets the Stage value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Stage 値を取得します。</summary>
    DynamicSlmPipelineStage Stage { get; }

    /// <summary>Executes the Execute operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Execute 操作を実行します。</summary>
    DynamicSlmPipelineResult<TOutput> Execute(TInput input);
}
