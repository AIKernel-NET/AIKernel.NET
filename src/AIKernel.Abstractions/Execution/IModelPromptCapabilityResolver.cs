namespace AIKernel.Abstractions.Execution;

using AIKernel.Abstractions.Providers;
using AIKernel.Dtos.Execution;

/// <summary>EN: Documentation for public API. JA: IModelPromptCapabilityResolver contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IModelPromptCapabilityResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IModelPromptCapabilityResolver']" />
public interface IModelPromptCapabilityResolver
{
    /// <summary>EN: Executes the Resolve operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Resolve 操作を実行します。</summary>
    ModelPromptCapability Resolve(
        IModelProvider provider,
        KernelExecutionRequest request);
}
