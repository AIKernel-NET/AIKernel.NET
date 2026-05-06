namespace AIKernel.Abstractions.Rules;

/// <summary>
/// UC-11/UC-21 に基づく IRuleEngine の契約を定義します。
/// </summary>
public interface IRuleEngine
{
    ValueTask<RuleEvaluationResult> EvaluateAsync(
        string ruleId,
        RuleEvaluationContext context,
        CancellationToken cancellationToken = default);
}


