namespace AIKernel.Dtos.Hatl;

public sealed record HatlBlockMacResult(
    string MacAlgorithm,
    string Mac,
    string EntryHash,
    string MerkleLeafHash,
    IReadOnlyDictionary<string, string> Metadata);
