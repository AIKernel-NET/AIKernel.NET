using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmCapabilitySwapDescriptor(
    string CapabilityId,
    string PayloadId,
    DynamicSlmHotSwapPolicy Policy,
    string? VirtualAddressHint,
    long EstimatedBytes,
    IReadOnlyDictionary<string, string> Metadata);
