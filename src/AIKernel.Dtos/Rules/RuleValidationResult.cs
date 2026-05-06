namespace AIKernel.Dtos.Rules;

/// <summary>
/// RuleValidationResult の契約を定義します。
/// </summary>
public sealed record RuleValidationResult(
    bool Success,
    bool Valid,
    IReadOnlyList<string> Errors,
    IReadOnlyList<string> Warnings,
    long DurationMs);



