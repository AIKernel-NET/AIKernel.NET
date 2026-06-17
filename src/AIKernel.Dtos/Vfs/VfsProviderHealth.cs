namespace AIKernel.Dtos.Vfs;

/// <summary>
/// EN: VfsProviderHealth の契約を定義します。
/// [EN] Documents this public package API member. [JA] VfsProviderHealth の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsProviderHealth']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsProviderHealth']" />
public sealed record VfsProviderHealth
{
    /// <summary>[EN] Documents this public package API member. [JA] IsHealthy を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.IsHealthy']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.IsHealthy']" />
    public required bool IsHealthy { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Message を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.Message']" />
    public string? Message { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] CheckedAtUtc を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.CheckedAtUtc']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsProviderHealth.CheckedAtUtc']" />
    public required DateTimeOffset CheckedAtUtc { get; init; }
}



