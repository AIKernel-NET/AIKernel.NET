namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderBillingInfo の契約を定義します。
/// </summary>
public interface IProviderBillingInfo
{
    string ProviderId { get; }
    string BillingAccountId { get; }
    string BillingCycle { get; }
    DateTimeOffset CycleStartUtc { get; }
    DateTimeOffset CycleEndUtc { get; }
    decimal AccumulatedCost { get; }
    decimal ForecastCost { get; }
    string PaymentStatus { get; }
}




