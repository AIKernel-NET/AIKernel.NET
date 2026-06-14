using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Telemetry;

namespace AIKernel.Dtos.Telemetry;

/// <summary>
/// Carries a telemetry snapshot request.
/// JA: TelemetrySnapshotRequest の公開契約を定義します。
/// </summary>
public sealed record TelemetrySnapshotRequest
{
    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>Gets the telemetry level. JA: Level を取得します。</summary>
    public TelemetryLevel Level { get; init; } = TelemetryLevel.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a telemetry stream request.
/// JA: TelemetryStreamRequest の公開契約を定義します。
/// </summary>
public sealed record TelemetryStreamRequest
{
    /// <summary>Gets the snapshot request template. JA: Snapshot を取得します。</summary>
    public TelemetrySnapshotRequest Snapshot { get; init; } = new();

    /// <summary>Gets the requested interval. JA: Interval を取得します。</summary>
    public TimeSpan? Interval { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a telemetry snapshot.
/// JA: TelemetrySnapshot の公開契約を定義します。
/// </summary>
public sealed record TelemetrySnapshot
{
    /// <summary>Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>Gets whether snapshot capture succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>Gets the telemetry level. JA: Level を取得します。</summary>
    public TelemetryLevel Level { get; init; } = TelemetryLevel.Unknown;

    /// <summary>Gets telemetry signals. JA: Signals を取得します。</summary>
    public IReadOnlyList<TelemetrySignal> Signals { get; init; } = [];

    /// <summary>Gets diagnostics emitted while building the snapshot. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets snapshot metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries one telemetry signal.
/// JA: TelemetrySignal の公開契約を定義します。
/// </summary>
public sealed record TelemetrySignal
{
    /// <summary>Gets the signal identifier. JA: SignalId を取得します。</summary>
    public string SignalId { get; init; } = string.Empty;

    /// <summary>Gets the signal kind. JA: Kind を取得します。</summary>
    public TelemetrySignalKind Kind { get; init; } = TelemetrySignalKind.Unknown;

    /// <summary>Gets the signal value. JA: Value を取得します。</summary>
    public string Value { get; init; } = string.Empty;

    /// <summary>Gets the signal confidence. JA: Confidence を取得します。</summary>
    public double? Confidence { get; init; }

    /// <summary>Gets signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a telemetry signal catalog request.
/// JA: TelemetrySignalCatalogRequest の公開契約を定義します。
/// </summary>
public sealed record TelemetrySignalCatalogRequest
{
    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a telemetry signal catalog.
/// JA: TelemetrySignalCatalog の公開契約を定義します。
/// </summary>
public sealed record TelemetrySignalCatalog
{
    /// <summary>Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets supported signal kinds. JA: SupportedSignals を取得します。</summary>
    public IReadOnlyList<TelemetrySignalKind> SupportedSignals { get; init; } = [];

    /// <summary>Gets diagnostics emitted while describing signals. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a telemetry reset request.
/// JA: TelemetryResetRequest の公開契約を定義します。
/// </summary>
public sealed record TelemetryResetRequest
{
    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a telemetry reset result.
/// JA: TelemetryResetResult の公開契約を定義します。
/// </summary>
public sealed record TelemetryResetResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether reset succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets reset diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when reset was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
