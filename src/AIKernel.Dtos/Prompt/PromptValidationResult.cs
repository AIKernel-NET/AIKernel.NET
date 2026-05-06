namespace AIKernel.Dtos.Prompt;

using AIKernel.Enums;

/// <summary>
/// PromptValidationResult の契約を定義します。
/// </summary>
public sealed record PromptValidationResult(
    FailClosedDecision Decision,
    bool TemporalIntegrityValid,
    bool ScopeBindingValid,
    IReadOnlyList<string> Violations,
    string Message);



