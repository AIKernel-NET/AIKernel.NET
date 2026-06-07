namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmBackgroundDistillationService']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmBackgroundDistillationService']" />
public interface IDynamicSlmBackgroundDistillationService
{
    /// <summary>Executes the EnqueueAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで EnqueueAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmDistillationJobDescriptor> EnqueueAsync(
        DynamicSlmDistillationOffloadRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the ReadJobAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ReadJobAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmDistillationJobDescriptor?> ReadJobAsync(
        DynamicSlmDistillationJobId jobId,
        CancellationToken cancellationToken = default);
}
