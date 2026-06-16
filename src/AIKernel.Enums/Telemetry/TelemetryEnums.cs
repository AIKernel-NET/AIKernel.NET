namespace AIKernel.Enums.Telemetry;

/// <summary>
/// EN: Describes telemetry signal kinds.
/// [EN] Documents this public package API member. [JA] TelemetrySignalKind の公開契約を定義します。
/// </summary>
public enum TelemetrySignalKind
{
    /// <summary>EN: Unknown telemetry signal. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Runtime state signal. JA: RuntimeState 値を表します。</summary>
    RuntimeState = 1,

    /// <summary>EN: Provider state signal. JA: ProviderState 値を表します。</summary>
    ProviderState = 2,

    /// <summary>EN: Process state signal. JA: ProcessState 値を表します。</summary>
    ProcessState = 3,

    /// <summary>EN: Control mode signal. JA: ControlMode 値を表します。</summary>
    ControlMode = 4,

    /// <summary>EN: Operator state signal. JA: OperatorState 値を表します。</summary>
    OperatorState = 5,

    /// <summary>EN: Safety signal. JA: Safety 値を表します。</summary>
    Safety = 6,

    /// <summary>EN: Backend signal. JA: Backend 値を表します。</summary>
    Backend = 7,

    /// <summary>EN: Operation status signal. JA: OperationStatus 値を表します。</summary>
    OperationStatus = 8
}

/// <summary>
/// EN: Describes telemetry level.
/// [EN] Documents this public package API member. [JA] TelemetryLevel の公開契約を定義します。
/// </summary>
public enum TelemetryLevel
{
    /// <summary>EN: Unknown telemetry level. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Minimal telemetry. JA: Minimal 値を表します。</summary>
    Minimal = 1,

    /// <summary>EN: Normal telemetry. JA: Normal 値を表します。</summary>
    Normal = 2,

    /// <summary>EN: Verbose telemetry. JA: Verbose 値を表します。</summary>
    Verbose = 3,

    /// <summary>EN: Diagnostic telemetry. JA: Diagnostic 値を表します。</summary>
    Diagnostic = 4
}
