namespace AIKernel.Abstractions.Execution;

using AIKernel.Dtos.Execution;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPromptGenerator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPromptGenerator']" />
public interface IPromptGenerator
{
    /// <summary>Executes the GenerateAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GenerateAsync 操作を実行します。</summary>
    Task<GeneratedPrompt> GenerateAsync(
        PromptGenerationRequest request,
        CancellationToken cancellationToken = default);
}
