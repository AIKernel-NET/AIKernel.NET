using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmDelegationRequest を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDelegationRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDelegationRequest']" />
public sealed record DynamicSlmDelegationRequest(
    string DelegationId,
    DynamicSlmDelegationKind Kind,
    DynamicSlmDelegationReason Reason,
    string SourceCapabilityId,
    string? TargetId,
    string? ReplayLogHash,
    string? ThoughtArtifactId,
    IReadOnlyDictionary<string, string> Metadata);
