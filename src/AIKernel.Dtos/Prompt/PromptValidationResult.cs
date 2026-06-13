namespace AIKernel.Dtos.Prompt;

using AIKernel.Enums;

/// <summary>
/// PromptValidationResult の契約を定義します。
/// JA: PromptValidationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.PromptValidationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.PromptValidationResult']" />
public sealed record PromptValidationResult(
    FailClosedDecision Decision,
    bool TemporalIntegrityValid,
    bool ScopeBindingValid,
    IReadOnlyList<string> Violations,
    string Message);



