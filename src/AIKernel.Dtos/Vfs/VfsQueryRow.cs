namespace AIKernel.Dtos.Vfs;

/// <summary>
/// EN: VfsQueryRow の契約を定義します。
/// EN: Documentation for public API. JA: VfsQueryRow の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsQueryRow']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsQueryRow']" />
public sealed record VfsQueryRow
{
    /// <summary>EN: Documentation for public API. JA: Data を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsQueryRow.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsQueryRow.string']" />
    public required IReadOnlyDictionary<string, string> Data { get; init; }
}



