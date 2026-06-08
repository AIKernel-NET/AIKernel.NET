using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCompatibilityResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCompatibilityResult']" />
public sealed record DynamicSlmCompatibilityResult(
    DynamicSlmCompatibilityStatus Status,
    string ModelId,
    IReadOnlyList<string> CapabilityIds,
    string? Reason,
    IReadOnlyDictionary<string, string> Metadata);
