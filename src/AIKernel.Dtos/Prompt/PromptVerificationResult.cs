namespace AIKernel.Dtos.Prompt;

using AIKernel.Enums;

/// <summary>
/// PromptVerificationResult の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.PromptVerificationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.PromptVerificationResult']" />
public sealed record PromptVerificationResult(
    FailClosedDecision Decision,
    bool HashIntegrityVerified,
    bool SignaturePresent,
    string Message);



