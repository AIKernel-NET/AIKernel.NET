namespace AIKernel.Dtos.Rom;

public sealed record RomSignatureSnapshot(
    string Algorithm,
    string ExpectedHash,
    string ActualHash,
    bool IsVerified);