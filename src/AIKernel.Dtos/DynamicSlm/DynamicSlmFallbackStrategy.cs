using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmFallbackStrategy を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmFallbackStrategy']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmFallbackStrategy']" />
public sealed record DynamicSlmFallbackStrategy(
    DynamicSlmFallbackKind Kind,
    string? TargetProviderId,
    string? TeacherModelId,
    string Reason,
    IReadOnlyDictionary<string, string> Metadata);
