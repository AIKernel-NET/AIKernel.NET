namespace AIKernel.Abstractions.Execution;

using AIKernel.Abstractions.Providers;
using AIKernel.Dtos.Execution;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IModelPromptCapabilityResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IModelPromptCapabilityResolver']" />
public interface IModelPromptCapabilityResolver
{
    /// <summary>Executes the Resolve operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Resolve 操作を実行します。</summary>
    ModelPromptCapability Resolve(
        IModelProvider provider,
        KernelExecutionRequest request);
}
