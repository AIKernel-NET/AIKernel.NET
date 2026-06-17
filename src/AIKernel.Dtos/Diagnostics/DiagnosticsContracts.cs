using AIKernel.Enums.Diagnostics;

namespace AIKernel.Dtos.Diagnostics;

/// <summary>
/// EN: Carries a portable diagnostic entry.
/// [EN] Documents this public package API member. [JA] DiagnosticEntry の公開契約を定義します。
/// </summary>
public sealed record DiagnosticEntry
{
    /// <summary>EN: Gets the diagnostic identifier. JA: DiagnosticId を取得します。</summary>
    public string DiagnosticId { get; init; } = string.Empty;

    /// <summary>EN: Gets the stable diagnostic code. JA: Code を取得します。</summary>
    public string Code { get; init; } = string.Empty;

    /// <summary>EN: Gets the diagnostic message. JA: Message を取得します。</summary>
    public string Message { get; init; } = string.Empty;

    /// <summary>EN: Gets the diagnostic severity. JA: Severity を取得します。</summary>
    public DiagnosticSeverity Severity { get; init; } = DiagnosticSeverity.Unknown;

    /// <summary>EN: Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>EN: Gets when the diagnostic was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets diagnostic metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries diagnostic details for result and snapshot DTOs.
/// [EN] Documents this public package API member. [JA] DiagnosticInfo の公開契約を定義します。
/// </summary>
public sealed record DiagnosticInfo
{
    /// <summary>EN: Gets diagnostic entries. JA: Entries を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Entries { get; init; } = [];

    /// <summary>EN: Gets diagnostic metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a diagnostics snapshot request.
/// [EN] Documents this public package API member. [JA] DiagnosticSnapshotRequest の公開契約を定義します。
/// </summary>
public sealed record DiagnosticSnapshotRequest
{
    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a diagnostics snapshot.
/// [EN] Documents this public package API member. [JA] DiagnosticSnapshot の公開契約を定義します。
/// </summary>
public sealed record DiagnosticSnapshot
{
    /// <summary>EN: Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether the snapshot was captured successfully. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic entries. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets snapshot metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a diagnostic query.
/// [EN] Documents this public package API member. [JA] DiagnosticQuery の公開契約を定義します。
/// </summary>
public sealed record DiagnosticQuery
{
    /// <summary>EN: Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>EN: Gets the minimum severity. JA: MinimumSeverity を取得します。</summary>
    public DiagnosticSeverity MinimumSeverity { get; init; } = DiagnosticSeverity.Unknown;

    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets the maximum number of entries. JA: Limit を取得します。</summary>
    public int? Limit { get; init; }

    /// <summary>EN: Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a diagnostic clear request.
/// [EN] Documents this public package API member. [JA] DiagnosticClearRequest の公開契約を定義します。
/// </summary>
public sealed record DiagnosticClearRequest
{
    /// <summary>EN: Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets clear metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a diagnostic clear result.
/// [EN] Documents this public package API member. [JA] DiagnosticClearResult の公開契約を定義します。
/// </summary>
public sealed record DiagnosticClearResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether clear succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the number of cleared entries. JA: ClearedCount を取得します。</summary>
    public int ClearedCount { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostics produced by the clear operation. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when the operation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a diagnostic key catalog request.
/// [EN] Documents this public package API member. [JA] DiagnosticKeyDescribeRequest の公開契約を定義します。
/// </summary>
public sealed record DiagnosticKeyDescribeRequest
{
    /// <summary>EN: Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries known diagnostic keys.
/// [EN] Documents this public package API member. [JA] DiagnosticKeyCatalog の公開契約を定義します。
/// </summary>
public sealed record DiagnosticKeyCatalog
{
    /// <summary>EN: Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets known diagnostic keys. JA: Keys を取得します。</summary>
    public IReadOnlyList<string> Keys { get; init; } = [];

    /// <summary>EN: Gets diagnostics emitted while describing the catalog. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
