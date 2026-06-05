namespace AIKernel.Enums;

/// <summary>
/// Required mitigation attached before a critical operation may execute.
/// </summary>
public enum CriticalOperationRequirement
{
    Unknown = 0,
    HumanApproval = 1,
    Sandbox = 2,
    Snapshot = 3,
    ReadOnly = 4,
    RestrictScope = 5,
    NoExecution = 6,
    ReplayRequired = 7
}
