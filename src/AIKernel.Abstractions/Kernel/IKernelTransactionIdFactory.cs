namespace AIKernel.Abstractions.Kernel;

using AIKernel.Dtos.Kernel;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelTransactionIdFactory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelTransactionIdFactory']" />
public interface IKernelTransactionIdFactory
{
    /// <summary>Executes the CreateTransactionId operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CreateTransactionId 操作を実行します。</summary>
    string CreateTransactionId(KernelRequest request);
}
