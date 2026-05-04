namespace AIKernel.Dtos.Prompt;

public sealed record GovernanceMetadataDto
{
    public required string Issuer { get; init; }
    public required string SignerId { get; init; }
    public string HashAlgorithm { get; init; } = "SHA256";
    public required string Hash { get; init; }
    public required string Signature { get; init; }
    public DateTime SignedAt { get; init; }
}
