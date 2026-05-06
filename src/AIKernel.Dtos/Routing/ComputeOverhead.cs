namespace AIKernel.Dtos.Routing;

/// <summary>
/// ComputeOverhead の契約を定義します。
/// </summary>
public sealed record ComputeOverhead(
    long MemoryOverheadMb,
    long AdditionalFlops,
    float LatencyOverheadMs);



