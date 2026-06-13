namespace AIKernel.Enums.Telemetry;

/// <summary>
/// Describes telemetry signal kinds.
/// JA: TelemetrySignalKind の公開契約を定義します。
/// </summary>
public enum TelemetrySignalKind
{
    /// <summary>Unknown telemetry signal. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Runtime state signal. JA: RuntimeState 値を表します。</summary>
    RuntimeState = 1,

    /// <summary>Provider state signal. JA: ProviderState 値を表します。</summary>
    ProviderState = 2,

    /// <summary>Process state signal. JA: ProcessState 値を表します。</summary>
    ProcessState = 3,

    /// <summary>Control mode signal. JA: ControlMode 値を表します。</summary>
    ControlMode = 4,

    /// <summary>Operator state signal. JA: OperatorState 値を表します。</summary>
    OperatorState = 5,

    /// <summary>Safety signal. JA: Safety 値を表します。</summary>
    Safety = 6,

    /// <summary>Backend signal. JA: Backend 値を表します。</summary>
    Backend = 7,

    /// <summary>Operation status signal. JA: OperationStatus 値を表します。</summary>
    OperationStatus = 8
}

/// <summary>
/// Describes telemetry level.
/// JA: TelemetryLevel の公開契約を定義します。
/// </summary>
public enum TelemetryLevel
{
    /// <summary>Unknown telemetry level. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Minimal telemetry. JA: Minimal 値を表します。</summary>
    Minimal = 1,

    /// <summary>Normal telemetry. JA: Normal 値を表します。</summary>
    Normal = 2,

    /// <summary>Verbose telemetry. JA: Verbose 値を表します。</summary>
    Verbose = 3,

    /// <summary>Diagnostic telemetry. JA: Diagnostic 値を表します。</summary>
    Diagnostic = 4
}
