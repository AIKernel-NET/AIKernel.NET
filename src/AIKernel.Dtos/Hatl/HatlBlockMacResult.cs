namespace AIKernel.Dtos.Hatl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlBlockMacResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlBlockMacResult']" />
public sealed record HatlBlockMacResult(
    string MacAlgorithm,
    string Mac,
    string EntryHash,
    string MerkleLeafHash,
    IReadOnlyDictionary<string, string> Metadata);
