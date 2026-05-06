namespace AIKernel.Dtos.Core;

/// <summary>
/// RateLimitInfo の契約を定義します。
/// </summary>
public sealed record RateLimitInfo(
    int WindowSeconds,
    int RequestsPerWindow,
    int UsedRequests);




