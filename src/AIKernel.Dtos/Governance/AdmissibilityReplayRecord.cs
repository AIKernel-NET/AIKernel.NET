using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Replay-compatible evidence emitted by a pre-inference admissibility gate.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.AdmissibilityReplayRecord']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.AdmissibilityReplayRecord']" />
public sealed record AdmissibilityReplayRecord(
    string RecordId,
    string StepId,
    string? ParentStepId,
    AdmissibilityGateKind GateKind,
    SemanticIrSlot? Slot,
    AdmissibilityDecisionKind Decision,
    string? Reason,
    string? EvidenceHash,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
