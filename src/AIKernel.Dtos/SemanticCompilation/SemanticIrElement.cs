namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// EN: Four-slot Semantic IR element: graph topology, transition shape, constraints, and boundary invariants.
/// [EN] Documents this public package API member. [JA] SemanticIrElement の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.SemanticIrElement']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.SemanticIrElement']" />
public sealed record SemanticIrElement(
    string IrId,
    string GraphTopology,
    string TransitionShape,
    string ConstraintSet,
    string BoundaryInvariants,
    string? AssociatedSemanticStateId,
    IReadOnlyDictionary<string, string> Metadata);
