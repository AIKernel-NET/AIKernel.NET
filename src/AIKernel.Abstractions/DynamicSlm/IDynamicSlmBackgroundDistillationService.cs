namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] IDynamicSlmBackgroundDistillationService contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmBackgroundDistillationService']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmBackgroundDistillationService']" />
public interface IDynamicSlmBackgroundDistillationService
{
    /// <summary>EN: Executes the EnqueueAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで EnqueueAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmDistillationJobDescriptor> EnqueueAsync(
        DynamicSlmDistillationOffloadRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the ReadJobAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ReadJobAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmDistillationJobDescriptor?> ReadJobAsync(
        DynamicSlmDistillationJobId jobId,
        CancellationToken cancellationToken = default);
}
