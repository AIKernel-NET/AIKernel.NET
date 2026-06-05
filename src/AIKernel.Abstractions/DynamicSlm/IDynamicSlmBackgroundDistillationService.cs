namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmBackgroundDistillationService
{
    ValueTask<DynamicSlmDistillationJobDescriptor> EnqueueAsync(
        DynamicSlmDistillationOffloadRequest request,
        CancellationToken cancellationToken = default);

    ValueTask<DynamicSlmDistillationJobDescriptor?> ReadJobAsync(
        DynamicSlmDistillationJobId jobId,
        CancellationToken cancellationToken = default);
}
