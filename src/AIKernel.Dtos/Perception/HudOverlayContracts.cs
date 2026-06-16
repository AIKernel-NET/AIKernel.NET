using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Perception;

namespace AIKernel.Dtos.Perception;

/// <summary>
/// EN: Carries a HUD signal extraction request.
/// EN: Documentation for public API. JA: HudSignalRequest の公開契約を定義します。
/// </summary>
public sealed record HudSignalRequest
{
    /// <summary>EN: Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public string? ObservationId { get; init; }

    /// <summary>EN: Gets the frame identifier. JA: FrameId を取得します。</summary>
    public string? FrameId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries lightweight HUD signals.
/// EN: Documentation for public API. JA: HudSignalSet の公開契約を定義します。
/// </summary>
public sealed record HudSignalSet
{
    /// <summary>EN: Gets the signal set identifier. JA: SignalSetId を取得します。</summary>
    public string SignalSetId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether extraction succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets HUD signals. JA: Signals を取得します。</summary>
    public IReadOnlyList<HudSignal> Signals { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets extraction diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when extraction was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries one lightweight HUD signal.
/// EN: Documentation for public API. JA: HudSignal の公開契約を定義します。
/// </summary>
public sealed record HudSignal
{
    /// <summary>EN: Gets the signal identifier. JA: SignalId を取得します。</summary>
    public string SignalId { get; init; } = string.Empty;

    /// <summary>EN: Gets the signal kind. JA: Kind を取得します。</summary>
    public HudSignalKind Kind { get; init; } = HudSignalKind.Unknown;

    /// <summary>EN: Gets the normalized signal value. JA: Value を取得します。</summary>
    public string Value { get; init; } = string.Empty;

    /// <summary>EN: Gets numeric value when available. JA: NumericValue を取得します。</summary>
    public double? NumericValue { get; init; }

    /// <summary>EN: Gets confidence kind. JA: Confidence を取得します。</summary>
    public SignalConfidenceKind Confidence { get; init; } = SignalConfidenceKind.Unknown;

    /// <summary>EN: Gets normalized X coordinate when available. JA: X を取得します。</summary>
    public double? X { get; init; }

    /// <summary>EN: Gets normalized Y coordinate when available. JA: Y を取得します。</summary>
    public double? Y { get; init; }

    /// <summary>EN: Gets normalized width when available. JA: Width を取得します。</summary>
    public double? Width { get; init; }

    /// <summary>EN: Gets normalized height when available. JA: Height を取得します。</summary>
    public double? Height { get; init; }

    /// <summary>EN: Gets signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a HUD signal catalog request.
/// EN: Documentation for public API. JA: HudSignalCatalogRequest の公開契約を定義します。
/// </summary>
public sealed record HudSignalCatalogRequest
{
    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries supported HUD signal kinds.
/// EN: Documentation for public API. JA: HudSignalCatalog の公開契約を定義します。
/// </summary>
public sealed record HudSignalCatalog
{
    /// <summary>EN: Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets supported HUD signal kinds. JA: SupportedSignals を取得します。</summary>
    public IReadOnlyList<HudSignalKind> SupportedSignals { get; init; } = [];

    /// <summary>EN: Gets catalog diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries visual signals that are heavier than lightweight HUD signals.
/// EN: Documentation for public API. JA: VisualSignalSet の公開契約を定義します。
/// </summary>
public sealed record VisualSignalSet
{
    /// <summary>EN: Gets the visual signal set identifier. JA: SignalSetId を取得します。</summary>
    public string SignalSetId { get; init; } = string.Empty;

    /// <summary>EN: Gets visual signals. JA: Signals を取得します。</summary>
    public IReadOnlyList<VisualSignal> Signals { get; init; } = [];

    /// <summary>EN: Gets visual signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries one visual signal.
/// EN: Documentation for public API. JA: VisualSignal の公開契約を定義します。
/// </summary>
public sealed record VisualSignal
{
    /// <summary>EN: Gets the visual signal identifier. JA: SignalId を取得します。</summary>
    public string SignalId { get; init; } = string.Empty;

    /// <summary>EN: Gets normalized X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>EN: Gets normalized Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>EN: Gets normalized width. JA: Width を取得します。</summary>
    public double Width { get; init; }

    /// <summary>EN: Gets normalized height. JA: Height を取得します。</summary>
    public double Height { get; init; }

    /// <summary>EN: Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets visual signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an overlay annotation request.
/// EN: Documentation for public API. JA: OverlayAnnotationRequest の公開契約を定義します。
/// </summary>
public sealed record OverlayAnnotationRequest
{
    /// <summary>EN: Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public string? ObservationId { get; init; }

    /// <summary>EN: Gets the frame identifier. JA: FrameId を取得します。</summary>
    public string? FrameId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries overlay annotations.
/// EN: Documentation for public API. JA: OverlayAnnotationSet の公開契約を定義します。
/// </summary>
public sealed record OverlayAnnotationSet
{
    /// <summary>EN: Gets the annotation set identifier. JA: AnnotationSetId を取得します。</summary>
    public string AnnotationSetId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether overlay creation succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets overlay annotations. JA: Annotations を取得します。</summary>
    public IReadOnlyList<OverlayAnnotation> Annotations { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets overlay diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when overlay creation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets annotation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries one overlay annotation.
/// EN: Documentation for public API. JA: OverlayAnnotation の公開契約を定義します。
/// </summary>
public sealed record OverlayAnnotation
{
    /// <summary>EN: Gets the annotation identifier. JA: AnnotationId を取得します。</summary>
    public string AnnotationId { get; init; } = string.Empty;

    /// <summary>EN: Gets the overlay shape kind. JA: ShapeKind を取得します。</summary>
    public OverlayShapeKind ShapeKind { get; init; } = OverlayShapeKind.Unknown;

    /// <summary>EN: Gets the overlay layer kind. JA: LayerKind を取得します。</summary>
    public OverlayLayerKind LayerKind { get; init; } = OverlayLayerKind.Unknown;

    /// <summary>EN: Gets normalized X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>EN: Gets normalized Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>EN: Gets normalized width. JA: Width を取得します。</summary>
    public double Width { get; init; }

    /// <summary>EN: Gets normalized height. JA: Height を取得します。</summary>
    public double Height { get; init; }

    /// <summary>EN: Gets optional annotation text. JA: Text を取得します。</summary>
    public string? Text { get; init; }

    /// <summary>EN: Gets annotation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an overlay layer catalog request.
/// EN: Documentation for public API. JA: OverlayLayerCatalogRequest の公開契約を定義します。
/// </summary>
public sealed record OverlayLayerCatalogRequest
{
    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries supported overlay layers.
/// EN: Documentation for public API. JA: OverlayLayerCatalog の公開契約を定義します。
/// </summary>
public sealed record OverlayLayerCatalog
{
    /// <summary>EN: Gets the catalog identifier. JA: CatalogId を取得します。</summary>
    public string CatalogId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether catalog description succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets supported overlay layers. JA: SupportedLayers を取得します。</summary>
    public IReadOnlyList<OverlayLayerKind> SupportedLayers { get; init; } = [];

    /// <summary>EN: Gets catalog diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets catalog metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
