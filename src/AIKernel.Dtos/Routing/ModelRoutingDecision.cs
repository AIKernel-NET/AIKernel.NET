namespace AIKernel.Dtos.Routing;

/// <summary>
/// ModelRoutingDecision の契約を定義します。
/// </summary>
public sealed record ModelRoutingDecision
{
    public required string SelectedProviderId { get; init; }
    public required string SelectionRationale { get; init; }
    public required ModelCapacityVector EffectiveCapacity { get; init; }
    public required double FittingScore { get; init; }
    public required DateTime DecisionTimestamp { get; init; }
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}



