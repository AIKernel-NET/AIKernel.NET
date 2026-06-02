namespace AIKernel.Dtos.Rom;

public sealed record RomSignatureVerificationResult(
    bool IsVerified,
    string Algorithm,
    string ExpectedHash,
    string ActualHash);