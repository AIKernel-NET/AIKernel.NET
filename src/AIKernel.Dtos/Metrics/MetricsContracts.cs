using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Metrics;

namespace AIKernel.Dtos.Metrics;

/// <summary>
/// EN: Carries a metrics snapshot request.
/// [EN] Documents this public package API member. [JA] MetricsSnapshotRequest の公開契約を定義します。
/// </summary>
public sealed record MetricsSnapshotRequest
{
    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a metrics snapshot.
/// [EN] Documents this public package API member. [JA] MetricsSnapshot の公開契約を定義します。
/// </summary>
public sealed record MetricsSnapshot
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

    /// <summary>EN: Gets metric points. JA: Points を取得します。</summary>
    public IReadOnlyList<MetricPoint> Points { get; init; } = [];

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
/// EN: Carries one metric point.
/// [EN] Documents this public package API member. [JA] MetricPoint の公開契約を定義します。
/// </summary>
public sealed record MetricPoint
{
    /// <summary>EN: Gets the metric identifier. JA: MetricId を取得します。</summary>
    public string MetricId { get; init; } = string.Empty;

    /// <summary>EN: Gets the metric kind. JA: Kind を取得します。</summary>
    public MetricKind Kind { get; init; } = MetricKind.Unknown;

    /// <summary>EN: Gets the metric value. JA: Value を取得します。</summary>
    public double Value { get; init; }

    /// <summary>EN: Gets the metric unit. JA: Unit を取得します。</summary>
    public string? Unit { get; init; }

    /// <summary>EN: Gets aggregation kind. JA: Aggregation を取得します。</summary>
    public MetricAggregationKind Aggregation { get; init; } = MetricAggregationKind.Unknown;

    /// <summary>EN: Gets when the point was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets point metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a metric series.
/// [EN] Documents this public package API member. [JA] MetricSeries の公開契約を定義します。
/// </summary>
public sealed record MetricSeries
{
    /// <summary>EN: Gets the series identifier. JA: SeriesId を取得します。</summary>
    public string SeriesId { get; init; } = string.Empty;

    /// <summary>EN: Gets points in the series. JA: Points を取得します。</summary>
    public IReadOnlyList<MetricPoint> Points { get; init; } = [];

    /// <summary>EN: Gets series metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a metric series query.
/// [EN] Documents this public package API member. [JA] MetricSeriesQuery の公開契約を定義します。
/// </summary>
public sealed record MetricSeriesQuery
{
    /// <summary>EN: Gets the metric kind. JA: Kind を取得します。</summary>
    public MetricKind Kind { get; init; } = MetricKind.Unknown;

    /// <summary>EN: Gets the start time. JA: From を取得します。</summary>
    public DateTimeOffset? From { get; init; }

    /// <summary>EN: Gets the end time. JA: To を取得します。</summary>
    public DateTimeOffset? To { get; init; }

    /// <summary>EN: Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a metric catalog request.
/// [EN] Documents this public package API member. [JA] MetricCatalogRequest の公開契約を定義します。
/// </summary>
public sealed record MetricCatalogRequest
{
    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries supported metric kinds.
/// [EN] Documents this public package API member. [JA] MetricCatalog の公開契約を定義します。
/// </summary>
public sealed record MetricCatalog
{
    /// <summary>EN: Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets supported metric kinds. JA: SupportedMetrics を取得します。</summary>
    public IReadOnlyList<MetricKind> SupportedMetrics { get; init; } = [];

    /// <summary>EN: Gets diagnostics emitted while describing metrics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a metrics reset request.
/// [EN] Documents this public package API member. [JA] MetricsResetRequest の公開契約を定義します。
/// </summary>
public sealed record MetricsResetRequest
{
    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a metrics reset result.
/// [EN] Documents this public package API member. [JA] MetricsResetResult の公開契約を定義します。
/// </summary>
public sealed record MetricsResetResult
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
