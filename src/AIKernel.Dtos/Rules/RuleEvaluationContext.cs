namespace AIKernel.Dtos.Rules;

/// <summary>
/// EN: RuleEvaluationContext の契約を定義します。
/// EN: Documentation for public API. JA: RuleEvaluationContext の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rules.RuleEvaluationContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rules.RuleEvaluationContext']" />
public sealed record RuleEvaluationContext(
    string ContextId,
    string Phase,
    IReadOnlyDictionary<string, string> Values);



