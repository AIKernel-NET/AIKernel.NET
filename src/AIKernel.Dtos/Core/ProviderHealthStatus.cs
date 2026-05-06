namespace AIKernel.Dtos.Core;

/// <summary>
/// ProviderHealthStatus の契約を定義します。
/// </summary>
public sealed record ProviderHealthStatus(
    bool IsHealthy,
    string? Message,
    DateTime CheckedAt,
    long ResponseTimeMs);




