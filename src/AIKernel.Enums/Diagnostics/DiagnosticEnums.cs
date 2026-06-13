namespace AIKernel.Enums.Diagnostics;

/// <summary>
/// Describes diagnostic severity.
/// JA: DiagnosticSeverity の公開契約を定義します。
/// </summary>
public enum DiagnosticSeverity
{
    /// <summary>Unknown severity. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Trace severity. JA: Trace 値を表します。</summary>
    Trace = 1,

    /// <summary>Debug severity. JA: Debug 値を表します。</summary>
    Debug = 2,

    /// <summary>Informational severity. JA: Info 値を表します。</summary>
    Info = 3,

    /// <summary>Warning severity. JA: Warning 値を表します。</summary>
    Warning = 4,

    /// <summary>Error severity. JA: Error 値を表します。</summary>
    Error = 5,

    /// <summary>Critical severity. JA: Critical 値を表します。</summary>
    Critical = 6
}

/// <summary>
/// Describes diagnostic scope.
/// JA: DiagnosticScope の公開契約を定義します。
/// </summary>
public enum DiagnosticScope
{
    /// <summary>Unknown diagnostic scope. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Provider scope. JA: Provider 値を表します。</summary>
    Provider = 1,

    /// <summary>Adapter scope. JA: Adapter 値を表します。</summary>
    Adapter = 2,

    /// <summary>Runtime scope. JA: Runtime 値を表します。</summary>
    Runtime = 3,

    /// <summary>Process scope. JA: Process 値を表します。</summary>
    Process = 4,

    /// <summary>Frame scope. JA: Frame 値を表します。</summary>
    Frame = 5,

    /// <summary>Perception scope. JA: Perception 値を表します。</summary>
    Perception = 6,

    /// <summary>Operator scope. JA: Operator 値を表します。</summary>
    Operator = 7,

    /// <summary>Governance scope. JA: Governance 値を表します。</summary>
    Governance = 8,

    /// <summary>Replay scope. JA: Replay 値を表します。</summary>
    Replay = 9,

    /// <summary>Evidence scope. JA: Evidence 値を表します。</summary>
    Evidence = 10,

    /// <summary>Telemetry scope. JA: Telemetry 値を表します。</summary>
    Telemetry = 11,

    /// <summary>Metrics scope. JA: Metrics 値を表します。</summary>
    Metrics = 12,

    /// <summary>Host scope. JA: Host 値を表します。</summary>
    Host = 13
}
