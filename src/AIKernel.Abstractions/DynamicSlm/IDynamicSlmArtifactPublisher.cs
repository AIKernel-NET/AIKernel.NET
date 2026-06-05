namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmArtifactPublisher
{
    ValueTask<DynamicSlmAdmissionResult> PublishAsync(
        DynamicSlmModelAbi modelAbi,
        DynamicSlmDistillationPlan distillationPlan,
        CancellationToken cancellationToken = default);
}
