using AIKernel.Dtos.Routing;
using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmExecutionProfile(
    long RequiredMemoryBytes,
    int ExpectedLatencyMs,
    ComputeShape? PreferredComputeShape,
    IReadOnlyList<DynamicSlmAcceleratorKind> SupportedAccelerators,
    string Quantization,
    bool SupportsPrefetch,
    bool SupportsHotSwap);
