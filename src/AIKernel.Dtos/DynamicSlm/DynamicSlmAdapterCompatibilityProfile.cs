using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmAdapterCompatibilityProfile を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmAdapterCompatibilityProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmAdapterCompatibilityProfile']" />
public sealed record DynamicSlmAdapterCompatibilityProfile(
    string BaseModelId,
    DynamicSlmBaseModelStateKind BaseModelState,
    IReadOnlyList<DynamicSlmPayloadKind> CompatiblePayloadKinds,
    IReadOnlyList<string> CompatibleAdapterFamilies,
    string? MaxVectorShiftNorm,
    IReadOnlyDictionary<string, string> Metadata);
