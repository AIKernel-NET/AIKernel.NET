namespace AIKernel.Enums;

public enum DynamicSlmPipelineStage
{
    Unknown = 0,
    CompatibilityVerification = 1,
    LineageVerification = 2,
    CapabilityGraphResolution = 3,
    CapabilityGapDetection = 4,
    CapabilityGraphEvolutionPlanning = 5,
    DistillationPlanning = 6,
    PlacementPlanning = 7,
    Admission = 8,
    PayloadLoading = 9,
    SchedulingExecution = 10,
    DistillationOffload = 11,
    FallbackSelection = 12,
    StrictOutputValidation = 13,
    Delegation = 14,
    ThoughtArtifactDump = 15,
    MemoryPlacement = 16
}
