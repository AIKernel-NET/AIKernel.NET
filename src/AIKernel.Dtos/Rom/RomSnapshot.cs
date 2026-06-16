namespace AIKernel.Dtos.Rom;

using System.Collections.Immutable;

/// <summary>EN: Documentation for public API. JA: RomSnapshot を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSnapshot']" />
public sealed record RomSnapshot
{
    /// <summary>EN: Documentation for public API. JA: RomId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.RomId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.RomId']" />
    public required RomId RomId { get; init; }

    /// <summary>EN: Documentation for public API. JA: SourcePath を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.SourcePath']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.SourcePath']" />
    public required string SourcePath { get; init; }

    /// <summary>EN: Documentation for public API. JA: Body を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.Body']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.Body']" />
    public required string Body { get; init; }

    /// <summary>EN: Documentation for public API. JA: SecurityTags を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.SecurityTags']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.SecurityTags']" />
    public required ImmutableArray<string> SecurityTags { get; init; }

    /// <summary>EN: Documentation for public API. JA: Relations を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.Relations']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.Relations']" />
    public required ImmutableArray<RomRelationSnapshot> Relations { get; init; }

    /// <summary>EN: Documentation for public API. JA: Signature を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.Signature']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.Signature']" />
    public required RomSignatureSnapshot Signature { get; init; }

    /// <summary>EN: Documentation for public API. JA: LoadedAtUtc を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.LoadedAtUtc']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.LoadedAtUtc']" />
    public required DateTimeOffset LoadedAtUtc { get; init; }

    /// <summary>EN: Documentation for public API. JA: AdditionalMetadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshot.string']" />
    public required ImmutableDictionary<string, string> AdditionalMetadata { get; init; }
}