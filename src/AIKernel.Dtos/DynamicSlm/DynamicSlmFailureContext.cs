using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmFailureContext(
    DynamicSlmFailureKind Kind,
    DynamicSlmPipelineStage Stage,
    string Code,
    string Message,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
