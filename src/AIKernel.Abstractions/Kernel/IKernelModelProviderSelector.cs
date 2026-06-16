namespace AIKernel.Abstractions.Kernel;

using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Providers;
using AIKernel.Dtos.Kernel;

/// <summary>[EN] Documents this public package API member. [JA] IKernelModelProviderSelector contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelModelProviderSelector']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelModelProviderSelector']" />
public interface IKernelModelProviderSelector
{
    /// <summary>EN: Executes the SelectAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SelectAsync 操作を実行します。</summary>
    Task<IModelProvider> SelectAsync(
        KernelRequest request,
        IContextSnapshot contextSnapshot,
        CancellationToken cancellationToken = default);
}
