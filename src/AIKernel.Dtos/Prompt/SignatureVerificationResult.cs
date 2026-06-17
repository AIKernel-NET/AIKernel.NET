namespace AIKernel.Dtos.Prompt;

/// <summary>
/// EN: SignatureVerificationResult の契約を定義します。
/// [EN] Documents this public package API member. [JA] SignatureVerificationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.SignatureVerificationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.SignatureVerificationResult']" />
public sealed record SignatureVerificationResult(
    bool IsValid,
    string Message);



