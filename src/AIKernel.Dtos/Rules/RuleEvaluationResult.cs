namespace AIKernel.Dtos.Rules;

public sealed record RuleEvaluationResult(
    bool Success,
    bool Passed,
    string? Reason,
    double Score,
    IReadOnlyDictionary<string, string>? Metadata,
    long DurationMs);
