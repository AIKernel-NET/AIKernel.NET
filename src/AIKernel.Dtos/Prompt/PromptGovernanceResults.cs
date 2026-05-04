namespace AIKernel.Dtos.Prompt;

using AIKernel.Enums;

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
