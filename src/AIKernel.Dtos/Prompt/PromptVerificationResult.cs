namespace AIKernel.Dtos.Prompt;

using AIKernel.Enums;

/// <summary>
/// PromptVerificationResult の契約を定義します。
/// </summary>
public sealed record PromptVerificationResult(
    FailClosedDecision Decision,
    bool HashIntegrityVerified,
    bool SignaturePresent,
    string Message);



