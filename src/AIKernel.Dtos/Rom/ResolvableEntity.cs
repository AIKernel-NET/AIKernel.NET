namespace AIKernel.Dtos.Rom;

/// <summary>
/// EN: ResolvableEntity の契約を定義します。
/// [EN] Documents this public package API member. [JA] ResolvableEntity の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.ResolvableEntity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.ResolvableEntity']" />
public sealed record ResolvableEntity
{
    /// <summary>[EN] Documents this public package API member. [JA] Id を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvableEntity.Id']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvableEntity.Id']" />
    public required string Id { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Type を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvableEntity.Type']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvableEntity.Type']" />
    public required string Type { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Metadata を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.ResolvableEntity.string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.ResolvableEntity.string&gt;']" />
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}




