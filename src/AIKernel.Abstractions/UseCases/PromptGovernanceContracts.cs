namespace AIKernel.Abstractions.UseCases;

public interface IPromptSignatureProvider
{
    Task<AIKernel.Dtos.Prompt.SignatureVerificationResult> VerifySignatureAsync(
        SignedPromptArtifactDto artifact,
        CancellationToken ct = default);
}

public interface IPromptVerifier
{
    Task<PromptVerificationResult> VerifyAsync(
        SignedPromptArtifactDto artifact,
        CancellationToken ct = default);
}

public interface IPromptRepository
{
    Task<SignedPromptArtifactDto?> GetSignedPromptArtifactAsync(string entityId, CancellationToken ct = default);
}

public interface IPromptValidator
{
    Task<PromptValidationResult> ValidateAsync(
        SignedPromptArtifactDto artifact,
        Models.IExecutionConstraints executionConstraints,
        CancellationToken ct = default);
}
