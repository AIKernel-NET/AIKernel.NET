namespace AIKernel.Dtos.Rules;

/// <summary>
/// RuleEvaluationContext の契約を定義します。
/// </summary>
public sealed record RuleEvaluationContext(
    string ContextId,
    string Phase,
    IReadOnlyDictionary<string, string> Values);



