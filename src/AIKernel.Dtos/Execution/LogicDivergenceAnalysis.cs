namespace AIKernel.Dtos.Execution;

/// <summary>
/// LogicDivergenceAnalysis の契約を定義します。
/// </summary>
public sealed record LogicDivergenceAnalysis
{
    public required bool DivergenceDetected { get; init; }
    public required string DivergenceType { get; init; }
    public required string Description { get; init; }
    public required string Severity { get; init; }
    public IReadOnlyList<string> AlteredSegments { get; init; } = new List<string>();
}




