namespace AIKernel.Dtos.Hatl;

/// <summary>EN: Documentation for public API. JA: HatlRatchetStepResult を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlRatchetStepResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlRatchetStepResult']" />
public sealed record HatlRatchetStepResult(
    string DerivationAlgorithm,
    string NextKeyCommitment,
    IReadOnlyDictionary<string, string> Metadata);
