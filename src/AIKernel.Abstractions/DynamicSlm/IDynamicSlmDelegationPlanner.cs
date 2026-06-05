namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmDelegationPlanner
{
    ValueTask<DynamicSlmDelegationRequest> PlanDelegationAsync(
        DynamicSlmCapabilityGap gap,
        DynamicSlmPipelineContext context,
        CancellationToken cancellationToken = default);
}
