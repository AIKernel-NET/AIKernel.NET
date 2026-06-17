using AIKernel.Enums;

namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// EN: Replay-addressable candidate movement from one Semantic IR/state artifact to another.
/// [EN] Documents this public package API member. [JA] SemanticTransitionDescriptor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.SemanticTransitionDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.SemanticTransitionDescriptor']" />
public sealed record SemanticTransitionDescriptor(
    string TransitionId,
    string FromIrId,
    string ToIrId,
    string? FromStateId,
    string? ToStateId,
    string? GovernedCircuitId,
    AdmissibilityDecisionKind? AdmissionDecision,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
