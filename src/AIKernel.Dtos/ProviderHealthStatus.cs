namespace AIKernel.Dtos;

public sealed record ProviderHealthStatus(
    bool IsHealthy,
    string? Message,
    DateTime CheckedAt,
    long ResponseTimeMs);
