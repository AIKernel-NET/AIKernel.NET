namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// Contract-only descriptor for materialized artifacts produced after a governed circuit is selected.
/// </summary>
public sealed record DeterministicSynthesisDescriptor(
    string SynthesisId,
    string SourceIrId,
    string GovernedCircuitId,
    IReadOnlyList<string> ArtifactReferences,
    string? RuntimePolicyId,
    string? ReplayConfigurationHash,
    IReadOnlyDictionary<string, string> Metadata);
