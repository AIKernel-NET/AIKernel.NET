namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmCapabilityGap を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityGap']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityGap']" />
public sealed record DynamicSlmCapabilityGap(
    string GapId,
    string CapabilityId,
    string ObservedFailureCode,
    string ReplayLogHash,
    string? SemanticDeltaHash,
    int EvidenceCount,
    IReadOnlyDictionary<string, string> Metadata);
