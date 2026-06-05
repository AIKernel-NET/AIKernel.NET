using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmCapabilityGraphUpdate(
    DynamicSlmGraphUpdateKind Kind,
    DynamicSlmCapabilityNode? Node,
    DynamicSlmCapabilityEdge? Edge,
    string? TargetCapabilityId,
    IReadOnlyDictionary<string, string> Metadata);

public sealed record DynamicSlmCapabilityGraphUpdatePlan(
    string PlanId,
    string ModelId,
    IReadOnlyList<DynamicSlmCapabilityGap> SourceGaps,
    IReadOnlyList<DynamicSlmCapabilityGraphUpdate> Updates,
    IReadOnlyDictionary<string, string> GovernanceMetadata);
