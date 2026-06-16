using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmPipelineResult&lt;TValue&gt; を表します。</summary>
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
