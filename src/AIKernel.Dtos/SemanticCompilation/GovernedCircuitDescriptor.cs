namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// Pre-verified semantic execution topology selected from a finite prototype space.
/// </summary>
public sealed record GovernedCircuitDescriptor(
    string CircuitId,
    SemanticIrElement Ir,
    string RuntimePolicyId,
    IReadOnlyList<string> CapabilityRequirements,
    IReadOnlyList<string> BoundaryInvariants,
    string? PrototypeSpaceId,
    IReadOnlyDictionary<string, string> Metadata);
