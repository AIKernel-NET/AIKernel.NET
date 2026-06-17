namespace AIKernel.Dtos.Rom;

using System.Collections.Immutable;

/// <summary>[EN] Documents this public package API member. [JA] RomSnapshotCandidate を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSnapshotCandidate']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSnapshotCandidate']" />
public sealed record RomSnapshotCandidate
{
    /// <summary>[EN] Documents this public package API member. [JA] RomId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.RomId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.RomId']" />
    public required RomId RomId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] SourcePath を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.SourcePath']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.SourcePath']" />
    public required string SourcePath { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Body を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.Body']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.Body']" />
    public required string Body { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] SecurityTags を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.SecurityTags']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.SecurityTags']" />
    public required ImmutableArray<string> SecurityTags { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Relations を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.Relations']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.Relations']" />
    public required ImmutableArray<RomRelationSnapshot> Relations { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ExpectedHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.ExpectedHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.ExpectedHash']" />
    public required string ExpectedHash { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] AdditionalMetadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSnapshotCandidate.string']" />
    public required ImmutableDictionary<string, string> AdditionalMetadata { get; init; }
}