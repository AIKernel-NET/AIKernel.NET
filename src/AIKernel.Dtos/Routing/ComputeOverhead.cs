namespace AIKernel.Dtos.Routing;

public sealed record ComputeOverhead(
    long MemoryOverheadMb,
    long AdditionalFlops,
    float LatencyOverheadMs);
