namespace AIKernel.Dtos.Vfs;

/// <summary>
/// VfsProviderHealth の契約を定義します。
/// JA: VfsProviderHealth の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsProviderHealth']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsProviderHealth']" />
public sealed record VfsProviderHealth
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.IsHealthy']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.IsHealthy']" />
    public required bool IsHealthy { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.Message']" />
    public string? Message { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.CheckedAtUtc']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.CheckedAtUtc']" />
    public required DateTimeOffset CheckedAtUtc { get; init; }
}



