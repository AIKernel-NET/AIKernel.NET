namespace AIKernel.Dtos.Rom;

/// <summary>
/// EN: ResolvedRomRelationDto の契約を定義します。
/// EN: Documentation for public API. JA: ResolvedRomRelationDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.ResolvedRomRelationDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.ResolvedRomRelationDto']" />
public sealed record ResolvedRomRelationDto
{
    /// <summary>EN: Documentation for public API. JA: OriginalReference を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRomRelationDto.OriginalReference']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRomRelationDto.OriginalReference']" />
    public required string OriginalReference { get; init; }
    /// <summary>EN: Documentation for public API. JA: FullyQualifiedId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRomRelationDto.FullyQualifiedId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRomRelationDto.FullyQualifiedId']" />
    public required string FullyQualifiedId { get; init; }
    /// <summary>EN: Documentation for public API. JA: RelationType を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRomRelationDto.RelationType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.ResolvedRomRelationDto.RelationType']" />
    public required string RelationType { get; init; }
}



