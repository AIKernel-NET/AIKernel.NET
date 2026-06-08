namespace AIKernel.Dtos.Vfs;

/// <summary>
/// VfsQueryRow の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsQueryRow']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsQueryRow']" />
public sealed record VfsQueryRow
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsQueryRow.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsQueryRow.string']" />
    public required IReadOnlyDictionary<string, string> Data { get; init; }
}



