using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmMemoryPlacementMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmMemoryPlacementMetadata']" />
public sealed record DynamicSlmMemoryPlacementMetadata(
    DynamicSlmResidentModelDescriptor ResidentModel,
    IReadOnlyList<DynamicSlmCapabilitySwapDescriptor> CapabilitySwaps,
    DynamicSlmHotSwapPolicy HotSwapPolicy,
    IReadOnlyDictionary<string, string> Metadata);
