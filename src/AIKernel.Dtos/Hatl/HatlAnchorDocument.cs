using AIKernel.Enums;

namespace AIKernel.Dtos.Hatl;

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
