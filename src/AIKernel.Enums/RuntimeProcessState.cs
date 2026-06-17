namespace AIKernel.Enums;

/// <summary>
/// EN: Describes a virtual process state.
/// [EN] Documents this public package API member. [JA] RuntimeProcessState の公開契約を定義します。
/// </summary>
public enum RuntimeProcessState
{
    /// <summary>EN: The process state is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: The process has been created. JA: Created 値を表します。</summary>
    Created = 1,

    /// <summary>EN: The process is running. JA: Running 値を表します。</summary>
    Running = 2,

    /// <summary>EN: The process is suspended. JA: Suspended 値を表します。</summary>
    Suspended = 3,

    /// <summary>EN: The process has exited. JA: Exited 値を表します。</summary>
    Exited = 4,

    /// <summary>EN: The process failed. JA: Failed 値を表します。</summary>
    Failed = 5
}
