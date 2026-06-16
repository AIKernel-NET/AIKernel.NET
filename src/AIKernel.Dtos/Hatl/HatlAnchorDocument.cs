using AIKernel.Enums;

namespace AIKernel.Dtos.Hatl;

/// <summary>EN: Documentation for public API. JA: HatlAnchorDocument を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlAnchorDocument']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlAnchorDocument']" />
public sealed record HatlAnchorDocument(
    string AnchorId,
    string LedgerId,
    HatlAnchorProfile AnchorProfile,
    long StartSequenceNumber,
    long EndSequenceNumber,
    string MerkleRootHash,
    string? PreviousAnchorHash,
    string AnchorHash,
    string SignatureAlgorithm,
    string Signature,
    IReadOnlyDictionary<string, string> Metadata);
