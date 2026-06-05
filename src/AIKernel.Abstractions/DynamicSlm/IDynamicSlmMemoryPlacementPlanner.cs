namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmMemoryPlacementPlanner
{
    ValueTask<DynamicSlmMemoryPlacementMetadata> PlanMemoryPlacementAsync(
        DynamicSlmResidentModelDescriptor residentModel,
        IReadOnlyList<DynamicSlmCapabilitySwapDescriptor> capabilitySwaps,
        DynamicSlmPlacementPlan placementPlan,
        CancellationToken cancellationToken = default);
}
