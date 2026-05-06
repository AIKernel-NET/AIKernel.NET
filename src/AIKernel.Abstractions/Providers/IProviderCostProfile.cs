namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderCostProfile の契約を定義します。
/// </summary>
public interface IProviderCostProfile
{
    string ProviderId { get; }
    string ModelClass { get; }
    decimal InputTokenUnitCost { get; }
    decimal OutputTokenUnitCost { get; }
    decimal ComputeMinuteCost { get; }
    decimal StorageUnitCost { get; }
    DateTimeOffset EffectiveFromUtc { get; }
}




