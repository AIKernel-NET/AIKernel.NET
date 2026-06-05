using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmMemoryPlacementMetadata(
    DynamicSlmResidentModelDescriptor ResidentModel,
    IReadOnlyList<DynamicSlmCapabilitySwapDescriptor> CapabilitySwaps,
    DynamicSlmHotSwapPolicy HotSwapPolicy,
    IReadOnlyDictionary<string, string> Metadata);
