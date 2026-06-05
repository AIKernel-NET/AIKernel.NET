namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPipelineResult<TValue>(
    bool IsSuccess,
    TValue? Value,
    DynamicSlmFailureContext? Failure,
    IReadOnlyList<DynamicSlmPipelineTrace> Trace,
    DynamicSlmPipelineMetadata Metadata);
