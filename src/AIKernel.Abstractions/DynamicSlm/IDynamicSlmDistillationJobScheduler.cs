namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmDistillationJobScheduler']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmDistillationJobScheduler']" />
public interface IDynamicSlmDistillationJobScheduler
{
    /// <summary>Executes the ScheduleAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ScheduleAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmDistillationJobDescriptor> ScheduleAsync(
        DynamicSlmDistillationOffloadRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the GetStatusAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetStatusAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmDistillationJobDescriptor?> GetStatusAsync(
        DynamicSlmDistillationJobId jobId,
        CancellationToken cancellationToken = default);
}
