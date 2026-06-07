namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// Pre-verified semantic execution topology selected from a finite prototype space.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.GovernedCircuitDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.GovernedCircuitDescriptor']" />
public sealed record GovernedCircuitDescriptor(
    string CircuitId,
    SemanticIrElement Ir,
    string RuntimePolicyId,
    IReadOnlyList<string> CapabilityRequirements,
    IReadOnlyList<string> BoundaryInvariants,
    string? PrototypeSpaceId,
    IReadOnlyDictionary<string, string> Metadata);
