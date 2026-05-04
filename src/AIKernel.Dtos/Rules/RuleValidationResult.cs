namespace AIKernel.Dtos.Rules;

public sealed record RuleValidationResult(
    bool Success,
    bool Valid,
    IReadOnlyList<string> Errors,
    IReadOnlyList<string> Warnings,
    long DurationMs);
