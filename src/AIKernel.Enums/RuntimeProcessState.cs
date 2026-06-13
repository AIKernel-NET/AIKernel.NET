namespace AIKernel.Enums;

/// <summary>
/// Describes a virtual process state.
/// JA: RuntimeProcessState の公開契約を定義します。
/// </summary>
public enum RuntimeProcessState
{
    /// <summary>The process state is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>The process has been created. JA: Created 値を表します。</summary>
    Created = 1,

    /// <summary>The process is running. JA: Running 値を表します。</summary>
    Running = 2,

    /// <summary>The process is suspended. JA: Suspended 値を表します。</summary>
    Suspended = 3,

    /// <summary>The process has exited. JA: Exited 値を表します。</summary>
    Exited = 4,

    /// <summary>The process failed. JA: Failed 値を表します。</summary>
    Failed = 5
}
