namespace AIKernel.Abstractions.Kernel;

using AIKernel.Dtos.Kernel;

/// <summary>EN: Documentation for public API. JA: IKernelRequestHasher contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelRequestHasher']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelRequestHasher']" />
public interface IKernelRequestHasher
{
    /// <summary>EN: Executes the ComputeHash operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ComputeHash 操作を実行します。</summary>
    string ComputeHash(KernelRequest request);
}
