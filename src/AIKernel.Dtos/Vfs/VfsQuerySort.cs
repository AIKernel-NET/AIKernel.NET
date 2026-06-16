namespace AIKernel.Dtos.Vfs;

/// <summary>
/// EN: VfsQuerySort の契約を定義します。
/// EN: Documentation for public API. JA: VfsQuerySort の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsQuerySort']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsQuerySort']" />
public sealed record VfsQuerySort
{
    /// <summary>EN: Documentation for public API. JA: FieldName を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsQuerySort.FieldName']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsQuerySort.FieldName']" />
    public required string FieldName { get; init; }
    /// <summary>EN: Documentation for public API. JA: Ascending を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsQuerySort.Ascending']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsQuerySort.Ascending']" />
    public bool Ascending { get; init; } = true;
}



