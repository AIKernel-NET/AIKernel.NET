using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPlacementPlan(
    string PlanId,
    IReadOnlyDictionary<string, DynamicSlmAcceleratorKind> CapabilityPlacements,
    IReadOnlyList<string> PrefetchPayloadIds,
    IReadOnlyDictionary<string, string> Metadata);
