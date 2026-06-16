namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmPipelineContext を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineContext']" />
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
    IReadOnlyList<DynamicSlmPipelineTrace> Trace)
{
    /// <summary>EN: Documentation for public API. JA: DynamicSlmPipelineContext を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineContext.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineContext.#ctor']" />
    public DynamicSlmPipelineContext(
        DynamicSlmModelAbi modelAbi,
        DynamicSlmResolvedSubgraph? resolvedSubgraph,
        DynamicSlmCompatibilityResult? compatibility,
        DynamicSlmAdmissionResult? lineageAdmission,
        IReadOnlyList<DynamicSlmCapabilityGap> capabilityGaps,
        DynamicSlmCapabilityGraphUpdatePlan? graphUpdatePlan,
        DynamicSlmDistillationPlan? distillationPlan,
        DynamicSlmDistillationJobDescriptor? distillationJob,
        DynamicSlmFallbackStrategy? fallbackStrategy,
        DynamicSlmPlacementPlan? placementPlan,
        DynamicSlmAdmissionResult? admission,
        IReadOnlyList<DynamicSlmLoadedPayload> loadedPayloads,
        DynamicSlmPipelineMetadata metadata,
        IReadOnlyList<DynamicSlmPipelineTrace> trace)
        : this(
            modelAbi,
            resolvedSubgraph,
            compatibility,
            lineageAdmission,
            capabilityGaps,
            graphUpdatePlan,
            distillationPlan,
            distillationJob,
            fallbackStrategy,
            null,
            Array.Empty<DynamicSlmThoughtArtifact>(),
            null,
            placementPlan,
            admission,
            loadedPayloads,
            metadata,
            trace)
    {
    }
}
