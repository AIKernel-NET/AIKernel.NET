namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmPipelineBuilder']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmPipelineBuilder']" />
public interface IDynamicSlmPipelineBuilder
{
    /// <summary>Executes the AddStep&lt;TInput, TOutput&gt; operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで AddStep&lt;TInput, TOutput&gt; 操作を実行します。</summary>
    IDynamicSlmPipelineBuilder AddStep<TInput, TOutput>(
        IDynamicSlmAsyncPipelineStep<TInput, TOutput> step);

    /// <summary>Executes the Build operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Build 操作を実行します。</summary>
    IDynamicSlmAsyncPipeline Build(
        DynamicSlmPipelineMetadata metadata);
}
