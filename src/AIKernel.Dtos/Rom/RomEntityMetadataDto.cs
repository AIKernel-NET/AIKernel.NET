namespace AIKernel.Dtos.Rom;

/// <summary>
/// EN: RomEntityMetadataDto の契約を定義します。
/// EN: Documentation for public API. JA: RomEntityMetadataDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomEntityMetadataDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomEntityMetadataDto']" />
public sealed record RomEntityMetadataDto
{
    /// <summary>EN: Documentation for public API. JA: EntityId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomEntityMetadataDto.EntityId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomEntityMetadataDto.EntityId']" />
    public required string EntityId { get; init; }
    /// <summary>EN: Documentation for public API. JA: EntityType を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomEntityMetadataDto.EntityType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomEntityMetadataDto.EntityType']" />
    public required string EntityType { get; init; }
    /// <summary>EN: Documentation for public API. JA: Version を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomEntityMetadataDto.Version']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomEntityMetadataDto.Version']" />
    public required string Version { get; init; }
    /// <summary>EN: Documentation for public API. JA: AdditionalMetadata を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomEntityMetadataDto.object&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomEntityMetadataDto.object&gt;']" />
    public IReadOnlyDictionary<string, object> AdditionalMetadata { get; init; } = new Dictionary<string, object>();
}



