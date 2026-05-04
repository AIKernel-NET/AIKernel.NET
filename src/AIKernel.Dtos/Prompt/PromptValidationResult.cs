namespace AIKernel.Dtos.Prompt;

using AIKernel.Enums;

public sealed record PromptValidationResult(
    FailClosedDecision Decision,
    bool TemporalIntegrityValid,
    bool ScopeBindingValid,
    IReadOnlyList<string> Violations,
    string Message);
