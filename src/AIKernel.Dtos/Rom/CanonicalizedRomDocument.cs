namespace AIKernel.Dtos.Rom;

/// <summary>
/// CanonicalizedRomDocument の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.CanonicalizedRomDocument']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.CanonicalizedRomDocument']" />
public sealed record CanonicalizedRomDocument
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDocument.NormalizedEntityId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDocument.NormalizedEntityId']" />
    public required string NormalizedEntityId { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDocument.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDocument.string']" />
    public required IReadOnlyDictionary<string, string> NormalizedMetadata { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDocument.NormalizedBody']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDocument.NormalizedBody']" />
    public required string NormalizedBody { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.CanonicalizedRomDocument.List&lt;ResolvedRelation&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.CanonicalizedRomDocument.List&lt;ResolvedRelation&gt;']" />
    public IReadOnlyList<ResolvedRelation> ResolvedRelations { get; init; } = new List<ResolvedRelation>();
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDocument.CanonicalizedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CanonicalizedRomDocument.CanonicalizedAt']" />
    public required DateTime CanonicalizedAt { get; init; }
}




