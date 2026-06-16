using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// EN: Replay-compatible evidence emitted by a pre-inference admissibility gate.
/// EN: Documentation for public API. JA: AdmissibilityReplayRecord の公開契約を定義します。
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
