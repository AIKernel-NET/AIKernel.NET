namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmDistillationJobScheduler
{
    ValueTask<DynamicSlmDistillationJobDescriptor> ScheduleAsync(
        DynamicSlmDistillationOffloadRequest request,
        CancellationToken cancellationToken = default);

    ValueTask<DynamicSlmDistillationJobDescriptor?> GetStatusAsync(
        DynamicSlmDistillationJobId jobId,
        CancellationToken cancellationToken = default);
}
