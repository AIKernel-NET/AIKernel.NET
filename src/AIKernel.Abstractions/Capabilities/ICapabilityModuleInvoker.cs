namespace AIKernel.Abstractions.Capabilities;

using AIKernel.Dtos.Capabilities;

/// <summary>[EN] Documents this public package API member. [JA] ICapabilityModuleInvoker contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Capabilities.ICapabilityModuleInvoker']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Capabilities.ICapabilityModuleInvoker']" />
public interface ICapabilityModuleInvoker
{
    /// <summary>EN: Executes the InvokeAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで InvokeAsync 操作を実行します。</summary>
    ValueTask<CapabilityInvocationResult> InvokeAsync(
        CapabilityInvocationRequest request,
        CancellationToken cancellationToken = default);
}
