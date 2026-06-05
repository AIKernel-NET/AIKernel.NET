using AIKernel.Enums;

namespace AIKernel.Dtos.Hatl;

public sealed record HatlVerificationResult(
    HatlVerificationStatus Status,
    string? AnchorId,
    string? VerifiedHash,
    string? FailureCode,
    IReadOnlyDictionary<string, string> Metadata);
