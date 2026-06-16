namespace AIKernel.Dtos.Rom;

/// <summary>
/// EN: RomRelationDto の契約を定義します。
/// EN: Documentation for public API. JA: RomRelationDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomRelationDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomRelationDto']" />
public sealed record RomRelationDto
{
    /// <summary>EN: Documentation for public API. JA: RelationType を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.RelationType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.RelationType']" />
    public required string RelationType { get; init; }
    /// <summary>EN: Documentation for public API. JA: RelationName を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.RelationName']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.RelationName']" />
    public required string RelationName { get; init; }
    /// <summary>EN: Documentation for public API. JA: TargetReference を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.TargetReference']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.TargetReference']" />
    public string? TargetReference { get; init; }
    /// <summary>EN: Documentation for public API. JA: NumericValue を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.NumericValue']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.NumericValue']" />
    public double? NumericValue { get; init; }
    /// <summary>EN: Documentation for public API. JA: TextValue を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.TextValue']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.TextValue']" />
    public string? TextValue { get; init; }
}



