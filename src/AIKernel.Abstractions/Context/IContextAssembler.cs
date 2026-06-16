namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Context;
using AIKernel.Dtos.Rom;
using AIKernel.Vfs;

/// <summary>EN: Documentation for public API. JA: IContextAssembler contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextAssembler']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextAssembler']" />
public interface IContextAssembler
{
    /// <summary>EN: Executes the AssembleAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで AssembleAsync 操作を実行します。</summary>
    Task<IContextSnapshot> AssembleAsync(
        IVfsSession session,
        ContextAssemblyRequest request,
        CancellationToken cancellationToken = default);
}
