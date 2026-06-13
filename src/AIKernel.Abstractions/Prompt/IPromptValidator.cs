namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく IPromptValidator の契約を定義します。
/// JA: IPromptValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptValidator']" />
public interface IPromptValidator
{
    /// <summary>Executes the ValidateAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateAsync 操作を実行します。</summary>
    Task<PromptValidationResult> ValidateAsync(
        SignedPromptArtifactDto artifact,
        Models.IExecutionConstraints executionConstraints,
        CancellationToken ct = default);
}




