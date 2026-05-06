namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderUsageStats の契約を定義します。
/// </summary>
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




