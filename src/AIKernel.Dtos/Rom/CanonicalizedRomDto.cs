namespace AIKernel.Dtos.Rom;

/// <summary>
/// EN: CanonicalizedRomDto の契約を定義します。
/// EN: Documentation for public API. JA: CanonicalizedRomDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.CanonicalizedRomDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.CanonicalizedRomDto']" />
public sealed record CanonicalizedRomDto
{
    /// <summary>EN: Documentation for public API. JA: CanonicalBody を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDto.CanonicalBody']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDto.CanonicalBody']" />
    public required string CanonicalBody { get; init; }
    /// <summary>EN: Documentation for public API. JA: CanonicalizationVersion を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDto.CanonicalizationVersion']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDto.CanonicalizationVersion']" />
    public required string CanonicalizationVersion { get; init; }
    /// <summary>EN: Documentation for public API. JA: Entities を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.CanonicalizedRomDto.List&lt;RomEntityMetadataDto&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.CanonicalizedRomDto.List&lt;RomEntityMetadataDto&gt;']" />
    public IReadOnlyList<RomEntityMetadataDto> Entities { get; init; } = new List<RomEntityMetadataDto>();
    /// <summary>EN: Documentation for public API. JA: Relations を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.CanonicalizedRomDto.List&lt;ResolvedRomRelationDto&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.CanonicalizedRomDto.List&lt;ResolvedRomRelationDto&gt;']" />
    public IReadOnlyList<ResolvedRomRelationDto> Relations { get; init; } = new List<ResolvedRomRelationDto>();
}


