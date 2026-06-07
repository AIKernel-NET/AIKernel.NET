namespace AIKernel.Abstractions.Rom;

using AIKernel.Dtos.Rom;
using AIKernel.Vfs;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomLoader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomLoader']" />
public interface IRomLoader
{
    /// <summary>Executes the LoadAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで LoadAsync 操作を実行します。</summary>
    Task<RomSnapshot> LoadAsync(
        IVfsSession session,
        string path,
        CancellationToken cancellationToken = default);
}
