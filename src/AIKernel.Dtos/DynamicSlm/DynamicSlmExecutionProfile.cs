using AIKernel.Dtos.Routing;
using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmExecutionProfile を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmExecutionProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmExecutionProfile']" />
public sealed record DynamicSlmExecutionProfile(
    long RequiredMemoryBytes,
    int ExpectedLatencyMs,
    ComputeShape? PreferredComputeShape,
    IReadOnlyList<DynamicSlmAcceleratorKind> SupportedAccelerators,
    string Quantization,
    bool SupportsPrefetch,
    bool SupportsHotSwap);
