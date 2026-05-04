namespace AIKernel.Dtos.Prompt;

public sealed record GovernanceMetadataDto
{
    public string Issuer { get; init; }
    public string SignerId { get; init; }
    public string HashAlgorithm { get; init; } = "SHA256";
    public string Hash { get; init; }
    public string Signature { get; init; }
    public DateTime SignedAt { get; init; }

    public GovernanceMetadataDto() { }

    public GovernanceMetadataDto(
        string issuer,
        string signerId,
        string hashAlgorithm,
        string hash,
        string signature,
        DateTime signedAt)
    {
        Issuer = issuer;
        SignerId = signerId;
        HashAlgorithm = hashAlgorithm;
        Hash = hash;
        Signature = signature;
        SignedAt = signedAt;
    }
}
