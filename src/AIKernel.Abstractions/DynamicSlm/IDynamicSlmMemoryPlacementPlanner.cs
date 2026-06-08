namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmMemoryPlacementPlanner']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmMemoryPlacementPlanner']" />
public interface IDynamicSlmMemoryPlacementPlanner
{
    /// <summary>Executes the PlanMemoryPlacementAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PlanMemoryPlacementAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmMemoryPlacementMetadata> PlanMemoryPlacementAsync(
        DynamicSlmResidentModelDescriptor residentModel,
        IReadOnlyList<DynamicSlmCapabilitySwapDescriptor> capabilitySwaps,
        DynamicSlmPlacementPlan placementPlan,
        CancellationToken cancellationToken = default);
}
