namespace AIKernel.Abstractions.UseCases;

public interface IPromptSignatureProvider
{
    Task<SignatureVerificationResult> VerifySignatureAsync(
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

public enum FailClosedDecision
{
    Allow = 0,
    Deny = 1,
    Indeterminate = 2
}

public sealed record SignatureVerificationResult(
    bool IsValid,
    string Message);

public sealed record PromptVerificationResult(
    FailClosedDecision Decision,
    bool HashIntegrityVerified,
    bool SignaturePresent,
    string Message);

public sealed record PromptValidationResult(
    FailClosedDecision Decision,
    bool TemporalIntegrityValid,
    bool ScopeBindingValid,
    IReadOnlyList<string> Violations,
    string Message);
