namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPipelineContext(
    DynamicSlmModelAbi ModelAbi,
    DynamicSlmResolvedSubgraph? ResolvedSubgraph,
    DynamicSlmCompatibilityResult? Compatibility,
    DynamicSlmAdmissionResult? LineageAdmission,
    IReadOnlyList<DynamicSlmCapabilityGap> CapabilityGaps,
    DynamicSlmCapabilityGraphUpdatePlan? GraphUpdatePlan,
    DynamicSlmDistillationPlan? DistillationPlan,
    DynamicSlmDistillationJobDescriptor? DistillationJob,
    DynamicSlmFallbackStrategy? FallbackStrategy,
    DynamicSlmDelegationRequest? DelegationRequest,
    IReadOnlyList<DynamicSlmThoughtArtifact> ThoughtArtifacts,
    DynamicSlmMemoryPlacementMetadata? MemoryPlacement,
    DynamicSlmPlacementPlan? PlacementPlan,
    DynamicSlmAdmissionResult? Admission,
    IReadOnlyList<DynamicSlmLoadedPayload> LoadedPayloads,
    DynamicSlmPipelineMetadata Metadata,
    IReadOnlyList<DynamicSlmPipelineTrace> Trace);
