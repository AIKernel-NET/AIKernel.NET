using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Metrics;

namespace AIKernel.Dtos.Metrics;

/// <summary>
/// Carries a metrics snapshot request.
/// JA: MetricsSnapshotRequest の公開契約を定義します。
/// </summary>
public sealed record MetricsSnapshotRequest
{
    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a metrics snapshot.
/// JA: MetricsSnapshot の公開契約を定義します。
/// </summary>
public sealed record MetricsSnapshot
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

    /// <summary>Gets metric points. JA: Points を取得します。</summary>
    public IReadOnlyList<MetricPoint> Points { get; init; } = [];

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
/// Carries one metric point.
/// JA: MetricPoint の公開契約を定義します。
/// </summary>
public sealed record MetricPoint
{
    /// <summary>Gets the metric identifier. JA: MetricId を取得します。</summary>
    public string MetricId { get; init; } = string.Empty;

    /// <summary>Gets the metric kind. JA: Kind を取得します。</summary>
    public MetricKind Kind { get; init; } = MetricKind.Unknown;

    /// <summary>Gets the metric value. JA: Value を取得します。</summary>
    public double Value { get; init; }

    /// <summary>Gets the metric unit. JA: Unit を取得します。</summary>
    public string? Unit { get; init; }

    /// <summary>Gets aggregation kind. JA: Aggregation を取得します。</summary>
    public MetricAggregationKind Aggregation { get; init; } = MetricAggregationKind.Unknown;

    /// <summary>Gets when the point was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets point metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a metric series.
/// JA: MetricSeries の公開契約を定義します。
/// </summary>
public sealed record MetricSeries
{
    /// <summary>Gets the series identifier. JA: SeriesId を取得します。</summary>
    public string SeriesId { get; init; } = string.Empty;

    /// <summary>Gets points in the series. JA: Points を取得します。</summary>
    public IReadOnlyList<MetricPoint> Points { get; init; } = [];

    /// <summary>Gets series metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a metric series query.
/// JA: MetricSeriesQuery の公開契約を定義します。
/// </summary>
public sealed record MetricSeriesQuery
{
    /// <summary>Gets the metric kind. JA: Kind を取得します。</summary>
    public MetricKind Kind { get; init; } = MetricKind.Unknown;

    /// <summary>Gets the start time. JA: From を取得します。</summary>
    public DateTimeOffset? From { get; init; }

    /// <summary>Gets the end time. JA: To を取得します。</summary>
    public DateTimeOffset? To { get; init; }

    /// <summary>Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a metric catalog request.
/// JA: MetricCatalogRequest の公開契約を定義します。
/// </summary>
public sealed record MetricCatalogRequest
{
    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries supported metric kinds.
/// JA: MetricCatalog の公開契約を定義します。
/// </summary>
public sealed record MetricCatalog
{
    /// <summary>Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets supported metric kinds. JA: SupportedMetrics を取得します。</summary>
    public IReadOnlyList<MetricKind> SupportedMetrics { get; init; } = [];

    /// <summary>Gets diagnostics emitted while describing metrics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a metrics reset request.
/// JA: MetricsResetRequest の公開契約を定義します。
/// </summary>
public sealed record MetricsResetRequest
{
    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a metrics reset result.
/// JA: MetricsResetResult の公開契約を定義します。
/// </summary>
public sealed record MetricsResetResult
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
