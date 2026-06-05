namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Abstractions.Models;
using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmScheduler
{
    ValueTask<DynamicSlmPlacementPlan> PlanPlacementAsync(
        DynamicSlmResolvedSubgraph subgraph,
        IExecutionConstraints executionConstraints,
        CancellationToken cancellationToken = default);
}
