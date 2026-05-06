namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderResourceProfile の契約を定義します。
/// </summary>
public interface IProviderResourceProfile
{
    string ProviderId { get; }
    IProviderCreditInfo CreditInfo { get; }
    IProviderCostProfile CostProfile { get; }
    IProviderUsageStats UsageStats { get; }
    IProviderBillingInfo BillingInfo { get; }
    double HealthScore { get; }
    DateTimeOffset UpdatedAtUtc { get; }
}




