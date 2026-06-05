namespace AIKernel.Enums;

/// <summary>
/// Defines normalized outcomes for semantic admissibility checks.
/// </summary>
public enum AdmissibilityDecisionKind
{
    Unknown = 0,
    Admit = 1,
    Deny = 2,
    SuspendForApproval = 3,
    Clarify = 4,
    ReadOnly = 5,
    Delegate = 6,
    Quarantine = 7
}
