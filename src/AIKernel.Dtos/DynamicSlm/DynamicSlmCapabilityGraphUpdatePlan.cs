using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmCapabilityGraphUpdate を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityGraphUpdate']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityGraphUpdate']" />
public sealed record DynamicSlmCapabilityGraphUpdate(
    DynamicSlmGraphUpdateKind Kind,
    DynamicSlmCapabilityNode? Node,
    DynamicSlmCapabilityEdge? Edge,
    string? TargetCapabilityId,
    IReadOnlyDictionary<string, string> Metadata);

/// <summary>EN: Documentation for public API. JA: DynamicSlmCapabilityGraphUpdatePlan を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityGraphUpdatePlan']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityGraphUpdatePlan']" />
public sealed record DynamicSlmCapabilityGraphUpdatePlan(
    string PlanId,
    string ModelId,
    IReadOnlyList<DynamicSlmCapabilityGap> SourceGaps,
    IReadOnlyList<DynamicSlmCapabilityGraphUpdate> Updates,
    IReadOnlyDictionary<string, string> GovernanceMetadata);
