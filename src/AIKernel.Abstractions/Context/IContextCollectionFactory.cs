namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Context;
using AIKernel.Dtos.Rom;

/// <summary>[EN] Documents this public package API member. [JA] IContextCollectionFactory contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextCollectionFactory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextCollectionFactory']" />
public interface IContextCollectionFactory
{
    /// <summary>EN: Executes the Create operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Create 操作を実行します。</summary>
    IContextCollection Create(
        IReadOnlyList<RomSnapshot> roms,
        IReadOnlyList<RomContextEdge> edges,
        ContextAssemblyScope scope);
}
