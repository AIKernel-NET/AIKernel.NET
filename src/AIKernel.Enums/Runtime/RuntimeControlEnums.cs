namespace AIKernel.Enums.Runtime;

/// <summary>
/// EN: Describes how a runtime is attached.
/// EN: Documentation for public API. JA: RuntimeAttachmentMode の公開契約を定義します。
/// </summary>
public enum RuntimeAttachmentMode
{
    /// <summary>EN: Unknown attachment mode. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Create or attach automatically. JA: Automatic 値を表します。</summary>
    Automatic = 1,

    /// <summary>EN: Attach to an existing runtime. JA: Existing 値を表します。</summary>
    Existing = 2,

    /// <summary>EN: Create a fresh runtime. JA: New 値を表します。</summary>
    New = 3,

    /// <summary>EN: Attach read-only. JA: ReadOnly 値を表します。</summary>
    ReadOnly = 4
}

/// <summary>
/// EN: Describes runtime control operations.
/// EN: Documentation for public API. JA: RuntimeControlOperation の公開契約を定義します。
/// </summary>
public enum RuntimeControlOperation
{
    /// <summary>EN: Unknown runtime operation. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Start the runtime. JA: Start 値を表します。</summary>
    Start = 1,

    /// <summary>EN: Stop the runtime. JA: Stop 値を表します。</summary>
    Stop = 2,

    /// <summary>EN: Restart the runtime. JA: Restart 値を表します。</summary>
    Restart = 3,

    /// <summary>EN: Pause the runtime. JA: Pause 値を表します。</summary>
    Pause = 4,

    /// <summary>EN: Resume the runtime. JA: Resume 値を表します。</summary>
    Resume = 5
}

/// <summary>
/// EN: Describes runtime state.
/// EN: Documentation for public API. JA: RuntimeState の公開契約を定義します。
/// </summary>
public enum RuntimeState
{
    /// <summary>EN: Unknown runtime state. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: The runtime is not initialized. JA: NotInitialized 値を表します。</summary>
    NotInitialized = 1,

    /// <summary>EN: The runtime is starting. JA: Starting 値を表します。</summary>
    Starting = 2,

    /// <summary>EN: The runtime is running. JA: Running 値を表します。</summary>
    Running = 3,

    /// <summary>EN: The runtime is paused. JA: Paused 値を表します。</summary>
    Paused = 4,

    /// <summary>EN: The runtime is stopping. JA: Stopping 値を表します。</summary>
    Stopping = 5,

    /// <summary>EN: The runtime is stopped. JA: Stopped 値を表します。</summary>
    Stopped = 6,

    /// <summary>EN: The runtime has failed. JA: Failed 値を表します。</summary>
    Failed = 7
}

/// <summary>
/// EN: Describes runtime failure categories.
/// EN: Documentation for public API. JA: RuntimeFailureKind の公開契約を定義します。
/// </summary>
public enum RuntimeFailureKind
{
    /// <summary>EN: Unknown failure kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: No failure is present. JA: None 値を表します。</summary>
    None = 1,

    /// <summary>EN: Preparation failed. JA: PreparationFailed 値を表します。</summary>
    PreparationFailed = 2,

    /// <summary>EN: Permission was denied. JA: PermissionDenied 値を表します。</summary>
    PermissionDenied = 3,

    /// <summary>EN: An artifact was missing. JA: ArtifactMissing 値を表します。</summary>
    ArtifactMissing = 4,

    /// <summary>EN: The host capability is missing. JA: HostCapabilityMissing 値を表します。</summary>
    HostCapabilityMissing = 5,

    /// <summary>EN: An internal failure occurred. JA: InternalFailure 値を表します。</summary>
    InternalFailure = 6
}

/// <summary>
/// EN: Describes process control operations.
/// EN: Documentation for public API. JA: ProcessControlOperation の公開契約を定義します。
/// </summary>
public enum ProcessControlOperation
{
    /// <summary>EN: Unknown process operation. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Start a process. JA: Start 値を表します。</summary>
    Start = 1,

    /// <summary>EN: Stop a process. JA: Stop 値を表します。</summary>
    Stop = 2,

    /// <summary>EN: Kill a process. JA: Kill 値を表します。</summary>
    Kill = 3,

    /// <summary>EN: Suspend a process. JA: Suspend 値を表します。</summary>
    Suspend = 4,

    /// <summary>EN: Resume a process. JA: Resume 値を表します。</summary>
    Resume = 5,

    /// <summary>EN: Signal a process. JA: Signal 値を表します。</summary>
    Signal = 6
}

/// <summary>
/// EN: Describes process state.
/// EN: Documentation for public API. JA: ProcessStateKind の公開契約を定義します。
/// </summary>
public enum ProcessStateKind
{
    /// <summary>EN: Unknown process state. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: The process is created. JA: Created 値を表します。</summary>
    Created = 1,

    /// <summary>EN: The process is running. JA: Running 値を表します。</summary>
    Running = 2,

    /// <summary>EN: The process is suspended. JA: Suspended 値を表します。</summary>
    Suspended = 3,

    /// <summary>EN: The process exited. JA: Exited 値を表します。</summary>
    Exited = 4,

    /// <summary>EN: The process failed. JA: Failed 値を表します。</summary>
    Failed = 5
}

/// <summary>
/// EN: Describes portable process signals.
/// EN: Documentation for public API. JA: ProcessSignalKind の公開契約を定義します。
/// </summary>
public enum ProcessSignalKind
{
    /// <summary>EN: Unknown process signal. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Interrupt signal. JA: Interrupt 値を表します。</summary>
    Interrupt = 1,

    /// <summary>EN: Terminate signal. JA: Terminate 値を表します。</summary>
    Terminate = 2,

    /// <summary>EN: Kill signal. JA: Kill 値を表します。</summary>
    Kill = 3,

    /// <summary>EN: User-defined signal. JA: Custom 値を表します。</summary>
    Custom = 4
}
