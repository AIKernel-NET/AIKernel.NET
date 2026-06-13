namespace AIKernel.Enums;

/// <summary>
/// Describes a virtual process state.
/// </summary>
public enum RuntimeProcessState
{
    /// <summary>The process state is unknown.</summary>
    Unknown = 0,

    /// <summary>The process has been created.</summary>
    Created = 1,

    /// <summary>The process is running.</summary>
    Running = 2,

    /// <summary>The process is suspended.</summary>
    Suspended = 3,

    /// <summary>The process has exited.</summary>
    Exited = 4,

    /// <summary>The process failed.</summary>
    Failed = 5
}
