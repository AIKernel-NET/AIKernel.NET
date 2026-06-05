using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmReplayLogEntry(
    string EntryId,
    string? ParentEntryId,
    DynamicSlmPipelineStage Stage,
    string? ThoughtArtifactId,
    string SemanticDeltaHash,
    string ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
