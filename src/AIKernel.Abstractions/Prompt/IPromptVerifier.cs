namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// EN: UC-11/UC-12/UC-13 に基づく IPromptVerifier の契約を定義します。
/// EN: Documentation for public API. JA: IPromptVerifier の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptVerifier']" />
public interface IPromptVerifier
{
    /// <summary>EN: Executes the VerifyAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAsync 操作を実行します。</summary>
    Task<PromptVerificationResult> VerifyAsync(
        SignedPromptArtifactDto artifact,
        CancellationToken ct = default);
}




