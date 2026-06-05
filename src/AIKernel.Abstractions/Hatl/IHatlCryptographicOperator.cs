namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

public interface IHatlCryptographicOperator
{
    ValueTask<HatlBlockMacResult> ComputeBlockMacAsync(
        HatlBlockMacRequest request,
        CancellationToken cancellationToken = default);

    ValueTask<HatlRatchetStepResult> AdvanceRatchetAsync(
        HatlRatchetStepRequest request,
        CancellationToken cancellationToken = default);

    ValueTask<HatlVerificationResult> VerifyAnchorSignatureAsync(
        HatlAnchorDocument anchor,
        CancellationToken cancellationToken = default);
}
