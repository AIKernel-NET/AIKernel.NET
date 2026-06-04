namespace AIKernel.Dtos.Tokenization;

/// <summary>
/// PaddingInfo の契約を定義します。
/// </summary>
public sealed class PaddingInfo
{
    public required int LogicalTokenCount { get; init; }
    public required int PhysicalCardinality { get; init; }
    public required int PaddingAmount { get; init; }
    public required float PaddingPercentage { get; init; }
    public string? PaddingMethod { get; init; }
    public long MemoryDifferenceBytes { get; init; }
    public string? Rationale { get; init; }
}




