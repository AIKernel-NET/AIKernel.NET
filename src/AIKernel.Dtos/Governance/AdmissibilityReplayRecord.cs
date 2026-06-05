using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Replay-compatible evidence emitted by a pre-inference admissibility gate.
/// </summary>
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
