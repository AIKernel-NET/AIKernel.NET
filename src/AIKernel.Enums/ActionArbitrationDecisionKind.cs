namespace AIKernel.Enums;

/// <summary>
/// Describes an operator action arbitration outcome.
/// </summary>
public enum ActionArbitrationDecisionKind
{
    /// <summary>No decision was made.</summary>
    None = 0,

    /// <summary>The proposal is approved for governance review or execution.</summary>
    Approve = 1,

    /// <summary>The proposal is denied.</summary>
    Deny = 2,

    /// <summary>The proposal requires clarification.</summary>
    Clarify = 3,

    /// <summary>The proposal is conditionally approved.</summary>
    Conditional = 4
}
