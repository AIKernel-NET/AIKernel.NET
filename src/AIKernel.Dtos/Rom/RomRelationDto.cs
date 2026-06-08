namespace AIKernel.Dtos.Rom;

/// <summary>
/// RomRelationDto の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomRelationDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomRelationDto']" />
public sealed record RomRelationDto
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.RelationType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.RelationType']" />
    public required string RelationType { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.RelationName']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.RelationName']" />
    public required string RelationName { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.TargetReference']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.TargetReference']" />
    public string? TargetReference { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.NumericValue']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.NumericValue']" />
    public double? NumericValue { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.TextValue']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomRelationDto.TextValue']" />
    public string? TextValue { get; init; }
}



