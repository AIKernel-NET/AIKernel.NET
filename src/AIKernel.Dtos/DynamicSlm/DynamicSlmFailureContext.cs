using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmFailureContext を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmFailureContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmFailureContext']" />
public sealed record DynamicSlmFailureContext(
    DynamicSlmFailureKind Kind,
    DynamicSlmPipelineStage Stage,
    string Code,
    string Message,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
