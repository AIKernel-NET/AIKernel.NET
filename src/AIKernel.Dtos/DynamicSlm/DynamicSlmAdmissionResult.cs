using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmAdmissionResult を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmAdmissionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmAdmissionResult']" />
public sealed record DynamicSlmAdmissionResult(
    DynamicSlmAdmissionStatus Status,
    string ArtifactHash,
    string? Reason,
    IReadOnlyDictionary<string, string> Metadata);
