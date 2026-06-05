namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// Four-slot Semantic IR element: graph topology, transition shape, constraints, and boundary invariants.
/// </summary>
public sealed record SemanticIrElement(
    string IrId,
    string GraphTopology,
    string TransitionShape,
    string ConstraintSet,
    string BoundaryInvariants,
    string? AssociatedSemanticStateId,
    IReadOnlyDictionary<string, string> Metadata);
