namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく IPromptVerifier の契約を定義します。
/// </summary>
public interface IPromptVerifier
{
    Task<PromptVerificationResult> VerifyAsync(
        SignedPromptArtifactDto artifact,
        CancellationToken ct = default);
}




