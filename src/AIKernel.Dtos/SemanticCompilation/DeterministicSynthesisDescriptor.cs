namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// EN: Contract-only descriptor for materialized artifacts produced after a governed circuit is selected.
/// EN: Documentation for public API. JA: DeterministicSynthesisDescriptor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.DeterministicSynthesisDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.DeterministicSynthesisDescriptor']" />
public sealed record DeterministicSynthesisDescriptor(
    string SynthesisId,
    string SourceIrId,
    string GovernedCircuitId,
    IReadOnlyList<string> ArtifactReferences,
    string? RuntimePolicyId,
    string? ReplayConfigurationHash,
    IReadOnlyDictionary<string, string> Metadata);
