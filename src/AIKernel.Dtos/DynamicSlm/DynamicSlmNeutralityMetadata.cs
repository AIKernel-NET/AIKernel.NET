using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmNeutralityMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmNeutralityMetadata']" />
public sealed record DynamicSlmNeutralityMetadata(
    DynamicSlmBaseModelStateKind BaseModelState,
    bool IsNeutralNullState,
    string? NeutralityScore,
    IReadOnlyDictionary<string, string> Metadata);
