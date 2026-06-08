using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDelegationMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDelegationMetadata']" />
public sealed record DynamicSlmDelegationMetadata(
    string DelegationId,
    DynamicSlmDelegationKind Kind,
    DynamicSlmDelegationReason Reason,
    bool FailClosed,
    string? TargetId,
    IReadOnlyDictionary<string, string> Metadata);
