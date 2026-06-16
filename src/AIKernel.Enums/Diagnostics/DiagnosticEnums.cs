namespace AIKernel.Enums.Diagnostics;

/// <summary>
/// EN: Describes diagnostic severity.
/// [EN] Documents this public package API member. [JA] DiagnosticSeverity の公開契約を定義します。
/// </summary>
public enum DiagnosticSeverity
{
    /// <summary>EN: Unknown severity. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Trace severity. JA: Trace 値を表します。</summary>
    Trace = 1,

    /// <summary>EN: Debug severity. JA: Debug 値を表します。</summary>
    Debug = 2,

    /// <summary>EN: Informational severity. JA: Info 値を表します。</summary>
    Info = 3,

    /// <summary>EN: Warning severity. JA: Warning 値を表します。</summary>
    Warning = 4,

    /// <summary>EN: Error severity. JA: Error 値を表します。</summary>
    Error = 5,

    /// <summary>EN: Critical severity. JA: Critical 値を表します。</summary>
    Critical = 6
}

/// <summary>
/// EN: Describes diagnostic scope.
/// [EN] Documents this public package API member. [JA] DiagnosticScope の公開契約を定義します。
/// </summary>
public enum DiagnosticScope
{
    /// <summary>EN: Unknown diagnostic scope. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Provider scope. JA: Provider 値を表します。</summary>
    Provider = 1,

    /// <summary>EN: Adapter scope. JA: Adapter 値を表します。</summary>
    Adapter = 2,

    /// <summary>EN: Runtime scope. JA: Runtime 値を表します。</summary>
    Runtime = 3,

    /// <summary>EN: Process scope. JA: Process 値を表します。</summary>
    Process = 4,

    /// <summary>EN: Frame scope. JA: Frame 値を表します。</summary>
    Frame = 5,

    /// <summary>EN: Perception scope. JA: Perception 値を表します。</summary>
    Perception = 6,

    /// <summary>EN: Operator scope. JA: Operator 値を表します。</summary>
    Operator = 7,

    /// <summary>EN: Governance scope. JA: Governance 値を表します。</summary>
    Governance = 8,

    /// <summary>EN: Replay scope. JA: Replay 値を表します。</summary>
    Replay = 9,

    /// <summary>EN: Evidence scope. JA: Evidence 値を表します。</summary>
    Evidence = 10,

    /// <summary>EN: Telemetry scope. JA: Telemetry 値を表します。</summary>
    Telemetry = 11,

    /// <summary>EN: Metrics scope. JA: Metrics 値を表します。</summary>
    Metrics = 12,

    /// <summary>EN: Host scope. JA: Host 値を表します。</summary>
    Host = 13
}
