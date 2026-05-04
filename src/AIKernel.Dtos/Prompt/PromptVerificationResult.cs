namespace AIKernel.Dtos.Prompt;

using AIKernel.Enums;

public sealed record PromptVerificationResult(
    FailClosedDecision Decision,
    bool HashIntegrityVerified,
    bool SignaturePresent,
    string Message);
