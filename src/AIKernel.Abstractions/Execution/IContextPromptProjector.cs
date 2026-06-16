namespace AIKernel.Abstractions.Execution;

using AIKernel.Abstractions.Context;
using AIKernel.Dtos.Execution;

/// <summary>EN: Documentation for public API. JA: IContextPromptProjector contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IContextPromptProjector']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IContextPromptProjector']" />
public interface IContextPromptProjector
{
    /// <summary>EN: Executes the Project operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Project 操作を実行します。</summary>
    IReadOnlyList<ContextPromptBlock> Project(
        IContextSnapshot snapshot,
        PromptProjectionOptions options);
}
