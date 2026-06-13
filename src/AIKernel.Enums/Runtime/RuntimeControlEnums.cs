namespace AIKernel.Enums.Runtime;

/// <summary>
/// Describes how a runtime is attached.
/// JA: RuntimeAttachmentMode の公開契約を定義します。
/// </summary>
public enum RuntimeAttachmentMode
{
    /// <summary>Unknown attachment mode. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Create or attach automatically. JA: Automatic 値を表します。</summary>
    Automatic = 1,

    /// <summary>Attach to an existing runtime. JA: Existing 値を表します。</summary>
    Existing = 2,

    /// <summary>Create a fresh runtime. JA: New 値を表します。</summary>
    New = 3,

    /// <summary>Attach read-only. JA: ReadOnly 値を表します。</summary>
    ReadOnly = 4
}

/// <summary>
/// Describes runtime control operations.
/// JA: RuntimeControlOperation の公開契約を定義します。
/// </summary>
public enum RuntimeControlOperation
{
    /// <summary>Unknown runtime operation. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Start the runtime. JA: Start 値を表します。</summary>
    Start = 1,

    /// <summary>Stop the runtime. JA: Stop 値を表します。</summary>
    Stop = 2,

    /// <summary>Restart the runtime. JA: Restart 値を表します。</summary>
    Restart = 3,

    /// <summary>Pause the runtime. JA: Pause 値を表します。</summary>
    Pause = 4,

    /// <summary>Resume the runtime. JA: Resume 値を表します。</summary>
    Resume = 5
}

/// <summary>
/// Describes runtime state.
/// JA: RuntimeState の公開契約を定義します。
/// </summary>
public enum RuntimeState
{
    /// <summary>Unknown runtime state. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>The runtime is not initialized. JA: NotInitialized 値を表します。</summary>
    NotInitialized = 1,

    /// <summary>The runtime is starting. JA: Starting 値を表します。</summary>
    Starting = 2,

    /// <summary>The runtime is running. JA: Running 値を表します。</summary>
    Running = 3,

    /// <summary>The runtime is paused. JA: Paused 値を表します。</summary>
    Paused = 4,

    /// <summary>The runtime is stopping. JA: Stopping 値を表します。</summary>
    Stopping = 5,

    /// <summary>The runtime is stopped. JA: Stopped 値を表します。</summary>
    Stopped = 6,

    /// <summary>The runtime has failed. JA: Failed 値を表します。</summary>
    Failed = 7
}

/// <summary>
/// Describes runtime failure categories.
/// JA: RuntimeFailureKind の公開契約を定義します。
/// </summary>
public enum RuntimeFailureKind
{
    /// <summary>Unknown failure kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>No failure is present. JA: None 値を表します。</summary>
    None = 1,

    /// <summary>Preparation failed. JA: PreparationFailed 値を表します。</summary>
    PreparationFailed = 2,

    /// <summary>Permission was denied. JA: PermissionDenied 値を表します。</summary>
    PermissionDenied = 3,

    /// <summary>An artifact was missing. JA: ArtifactMissing 値を表します。</summary>
    ArtifactMissing = 4,

    /// <summary>The host capability is missing. JA: HostCapabilityMissing 値を表します。</summary>
    HostCapabilityMissing = 5,

    /// <summary>An internal failure occurred. JA: InternalFailure 値を表します。</summary>
    InternalFailure = 6
}

/// <summary>
/// Describes process control operations.
/// JA: ProcessControlOperation の公開契約を定義します。
/// </summary>
public enum ProcessControlOperation
{
    /// <summary>Unknown process operation. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Start a process. JA: Start 値を表します。</summary>
    Start = 1,

    /// <summary>Stop a process. JA: Stop 値を表します。</summary>
    Stop = 2,

    /// <summary>Kill a process. JA: Kill 値を表します。</summary>
    Kill = 3,

    /// <summary>Suspend a process. JA: Suspend 値を表します。</summary>
    Suspend = 4,

    /// <summary>Resume a process. JA: Resume 値を表します。</summary>
    Resume = 5,

    /// <summary>Signal a process. JA: Signal 値を表します。</summary>
    Signal = 6
}

/// <summary>
/// Describes process state.
/// JA: ProcessStateKind の公開契約を定義します。
/// </summary>
public enum ProcessStateKind
{
    /// <summary>Unknown process state. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>The process is created. JA: Created 値を表します。</summary>
    Created = 1,

    /// <summary>The process is running. JA: Running 値を表します。</summary>
    Running = 2,

    /// <summary>The process is suspended. JA: Suspended 値を表します。</summary>
    Suspended = 3,

    /// <summary>The process exited. JA: Exited 値を表します。</summary>
    Exited = 4,

    /// <summary>The process failed. JA: Failed 値を表します。</summary>
    Failed = 5
}

/// <summary>
/// Describes portable process signals.
/// JA: ProcessSignalKind の公開契約を定義します。
/// </summary>
public enum ProcessSignalKind
{
    /// <summary>Unknown process signal. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Interrupt signal. JA: Interrupt 値を表します。</summary>
    Interrupt = 1,

    /// <summary>Terminate signal. JA: Terminate 値を表します。</summary>
    Terminate = 2,

    /// <summary>Kill signal. JA: Kill 値を表します。</summary>
    Kill = 3,

    /// <summary>User-defined signal. JA: Custom 値を表します。</summary>
    Custom = 4
}
