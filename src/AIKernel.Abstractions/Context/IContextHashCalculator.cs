namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Context;
using AIKernel.Dtos.Rom;

/// <summary>EN: Documentation for public API. JA: IContextHashCalculator contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextHashCalculator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextHashCalculator']" />
public interface IContextHashCalculator
{
    /// <summary>EN: Executes the ComputeHash operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ComputeHash 操作を実行します。</summary>
    string ComputeHash(
        ContextAssemblyRequest request,
        IReadOnlyList<RomSnapshot> roms,
        IReadOnlyList<RomContextEdge> edges);
}
