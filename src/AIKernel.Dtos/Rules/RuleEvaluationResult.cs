namespace AIKernel.Dtos.Rules;

/// <summary>
/// RuleEvaluationResult の契約を定義します。
/// </summary>
public sealed record RuleEvaluationResult(
    bool Success,
    bool Passed,
    string? Reason,
    double Score,
    IReadOnlyDictionary<string, string>? Metadata,
    long DurationMs);



