using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmThoughtArtifact(
    string ArtifactId,
    DynamicSlmReasoningTraceFormat Format,
    string Intent,
    IReadOnlyList<string> IntermediateSteps,
    IReadOnlyList<string> Decisions,
    string? OutputHash,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
