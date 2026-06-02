namespace AIKernel.Abstractions.Rom;

using AIKernel.Dtos.Rom;

public interface IRomSignatureVerifier
{
    Task<RomSignatureVerificationResult> VerifyAsync(
        RomSnapshotCandidate candidate,
        CancellationToken cancellationToken = default);
}