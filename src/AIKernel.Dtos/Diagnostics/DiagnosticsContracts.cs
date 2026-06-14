using AIKernel.Enums.Diagnostics;

namespace AIKernel.Dtos.Diagnostics;

/// <summary>
/// Carries a portable diagnostic entry.
/// JA: DiagnosticEntry の公開契約を定義します。
/// </summary>
public sealed record DiagnosticEntry
{
    /// <summary>Gets the diagnostic identifier. JA: DiagnosticId を取得します。</summary>
    public string DiagnosticId { get; init; } = string.Empty;

    /// <summary>Gets the stable diagnostic code. JA: Code を取得します。</summary>
    public string Code { get; init; } = string.Empty;

    /// <summary>Gets the diagnostic message. JA: Message を取得します。</summary>
    public string Message { get; init; } = string.Empty;

    /// <summary>Gets the diagnostic severity. JA: Severity を取得します。</summary>
    public DiagnosticSeverity Severity { get; init; } = DiagnosticSeverity.Unknown;

    /// <summary>Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>Gets when the diagnostic was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets diagnostic metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries diagnostic details for result and snapshot DTOs.
/// JA: DiagnosticInfo の公開契約を定義します。
/// </summary>
public sealed record DiagnosticInfo
{
    /// <summary>Gets diagnostic entries. JA: Entries を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Entries { get; init; } = [];

    /// <summary>Gets diagnostic metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a diagnostics snapshot request.
/// JA: DiagnosticSnapshotRequest の公開契約を定義します。
/// </summary>
public sealed record DiagnosticSnapshotRequest
{
    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a diagnostics snapshot.
/// JA: DiagnosticSnapshot の公開契約を定義します。
/// </summary>
public sealed record DiagnosticSnapshot
{
    /// <summary>Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>Gets whether the snapshot was captured successfully. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets diagnostic entries. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets snapshot metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a diagnostic query.
/// JA: DiagnosticQuery の公開契約を定義します。
/// </summary>
public sealed record DiagnosticQuery
{
    /// <summary>Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>Gets the minimum severity. JA: MinimumSeverity を取得します。</summary>
    public DiagnosticSeverity MinimumSeverity { get; init; } = DiagnosticSeverity.Unknown;

    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets the maximum number of entries. JA: Limit を取得します。</summary>
    public int? Limit { get; init; }

    /// <summary>Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a diagnostic clear request.
/// JA: DiagnosticClearRequest の公開契約を定義します。
/// </summary>
public sealed record DiagnosticClearRequest
{
    /// <summary>Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets clear metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a diagnostic clear result.
/// JA: DiagnosticClearResult の公開契約を定義します。
/// </summary>
public sealed record DiagnosticClearResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether clear succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the number of cleared entries. JA: ClearedCount を取得します。</summary>
    public int ClearedCount { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets diagnostics produced by the clear operation. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when the operation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a diagnostic key catalog request.
/// JA: DiagnosticKeyDescribeRequest の公開契約を定義します。
/// </summary>
public sealed record DiagnosticKeyDescribeRequest
{
    /// <summary>Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries known diagnostic keys.
/// JA: DiagnosticKeyCatalog の公開契約を定義します。
/// </summary>
public sealed record DiagnosticKeyCatalog
{
    /// <summary>Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets known diagnostic keys. JA: Keys を取得します。</summary>
    public IReadOnlyList<string> Keys { get; init; } = [];

    /// <summary>Gets diagnostics emitted while describing the catalog. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
