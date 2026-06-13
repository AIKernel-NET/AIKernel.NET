namespace AIKernel.Enums;

/// <summary>
/// Describes a policy decision category.
/// </summary>
public enum PolicyDecisionKind
{
    /// <summary>No decision was made.</summary>
    None = 0,

    /// <summary>The request is allowed.</summary>
    Allow = 1,

    /// <summary>The request is denied.</summary>
    Deny = 2,

    /// <summary>The request needs clarification.</summary>
    Clarify = 3,

    /// <summary>The request is conditionally allowed.</summary>
    Conditional = 4
}
