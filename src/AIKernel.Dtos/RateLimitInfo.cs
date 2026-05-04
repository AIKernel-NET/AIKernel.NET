namespace AIKernel.Dtos;

public sealed record RateLimitInfo(
    int WindowSeconds,
    int RequestsPerWindow,
    int UsedRequests);
