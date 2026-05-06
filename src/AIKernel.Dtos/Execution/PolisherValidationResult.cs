namespace AIKernel.Dtos.Execution;

/// <summary>
/// PolisherValidationResult の契約を定義します。
/// </summary>
public sealed record PolisherValidationResult
{
    public required bool IsValid { get; init; }
    public required string Message { get; init; }
    public IReadOnlyList<string> Violations { get; init; } = new List<string>();
    public double LogicIntegrityScore { get; init; }
}




