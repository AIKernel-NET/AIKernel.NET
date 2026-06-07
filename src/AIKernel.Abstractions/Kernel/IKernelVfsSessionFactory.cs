namespace AIKernel.Abstractions.Kernel;

using AIKernel.Dtos.Kernel;
using AIKernel.Vfs;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelVfsSessionFactory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelVfsSessionFactory']" />
public interface IKernelVfsSessionFactory
{
    /// <summary>Executes the OpenSessionAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで OpenSessionAsync 操作を実行します。</summary>
    Task<IVfsSession> OpenSessionAsync(
        KernelRequest request,
        CancellationToken cancellationToken = default);
}
