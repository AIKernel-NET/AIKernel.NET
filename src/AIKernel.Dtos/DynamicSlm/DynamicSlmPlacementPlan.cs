using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmPlacementPlan を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPlacementPlan']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPlacementPlan']" />
public sealed record DynamicSlmPlacementPlan(
    string PlanId,
    IReadOnlyDictionary<string, DynamicSlmAcceleratorKind> CapabilityPlacements,
    IReadOnlyList<string> PrefetchPayloadIds,
    IReadOnlyDictionary<string, string> Metadata);
