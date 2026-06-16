namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: IDynamicSlmArtifactPublisher contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmArtifactPublisher']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmArtifactPublisher']" />
public interface IDynamicSlmArtifactPublisher
{
    /// <summary>EN: Executes the PublishAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PublishAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmAdmissionResult> PublishAsync(
        DynamicSlmModelAbi modelAbi,
        DynamicSlmDistillationPlan distillationPlan,
        CancellationToken cancellationToken = default);
}
