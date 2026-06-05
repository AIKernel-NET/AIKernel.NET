using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPipelineMetadata(
    string PipelineId,
    string? ReplayLogHash,
    string? ModelAbiHash,
    string? CapabilityGraphHash,
    string? LineageHash,
    string? PlacementPlanId,
    DynamicSlmDistillationJobId? DistillationJobId,
    string? DelegationId,
    string? ThoughtArtifactId,
    string? TrajectoryId,
    string? MemoryPlacementId,
    DynamicSlmStrictOutputMode? StrictOutputMode,
    bool GapDetected,
    bool TeacherFallbackUsed,
    IReadOnlyDictionary<string, string> Values);
