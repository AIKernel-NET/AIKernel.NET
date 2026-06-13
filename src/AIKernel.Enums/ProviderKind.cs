namespace AIKernel.Enums;

/// <summary>
/// Classifies a provider by its architectural responsibility.
/// </summary>
public enum ProviderKind
{
    /// <summary>Provider kind is not specified.</summary>
    Unknown = 0,

    /// <summary>Side-effecting provider boundary.</summary>
    Provider = 1,

    /// <summary>Read-only observation and evidence boundary.</summary>
    Observer = 2,

    /// <summary>Bounded action-proposal boundary.</summary>
    Operator = 3,

    /// <summary>Governance-approved input execution boundary.</summary>
    ActionProvider = 4
}
