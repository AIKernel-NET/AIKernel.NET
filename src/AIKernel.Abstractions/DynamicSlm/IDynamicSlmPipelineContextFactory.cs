namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] IDynamicSlmPipelineContextFactory contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmPipelineContextFactory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmPipelineContextFactory']" />
public interface IDynamicSlmPipelineContextFactory
{
    /// <summary>EN: Executes the Create operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Create 操作を実行します。</summary>
    DynamicSlmPipelineContext Create(
        DynamicSlmModelAbi modelAbi,
        DynamicSlmPipelineMetadata metadata);
}
