namespace AIKernel.Enums;

/// <summary>
/// Describes a virtual runtime lifecycle state.
/// JA: RuntimeLifecycleStatus の公開契約を定義します。
/// </summary>
public enum RuntimeLifecycleStatus
{
    /// <summary>The state is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>The runtime has not been initialized. JA: NotInitialized 値を表します。</summary>
    NotInitialized = 1,

    /// <summary>The runtime is waiting for explicit consent. JA: AwaitingConsent 値を表します。</summary>
    AwaitingConsent = 2,

    /// <summary>The runtime is preparing assets or models. JA: Preparing 値を表します。</summary>
    Preparing = 3,

    /// <summary>The runtime is ready to start. JA: Ready 値を表します。</summary>
    Ready = 4,

    /// <summary>The runtime is running. JA: Running 値を表します。</summary>
    Running = 5,

    /// <summary>The runtime has stopped. JA: Stopped 値を表します。</summary>
    Stopped = 6,

    /// <summary>The runtime failed. JA: Failed 値を表します。</summary>
    Failed = 7
}
