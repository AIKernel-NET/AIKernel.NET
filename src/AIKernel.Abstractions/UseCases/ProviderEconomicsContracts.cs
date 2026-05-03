namespace AIKernel.Abstractions;

public interface IProviderCreditInfo
{
    string ProviderId { get; }
    string CurrencyCode { get; }
    decimal CurrentBalance { get; }
    decimal ReservedBalance { get; }
    decimal HardLimit { get; }
    decimal SoftLimit { get; }
    DateTimeOffset LastUpdatedUtc { get; }
}

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

public interface IProviderUsageStats
{
    string ProviderId { get; }
    DateTimeOffset WindowStartUtc { get; }
    DateTimeOffset WindowEndUtc { get; }
    long RequestsCount { get; }
    long InputTokens { get; }
    long OutputTokens { get; }
    double AvgLatencyMs { get; }
    double RateLimitUtilization { get; }
}

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
