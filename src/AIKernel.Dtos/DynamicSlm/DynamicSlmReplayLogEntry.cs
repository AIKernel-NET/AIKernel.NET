using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmReplayLogEntry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmReplayLogEntry']" />
public sealed record DynamicSlmReplayLogEntry(
    string EntryId,
    string? ParentEntryId,
    DynamicSlmPipelineStage Stage,
    string? ThoughtArtifactId,
    string SemanticDeltaHash,
    string ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
