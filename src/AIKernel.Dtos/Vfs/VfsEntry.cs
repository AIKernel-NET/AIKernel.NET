using AIKernel.Enums;

namespace AIKernel.Dtos.Vfs;

/// <summary>
/// VfsEntry の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsEntry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsEntry']" />
public sealed record VfsEntry
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.Name']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.Name']" />
    public required string Name { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.Type']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.Type']" />
    public required VfsEntryType Type { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.Path']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.Path']" />
    public required string Path { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.Size']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.Size']" />
    public long Size { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.CreatedAt']" />
    public required DateTime CreatedAt { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.ModifiedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsEntry.ModifiedAt']" />
    public required DateTime ModifiedAt { get; init; }
}



