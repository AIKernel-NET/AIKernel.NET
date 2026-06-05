namespace AIKernel.Dtos.Hatl;

public sealed record HatlLedgerEntry(
    string LedgerId,
    long SequenceNumber,
    string PreviousEntryHash,
    string EntryHash,
    string PayloadHash,
    string MacAlgorithm,
    string Mac,
    string MerkleLeafHash,
    IReadOnlyDictionary<string, string> Metadata);
