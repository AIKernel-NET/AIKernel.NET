namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmArtifactPublisher']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmArtifactPublisher']" />
public interface IDynamicSlmArtifactPublisher
{
    /// <summary>Executes the PublishAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PublishAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmAdmissionResult> PublishAsync(
        DynamicSlmModelAbi modelAbi,
        DynamicSlmDistillationPlan distillationPlan,
        CancellationToken cancellationToken = default);
}
