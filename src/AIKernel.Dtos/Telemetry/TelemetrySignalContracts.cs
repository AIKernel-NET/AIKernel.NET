using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Telemetry;

namespace AIKernel.Dtos.Telemetry;

/// <summary>
/// EN: Carries a telemetry snapshot request.
/// [EN] Documents this public package API member. [JA] TelemetrySnapshotRequest の公開契約を定義します。
/// </summary>
public sealed record TelemetrySnapshotRequest
{
    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>EN: Gets the telemetry level. JA: Level を取得します。</summary>
    public TelemetryLevel Level { get; init; } = TelemetryLevel.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a telemetry stream request.
/// [EN] Documents this public package API member. [JA] TelemetryStreamRequest の公開契約を定義します。
/// </summary>
public sealed record TelemetryStreamRequest
{
    /// <summary>EN: Gets the snapshot request template. JA: Snapshot を取得します。</summary>
    public TelemetrySnapshotRequest Snapshot { get; init; } = new();

    /// <summary>EN: Gets the requested interval. JA: Interval を取得します。</summary>
    public TimeSpan? Interval { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a telemetry snapshot.
/// [EN] Documents this public package API member. [JA] TelemetrySnapshot の公開契約を定義します。
/// </summary>
public sealed record TelemetrySnapshot
{
    /// <summary>EN: Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether snapshot capture succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>EN: Gets the telemetry level. JA: Level を取得します。</summary>
    public TelemetryLevel Level { get; init; } = TelemetryLevel.Unknown;

    /// <summary>EN: Gets telemetry signals. JA: Signals を取得します。</summary>
    public IReadOnlyList<TelemetrySignal> Signals { get; init; } = [];

    /// <summary>EN: Gets diagnostics emitted while building the snapshot. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets snapshot metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries one telemetry signal.
/// [EN] Documents this public package API member. [JA] TelemetrySignal の公開契約を定義します。
/// </summary>
public sealed record TelemetrySignal
{
    /// <summary>EN: Gets the signal identifier. JA: SignalId を取得します。</summary>
    public string SignalId { get; init; } = string.Empty;

    /// <summary>EN: Gets the signal kind. JA: Kind を取得します。</summary>
    public TelemetrySignalKind Kind { get; init; } = TelemetrySignalKind.Unknown;

    /// <summary>EN: Gets the signal value. JA: Value を取得します。</summary>
    public string Value { get; init; } = string.Empty;

    /// <summary>EN: Gets the signal confidence. JA: Confidence を取得します。</summary>
    public double? Confidence { get; init; }

    /// <summary>EN: Gets signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a telemetry signal catalog request.
/// [EN] Documents this public package API member. [JA] TelemetrySignalCatalogRequest の公開契約を定義します。
/// </summary>
public sealed record TelemetrySignalCatalogRequest
{
    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a telemetry signal catalog.
/// [EN] Documents this public package API member. [JA] TelemetrySignalCatalog の公開契約を定義します。
/// </summary>
public sealed record TelemetrySignalCatalog
{
    /// <summary>EN: Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets supported signal kinds. JA: SupportedSignals を取得します。</summary>
    public IReadOnlyList<TelemetrySignalKind> SupportedSignals { get; init; } = [];

    /// <summary>EN: Gets diagnostics emitted while describing signals. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a telemetry reset request.
/// [EN] Documents this public package API member. [JA] TelemetryResetRequest の公開契約を定義します。
/// </summary>
public sealed record TelemetryResetRequest
{
    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a telemetry reset result.
/// [EN] Documents this public package API member. [JA] TelemetryResetResult の公開契約を定義します。
/// </summary>
public sealed record TelemetryResetResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether reset succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets reset diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when reset was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
