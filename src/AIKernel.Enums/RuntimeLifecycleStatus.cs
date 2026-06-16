namespace AIKernel.Enums;

/// <summary>
/// EN: Describes a virtual runtime lifecycle state.
/// EN: Documentation for public API. JA: RuntimeLifecycleStatus の公開契約を定義します。
/// </summary>
public enum RuntimeLifecycleStatus
{
    /// <summary>EN: The state is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: The runtime has not been initialized. JA: NotInitialized 値を表します。</summary>
    NotInitialized = 1,

    /// <summary>EN: The runtime is waiting for explicit consent. JA: AwaitingConsent 値を表します。</summary>
    AwaitingConsent = 2,

    /// <summary>EN: The runtime is preparing assets or models. JA: Preparing 値を表します。</summary>
    Preparing = 3,

    /// <summary>EN: The runtime is ready to start. JA: Ready 値を表します。</summary>
    Ready = 4,

    /// <summary>EN: The runtime is running. JA: Running 値を表します。</summary>
    Running = 5,

    /// <summary>EN: The runtime has stopped. JA: Stopped 値を表します。</summary>
    Stopped = 6,

    /// <summary>EN: The runtime failed. JA: Failed 値を表します。</summary>
    Failed = 7
}
