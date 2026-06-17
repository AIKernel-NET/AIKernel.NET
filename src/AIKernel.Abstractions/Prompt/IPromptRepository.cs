namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// EN: UC-11/UC-12/UC-13 に基づく IPromptRepository の契約を定義します。
/// [EN] Documents this public package API member. [JA] IPromptRepository の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptRepository']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptRepository']" />
public interface IPromptRepository
{
    /// <summary>EN: Executes the GetSignedPromptArtifactAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetSignedPromptArtifactAsync 操作を実行します。</summary>
    Task<SignedPromptArtifactDto?> GetSignedPromptArtifactAsync(string entityId, CancellationToken ct = default);
}




