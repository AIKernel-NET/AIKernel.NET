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
    IReadOnlyDictionary<string, string> Values)
{
    public DynamicSlmPipelineMetadata(
        string pipelineId,
        string? replayLogHash,
        string? modelAbiHash,
        string? capabilityGraphHash,
        string? lineageHash,
        string? placementPlanId,
        DynamicSlmDistillationJobId? distillationJobId,
        bool gapDetected,
        bool teacherFallbackUsed,
        IReadOnlyDictionary<string, string> values)
        : this(
            pipelineId,
            replayLogHash,
            modelAbiHash,
            capabilityGraphHash,
            lineageHash,
            placementPlanId,
            distillationJobId,
            null,
            null,
            null,
            null,
            null,
            gapDetected,
            teacherFallbackUsed,
            values)
    {
    }
}
