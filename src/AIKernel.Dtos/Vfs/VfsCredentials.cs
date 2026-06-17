namespace AIKernel.Dtos.Vfs;

/// <summary>[EN] Documents this public package API member. [JA] VfsCredentials を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsCredentials']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Vfs.VfsCredentials']" />
public sealed record VfsCredentials
{
    /// <summary>[EN] Documents this public package API member. [JA] Username を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsCredentials.Username']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsCredentials.Username']" />
    public string? Username { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ApiKey を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsCredentials.ApiKey']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsCredentials.ApiKey']" />
    public string? ApiKey { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Token を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsCredentials.Token']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsCredentials.Token']" />
    public string? Token { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Parameters を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsCredentials.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Vfs.VfsCredentials.string']" />
    public IReadOnlyDictionary<string, string>? Parameters { get; init; }
}
