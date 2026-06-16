namespace AIKernel.Dtos.Rules;

/// <summary>
/// EN: RuleEvaluationResult の契約を定義します。
/// [EN] Documents this public package API member. [JA] RuleEvaluationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rules.RuleEvaluationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rules.RuleEvaluationResult']" />
public sealed record RuleEvaluationResult(
    bool Success,
    bool Passed,
    string? Reason,
    double Score,
    IReadOnlyDictionary<string, string>? Metadata,
    long DurationMs);



