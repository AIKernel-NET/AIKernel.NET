namespace AIKernel.Abstractions;

public sealed class PaddingInfo
{
    public required int LogicalTokenCount { get; init; }
    public required int PhysicalCardinality { get; init; }
    public int PaddingAmount => PhysicalCardinality - LogicalTokenCount;
    public float PaddingPercentage => LogicalTokenCount > 0
        ? (PaddingAmount * 100.0f) / LogicalTokenCount
        : 0.0f;
    public string? PaddingMethod { get; init; }
    public long MemoryDifferenceBytes { get; init; }
    public string? Rationale { get; init; }
}
