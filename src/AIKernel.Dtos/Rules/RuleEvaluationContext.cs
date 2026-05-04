namespace AIKernel.Dtos.Rules;

public sealed record RuleEvaluationContext(
    string ContextId,
    string Phase,
    IReadOnlyDictionary<string, string> Values);
