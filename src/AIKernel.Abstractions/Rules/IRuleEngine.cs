namespace AIKernel.Abstractions.Rules;

/// <summary>
/// EN: UC-11/UC-21 に基づく IRuleEngine の契約を定義します。
/// EN: Documentation for public API. JA: IRuleEngine の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rules.IRuleEngine']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rules.IRuleEngine']" />
public interface IRuleEngine
{
    /// <summary>EN: Executes the EvaluateAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで EvaluateAsync 操作を実行します。</summary>
    ValueTask<RuleEvaluationResult> EvaluateAsync(
        string ruleId,
        RuleEvaluationContext context,
        CancellationToken cancellationToken = default);
}


