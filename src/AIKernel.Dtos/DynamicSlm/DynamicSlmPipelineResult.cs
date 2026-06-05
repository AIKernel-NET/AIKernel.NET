using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPipelineResult<TValue>(
    DynamicSlmPipelineStatus Status,
    bool IsSuccess,
    TValue? Value,
    DynamicSlmFailureContext? Failure,
    DynamicSlmPipelineOffloadInfo? Offload,
    IReadOnlyList<DynamicSlmPipelineTrace> Trace,
    DynamicSlmPipelineMetadata Metadata);
