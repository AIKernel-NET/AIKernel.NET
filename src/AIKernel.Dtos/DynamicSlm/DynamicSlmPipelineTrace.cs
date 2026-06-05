using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPipelineTrace(
    DynamicSlmPipelineStage Stage,
    string StepId,
    string? ParentStepId,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
