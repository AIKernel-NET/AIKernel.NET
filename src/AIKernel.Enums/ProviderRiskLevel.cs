namespace AIKernel.Enums;

/// <summary>
/// Describes provider capability risk level.
/// </summary>
public enum ProviderRiskLevel
{
    /// <summary>Risk is unknown.</summary>
    Unknown = 0,

    /// <summary>Read-only or observation-only capability.</summary>
    ReadOnly = 1,

    /// <summary>Low-risk bounded capability.</summary>
    Low = 2,

    /// <summary>Medium-risk capability requiring policy review.</summary>
    Medium = 3,

    /// <summary>High-risk capability requiring explicit governance approval.</summary>
    High = 4,

    /// <summary>Privileged capability with external side effects.</summary>
    Privileged = 5
}
