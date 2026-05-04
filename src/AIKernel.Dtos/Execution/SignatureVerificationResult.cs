namespace AIKernel.Dtos.Execution;

public sealed record SignatureVerificationResult
{
    public required bool IsValid { get; init; }
    public required string SignerId { get; init; }
    public required double TrustScore { get; init; }
    public required string Message { get; init; }
    public required DateTime VerificationTimestamp { get; init; }
}

