namespace AIKernel.Abstractions.Kernel;

using AIKernel.Dtos.Kernel;

/// <summary>[EN] Documents this public package API member. [JA] IKernelTransactionIdFactory contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelTransactionIdFactory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelTransactionIdFactory']" />
public interface IKernelTransactionIdFactory
{
    /// <summary>EN: Executes the CreateTransactionId operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CreateTransactionId 操作を実行します。</summary>
    string CreateTransactionId(KernelRequest request);
}
