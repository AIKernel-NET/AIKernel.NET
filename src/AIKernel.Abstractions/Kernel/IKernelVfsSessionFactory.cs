namespace AIKernel.Abstractions.Kernel;

using AIKernel.Dtos.Kernel;
using AIKernel.Vfs;

/// <summary>[EN] Documents this public package API member. [JA] IKernelVfsSessionFactory contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelVfsSessionFactory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelVfsSessionFactory']" />
public interface IKernelVfsSessionFactory
{
    /// <summary>EN: Executes the OpenSessionAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで OpenSessionAsync 操作を実行します。</summary>
    Task<IVfsSession> OpenSessionAsync(
        KernelRequest request,
        CancellationToken cancellationToken = default);
}
