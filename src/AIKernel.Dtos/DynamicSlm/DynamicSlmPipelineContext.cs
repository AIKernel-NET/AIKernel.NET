namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPipelineContext(
    DynamicSlmModelAbi ModelAbi,
    DynamicSlmResolvedSubgraph? ResolvedSubgraph,
    DynamicSlmCompatibilityResult? Compatibility,
    DynamicSlmAdmissionResult? LineageAdmission,
    IReadOnlyList<DynamicSlmCapabilityGap> CapabilityGaps,
    DynamicSlmCapabilityGraphUpdatePlan? GraphUpdatePlan,
    DynamicSlmDistillationPlan? DistillationPlan,
    DynamicSlmPlacementPlan? PlacementPlan,
    DynamicSlmAdmissionResult? Admission,
    IReadOnlyList<DynamicSlmLoadedPayload> LoadedPayloads,
    DynamicSlmPipelineMetadata Metadata,
    IReadOnlyList<DynamicSlmPipelineTrace> Trace);
