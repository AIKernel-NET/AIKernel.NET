using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmCapabilitySwapDescriptor を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilitySwapDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilitySwapDescriptor']" />
public sealed record DynamicSlmCapabilitySwapDescriptor(
    string CapabilityId,
    string PayloadId,
    DynamicSlmHotSwapPolicy Policy,
    string? VirtualAddressHint,
    long EstimatedBytes,
    IReadOnlyDictionary<string, string> Metadata);
