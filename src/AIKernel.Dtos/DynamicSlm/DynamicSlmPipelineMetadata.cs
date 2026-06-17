using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmPipelineMetadata を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineMetadata']" />
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
    /// <summary>[EN] Documents this public package API member. [JA] DynamicSlmPipelineMetadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineMetadata.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineMetadata.#ctor']" />
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
