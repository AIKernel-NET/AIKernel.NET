namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// EN: UC-11/UC-12/UC-13 に基づく IPromptSignatureProvider の契約を定義します。
/// EN: Documentation for public API. JA: IPromptSignatureProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptSignatureProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptSignatureProvider']" />
public interface IPromptSignatureProvider
{
    /// <summary>EN: Executes the VerifySignatureAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifySignatureAsync 操作を実行します。</summary>
    Task<AIKernel.Dtos.Prompt.SignatureVerificationResult> VerifySignatureAsync(
        SignedPromptArtifactDto artifact,
        CancellationToken ct = default);
}




