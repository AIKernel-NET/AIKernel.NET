namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// Finite, closed set of verified governed circuits available to one compilation decision.
/// </summary>
public sealed record PrototypeSpaceDescriptor(
    string PrototypeSpaceId,
    IReadOnlyList<GovernedCircuitDescriptor> Circuits,
    string? Version,
    string? PrototypeSpaceHash,
    IReadOnlyDictionary<string, string> Metadata);
