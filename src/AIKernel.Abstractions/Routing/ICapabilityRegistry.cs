namespace AIKernel.Abstractions.Routing;

/// <summary>
/// UC-03/UC-22 に基づく ICapabilityRegistry の契約を定義します。
/// </summary>
public interface ICapabilityRegistry
{
    ValueTask RegisterCapabilityAsync(
        string providerId,
        ModelCapacityVector capacityVector,
        CancellationToken cancellationToken = default);

    ValueTask<ModelCapacityVector?> GetCapabilityAsync(
        string providerId,
        CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyList<string>> ResolveCandidatesAsync(
        RuleEvaluationContext context,
        CancellationToken cancellationToken = default);
}


