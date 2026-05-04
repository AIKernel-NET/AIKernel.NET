namespace AIKernel.Dtos.Governance;

public sealed record TrustContext
{
    public required string SignerId { get; init; }
    public required double TrustScore { get; init; }
    public required bool IsKeyRevoked { get; init; }
    public DateTime? KeyExpiry { get; init; }
    public required bool IsCertificateChainValid { get; init; }
    public required bool IsTrustStoreHealthy { get; init; }
    public required DateTime VerificationTimestamp { get; init; }
    public required bool IsDetermined { get; init; }
}
