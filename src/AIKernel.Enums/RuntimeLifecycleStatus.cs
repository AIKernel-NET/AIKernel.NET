namespace AIKernel.Enums;

/// <summary>
/// Describes a virtual runtime lifecycle state.
/// </summary>
public enum RuntimeLifecycleStatus
{
    /// <summary>The state is unknown.</summary>
    Unknown = 0,

    /// <summary>The runtime has not been initialized.</summary>
    NotInitialized = 1,

    /// <summary>The runtime is waiting for explicit consent.</summary>
    AwaitingConsent = 2,

    /// <summary>The runtime is preparing assets or models.</summary>
    Preparing = 3,

    /// <summary>The runtime is ready to start.</summary>
    Ready = 4,

    /// <summary>The runtime is running.</summary>
    Running = 5,

    /// <summary>The runtime has stopped.</summary>
    Stopped = 6,

    /// <summary>The runtime failed.</summary>
    Failed = 7
}
