namespace AIKernel.Dtos.Hatl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlLedgerEntry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlLedgerEntry']" />
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
