using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Diagnostics;
using AIKernel.Enums.Observability;

namespace AIKernel.Dtos.Observability;

/// <summary>
/// Carries an evidence capture request.
/// JA: EvidenceCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceCaptureRequest
{
    /// <summary>Gets the evidence request identifier. JA: RequestId を取得します。</summary>
    public string RequestId { get; init; } = string.Empty;

    /// <summary>Gets the capture mode. JA: Mode を取得します。</summary>
    public EvidenceCaptureMode Mode { get; init; } = EvidenceCaptureMode.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a frame evidence capture request.
/// JA: EvidenceFrameCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceFrameCaptureRequest
{
    /// <summary>Gets the frame identifier. JA: FrameId を取得します。</summary>
    public string? FrameId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a log evidence capture request.
/// JA: EvidenceLogCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceLogCaptureRequest
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a diagnostics evidence capture request.
/// JA: EvidenceDiagnosticsCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceDiagnosticsCaptureRequest
{
    /// <summary>Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an evidence export request.
/// JA: EvidenceExportRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceExportRequest
{
    /// <summary>Gets the evidence bundle identifier. JA: EvidenceId を取得します。</summary>
    public string EvidenceId { get; init; } = string.Empty;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an evidence export result.
/// JA: EvidenceExportResult の公開契約を定義します。
/// </summary>
public sealed record EvidenceExportResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether export succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the exported artifact reference. JA: Artifact を取得します。</summary>
    public EvidenceArtifactRef? Artifact { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets export diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when export was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an evidence bundle.
/// JA: EvidenceBundle の公開契約を定義します。
/// </summary>
public sealed record EvidenceBundle
{
    /// <summary>Gets the evidence identifier. JA: EvidenceId を取得します。</summary>
    public string EvidenceId { get; init; } = string.Empty;

    /// <summary>Gets whether capture succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets captured evidence items. JA: Items を取得します。</summary>
    public IReadOnlyList<EvidenceItem> Items { get; init; } = [];

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets bundle diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when the bundle was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets bundle metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries one evidence item.
/// JA: EvidenceItem の公開契約を定義します。
/// </summary>
public sealed record EvidenceItem
{
    /// <summary>Gets the evidence item identifier. JA: EvidenceItemId を取得します。</summary>
    public string EvidenceItemId { get; init; } = string.Empty;

    /// <summary>Gets whether item capture succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the evidence kind. JA: Kind を取得します。</summary>
    public EvidenceKind Kind { get; init; } = EvidenceKind.Unknown;

    /// <summary>Gets an artifact reference. JA: Artifact を取得します。</summary>
    public EvidenceArtifactRef? Artifact { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets item diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when item capture was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets item metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// References an evidence artifact.
/// JA: EvidenceArtifactRef の公開契約を定義します。
/// </summary>
public sealed record EvidenceArtifactRef
{
    /// <summary>Gets the artifact identifier. JA: ArtifactId を取得します。</summary>
    public string ArtifactId { get; init; } = string.Empty;

    /// <summary>Gets the artifact URI. JA: Uri を取得します。</summary>
    public string? Uri { get; init; }

    /// <summary>Gets the content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets artifact metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
