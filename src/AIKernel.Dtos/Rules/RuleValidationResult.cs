namespace AIKernel.Dtos.Rules;

/// <summary>
/// EN: RuleValidationResult の契約を定義します。
/// EN: Documentation for public API. JA: RuleValidationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rules.RuleValidationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rules.RuleValidationResult']" />
public sealed record RuleValidationResult(
    bool Success,
    bool Valid,
    IReadOnlyList<string> Errors,
    IReadOnlyList<string> Warnings,
    long DurationMs);



