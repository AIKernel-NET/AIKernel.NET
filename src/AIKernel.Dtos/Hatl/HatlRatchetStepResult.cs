namespace AIKernel.Dtos.Hatl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlRatchetStepResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlRatchetStepResult']" />
public sealed record HatlRatchetStepResult(
    string DerivationAlgorithm,
    string NextKeyCommitment,
    IReadOnlyDictionary<string, string> Metadata);
