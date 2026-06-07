using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineResult']" />
public sealed record DynamicSlmPipelineResult<TValue>(
    DynamicSlmPipelineStatus Status,
    bool IsSuccess,
    TValue? Value,
    DynamicSlmFailureContext? Failure,
    DynamicSlmPipelineOffloadInfo? Offload,
    IReadOnlyList<DynamicSlmPipelineTrace> Trace,
    DynamicSlmPipelineMetadata Metadata);
