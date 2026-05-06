namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく IPromptSignatureProvider の契約を定義します。
/// </summary>
public interface IPromptSignatureProvider
{
    Task<AIKernel.Dtos.Prompt.SignatureVerificationResult> VerifySignatureAsync(
        SignedPromptArtifactDto artifact,
        CancellationToken ct = default);
}




