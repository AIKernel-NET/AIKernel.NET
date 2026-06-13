namespace AIKernel.Enums;

/// <summary>
/// Describes the maximum side-effect mode allowed for a runtime loop.
/// </summary>
public enum RuntimeControlMode
{
    /// <summary>Normal governed runtime operation.</summary>
    Normal = 0,

    /// <summary>Observation is allowed but input execution is blocked.</summary>
    ObserveOnly = 1,

    /// <summary>Manual movement or input override is allowed.</summary>
    ManualOverride = 2,

    /// <summary>Assisted governed control is allowed.</summary>
    AssistedControl = 3,

    /// <summary>Replay-only operation is allowed.</summary>
    ReplayOnly = 4
}
