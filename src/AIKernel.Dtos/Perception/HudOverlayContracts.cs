using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Perception;

namespace AIKernel.Dtos.Perception;

/// <summary>
/// Carries a HUD signal extraction request.
/// JA: HudSignalRequest の公開契約を定義します。
/// </summary>
public sealed record HudSignalRequest
{
    /// <summary>Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public string? ObservationId { get; init; }

    /// <summary>Gets the frame identifier. JA: FrameId を取得します。</summary>
    public string? FrameId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries lightweight HUD signals.
/// JA: HudSignalSet の公開契約を定義します。
/// </summary>
public sealed record HudSignalSet
{
    /// <summary>Gets the signal set identifier. JA: SignalSetId を取得します。</summary>
    public string SignalSetId { get; init; } = string.Empty;

    /// <summary>Gets whether extraction succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets HUD signals. JA: Signals を取得します。</summary>
    public IReadOnlyList<HudSignal> Signals { get; init; } = [];

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets extraction diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when extraction was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries one lightweight HUD signal.
/// JA: HudSignal の公開契約を定義します。
/// </summary>
public sealed record HudSignal
{
    /// <summary>Gets the signal identifier. JA: SignalId を取得します。</summary>
    public string SignalId { get; init; } = string.Empty;

    /// <summary>Gets the signal kind. JA: Kind を取得します。</summary>
    public HudSignalKind Kind { get; init; } = HudSignalKind.Unknown;

    /// <summary>Gets the normalized signal value. JA: Value を取得します。</summary>
    public string Value { get; init; } = string.Empty;

    /// <summary>Gets numeric value when available. JA: NumericValue を取得します。</summary>
    public double? NumericValue { get; init; }

    /// <summary>Gets confidence kind. JA: Confidence を取得します。</summary>
    public SignalConfidenceKind Confidence { get; init; } = SignalConfidenceKind.Unknown;

    /// <summary>Gets normalized X coordinate when available. JA: X を取得します。</summary>
    public double? X { get; init; }

    /// <summary>Gets normalized Y coordinate when available. JA: Y を取得します。</summary>
    public double? Y { get; init; }

    /// <summary>Gets normalized width when available. JA: Width を取得します。</summary>
    public double? Width { get; init; }

    /// <summary>Gets normalized height when available. JA: Height を取得します。</summary>
    public double? Height { get; init; }

    /// <summary>Gets signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a HUD signal catalog request.
/// JA: HudSignalCatalogRequest の公開契約を定義します。
/// </summary>
public sealed record HudSignalCatalogRequest
{
    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries supported HUD signal kinds.
/// JA: HudSignalCatalog の公開契約を定義します。
/// </summary>
public sealed record HudSignalCatalog
{
    /// <summary>Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets supported HUD signal kinds. JA: SupportedSignals を取得します。</summary>
    public IReadOnlyList<HudSignalKind> SupportedSignals { get; init; } = [];

    /// <summary>Gets catalog diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries visual signals that are heavier than lightweight HUD signals.
/// JA: VisualSignalSet の公開契約を定義します。
/// </summary>
public sealed record VisualSignalSet
{
    /// <summary>Gets the visual signal set identifier. JA: SignalSetId を取得します。</summary>
    public string SignalSetId { get; init; } = string.Empty;

    /// <summary>Gets visual signals. JA: Signals を取得します。</summary>
    public IReadOnlyList<VisualSignal> Signals { get; init; } = [];

    /// <summary>Gets visual signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries one visual signal.
/// JA: VisualSignal の公開契約を定義します。
/// </summary>
public sealed record VisualSignal
{
    /// <summary>Gets the visual signal identifier. JA: SignalId を取得します。</summary>
    public string SignalId { get; init; } = string.Empty;

    /// <summary>Gets normalized X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>Gets normalized Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>Gets normalized width. JA: Width を取得します。</summary>
    public double Width { get; init; }

    /// <summary>Gets normalized height. JA: Height を取得します。</summary>
    public double Height { get; init; }

    /// <summary>Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>Gets visual signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an overlay annotation request.
/// JA: OverlayAnnotationRequest の公開契約を定義します。
/// </summary>
public sealed record OverlayAnnotationRequest
{
    /// <summary>Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public string? ObservationId { get; init; }

    /// <summary>Gets the frame identifier. JA: FrameId を取得します。</summary>
    public string? FrameId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries overlay annotations.
/// JA: OverlayAnnotationSet の公開契約を定義します。
/// </summary>
public sealed record OverlayAnnotationSet
{
    /// <summary>Gets the annotation set identifier. JA: AnnotationSetId を取得します。</summary>
    public string AnnotationSetId { get; init; } = string.Empty;

    /// <summary>Gets whether overlay creation succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets overlay annotations. JA: Annotations を取得します。</summary>
    public IReadOnlyList<OverlayAnnotation> Annotations { get; init; } = [];

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets overlay diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when overlay creation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets annotation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries one overlay annotation.
/// JA: OverlayAnnotation の公開契約を定義します。
/// </summary>
public sealed record OverlayAnnotation
{
    /// <summary>Gets the annotation identifier. JA: AnnotationId を取得します。</summary>
    public string AnnotationId { get; init; } = string.Empty;

    /// <summary>Gets the overlay shape kind. JA: ShapeKind を取得します。</summary>
    public OverlayShapeKind ShapeKind { get; init; } = OverlayShapeKind.Unknown;

    /// <summary>Gets the overlay layer kind. JA: LayerKind を取得します。</summary>
    public OverlayLayerKind LayerKind { get; init; } = OverlayLayerKind.Unknown;

    /// <summary>Gets normalized X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>Gets normalized Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>Gets normalized width. JA: Width を取得します。</summary>
    public double Width { get; init; }

    /// <summary>Gets normalized height. JA: Height を取得します。</summary>
    public double Height { get; init; }

    /// <summary>Gets optional annotation text. JA: Text を取得します。</summary>
    public string? Text { get; init; }

    /// <summary>Gets annotation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an overlay layer catalog request.
/// JA: OverlayLayerCatalogRequest の公開契約を定義します。
/// </summary>
public sealed record OverlayLayerCatalogRequest
{
    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries supported overlay layers.
/// JA: OverlayLayerCatalog の公開契約を定義します。
/// </summary>
public sealed record OverlayLayerCatalog
{
    /// <summary>Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets supported overlay layers. JA: SupportedLayers を取得します。</summary>
    public IReadOnlyList<OverlayLayerKind> SupportedLayers { get; init; } = [];

    /// <summary>Gets catalog diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
