namespace AIKernel.Dtos.Rom;

/// <summary>
/// EN: ResolvedRelation の契約を定義します。
/// [EN] Documents this public package API member. [JA] ResolvedRelation の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.ResolvedRelation']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.ResolvedRelation']" />
public sealed record ResolvedRelation
{
    /// <summary>[EN] Documents this public package API member. [JA] OriginalReference を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRelation.OriginalReference']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRelation.OriginalReference']" />
    public required string OriginalReference { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] ResolvedId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRelation.ResolvedId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRelation.ResolvedId']" />
    public required string ResolvedId { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] RelationType を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRelation.RelationType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRelation.RelationType']" />
    public required string RelationType { get; init; }
}




