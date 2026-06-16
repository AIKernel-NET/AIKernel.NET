using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Diagnostics;
using AIKernel.Enums.Observability;

namespace AIKernel.Dtos.Observability;

/// <summary>
/// EN: Carries an evidence capture request.
/// EN: Documentation for public API. JA: EvidenceCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceCaptureRequest
{
    /// <summary>EN: Gets the evidence request identifier. JA: RequestId を取得します。</summary>
    public string RequestId { get; init; } = string.Empty;

    /// <summary>EN: Gets the capture mode. JA: Mode を取得します。</summary>
    public EvidenceCaptureMode Mode { get; init; } = EvidenceCaptureMode.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a frame evidence capture request.
/// EN: Documentation for public API. JA: EvidenceFrameCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceFrameCaptureRequest
{
    /// <summary>EN: Gets the frame identifier. JA: FrameId を取得します。</summary>
    public string? FrameId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a log evidence capture request.
/// EN: Documentation for public API. JA: EvidenceLogCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceLogCaptureRequest
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a diagnostics evidence capture request.
/// EN: Documentation for public API. JA: EvidenceDiagnosticsCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceDiagnosticsCaptureRequest
{
    /// <summary>EN: Gets the diagnostic scope. JA: Scope を取得します。</summary>
    public DiagnosticScope Scope { get; init; } = DiagnosticScope.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an evidence export request.
/// EN: Documentation for public API. JA: EvidenceExportRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceExportRequest
{
    /// <summary>EN: Gets the evidence bundle identifier. JA: EvidenceId を取得します。</summary>
    public string EvidenceId { get; init; } = string.Empty;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an evidence export result.
/// EN: Documentation for public API. JA: EvidenceExportResult の公開契約を定義します。
/// </summary>
public sealed record EvidenceExportResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether export succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the exported artifact reference. JA: Artifact を取得します。</summary>
    public EvidenceArtifactRef? Artifact { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets export diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when export was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an evidence bundle.
/// EN: Documentation for public API. JA: EvidenceBundle の公開契約を定義します。
/// </summary>
public sealed record EvidenceBundle
{
    /// <summary>EN: Gets the evidence identifier. JA: EvidenceId を取得します。</summary>
    public string EvidenceId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether capture succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets captured evidence items. JA: Items を取得します。</summary>
    public IReadOnlyList<EvidenceItem> Items { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets bundle diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when the bundle was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets bundle metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries one evidence item.
/// EN: Documentation for public API. JA: EvidenceItem の公開契約を定義します。
/// </summary>
public sealed record EvidenceItem
{
    /// <summary>EN: Gets the evidence item identifier. JA: EvidenceItemId を取得します。</summary>
    public string EvidenceItemId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether item capture succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the evidence kind. JA: Kind を取得します。</summary>
    public EvidenceKind Kind { get; init; } = EvidenceKind.Unknown;

    /// <summary>EN: Gets an artifact reference. JA: Artifact を取得します。</summary>
    public EvidenceArtifactRef? Artifact { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets item diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when item capture was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets item metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: References an evidence artifact.
/// EN: Documentation for public API. JA: EvidenceArtifactRef の公開契約を定義します。
/// </summary>
public sealed record EvidenceArtifactRef
{
    /// <summary>EN: Gets the artifact identifier. JA: ArtifactId を取得します。</summary>
    public string ArtifactId { get; init; } = string.Empty;

    /// <summary>EN: Gets the artifact URI. JA: Uri を取得します。</summary>
    public string? Uri { get; init; }

    /// <summary>EN: Gets the content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>EN: Gets artifact metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
