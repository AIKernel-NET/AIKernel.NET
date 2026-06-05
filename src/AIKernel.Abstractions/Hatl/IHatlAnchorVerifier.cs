namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

public interface IHatlAnchorVerifier
{
    ValueTask<HatlVerificationResult> VerifyAnchorAsync(
        HatlAnchorDocument anchor,
        CancellationToken cancellationToken = default);

    ValueTask<HatlVerificationResult> VerifyInclusionAsync(
        HatlLedgerEntry entry,
        HatlAnchorDocument anchor,
        IReadOnlyList<string> merklePath,
        CancellationToken cancellationToken = default);
}
