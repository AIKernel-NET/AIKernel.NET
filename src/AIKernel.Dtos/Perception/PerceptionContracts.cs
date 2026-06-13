using AIKernel.Dtos.Providers;

namespace AIKernel.Dtos.Perception;

/// <summary>
/// Carries frame perception options.
/// JA: FramePerceptionOptions の公開契約を定義します。
/// </summary>
public sealed record FramePerceptionOptions
{
    /// <summary>Gets whether HUD extraction is requested. JA: IncludeHud を取得します。</summary>
    public bool IncludeHud { get; init; } = true;

    /// <summary>Gets whether motion extraction is requested. JA: IncludeMotion を取得します。</summary>
    public bool IncludeMotion { get; init; } = true;

    /// <summary>Gets optional perception metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a symbolic region extracted from a frame.
/// JA: PerceptionRegion の公開契約を定義します。
/// </summary>
public sealed record PerceptionRegion
{
    /// <summary>Gets the region identifier. JA: RegionId を取得します。</summary>
    public required string RegionId { get; init; }

    /// <summary>Gets the normalized X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>Gets the normalized Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>Gets the normalized width. JA: Width を取得します。</summary>
    public double Width { get; init; }

    /// <summary>Gets the normalized height. JA: Height を取得します。</summary>
    public double Height { get; init; }

    /// <summary>Gets optional region metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a bounded symbolic perception signal.
/// JA: PerceptionSignal の公開契約を定義します。
/// </summary>
public sealed record PerceptionSignal
{
    /// <summary>Gets the signal identifier. JA: SignalId を取得します。</summary>
    public required string SignalId { get; init; }

    /// <summary>Gets the signal kind. JA: Kind を取得します。</summary>
    public required string Kind { get; init; }

    /// <summary>Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>Gets optional signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a semantic frame signature.
/// JA: SemanticSignature の公開契約を定義します。
/// </summary>
public sealed record SemanticSignature
{
    /// <summary>Gets the signature identifier. JA: SignatureId を取得します。</summary>
    public required string SignatureId { get; init; }

    /// <summary>Gets the signature hash. JA: Hash を取得します。</summary>
    public required string Hash { get; init; }

    /// <summary>Gets optional signature metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes bounded motion metadata across frames.
/// JA: MotionSignature の公開契約を定義します。
/// </summary>
public sealed record MotionSignature
{
    /// <summary>Gets a motion vector X component. JA: DeltaX を取得します。</summary>
    public double DeltaX { get; init; }

    /// <summary>Gets a motion vector Y component. JA: DeltaY を取得します。</summary>
    public double DeltaY { get; init; }

    /// <summary>Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>Gets optional motion metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a frame perception result.
/// JA: FramePerceptionResult の公開契約を定義します。
/// </summary>
public sealed record FramePerceptionResult
{
    /// <summary>Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public required string ObservationId { get; init; }

    /// <summary>Gets the source surface identifier. JA: SurfaceId を取得します。</summary>
    public string? SurfaceId { get; init; }

    /// <summary>Gets the source frame identifier. JA: FrameId を取得します。</summary>
    public required string FrameId { get; init; }

    /// <summary>Gets the source frame index. JA: FrameIndex を取得します。</summary>
    public long FrameIndex { get; init; }

    /// <summary>Gets extracted regions. JA: Regions を取得します。</summary>
    public IReadOnlyList<PerceptionRegion> Regions { get; init; } = [];

    /// <summary>Gets extracted signals. JA: Signals を取得します。</summary>
    public IReadOnlyList<PerceptionSignal> Signals { get; init; } = [];

    /// <summary>Gets extracted semantic signatures. JA: Signatures を取得します。</summary>
    public IReadOnlyList<SemanticSignature> Signatures { get; init; } = [];

    /// <summary>Gets extracted motion metadata. JA: Motion を取得します。</summary>
    public MotionSignature? Motion { get; init; }

    /// <summary>Gets provider diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<ProviderDiagnostic> Diagnostics { get; init; } = [];

    /// <summary>Gets optional perception metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an observation request.
/// JA: ObservationRequest の公開契約を定義します。
/// </summary>
public sealed record ObservationRequest
{
    /// <summary>Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public required string ObservationId { get; init; }

    /// <summary>Gets optional observation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a read-only observation snapshot.
/// JA: ObservationSnapshot の公開契約を定義します。
/// </summary>
public sealed record ObservationSnapshot
{
    /// <summary>Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public required string ObservationId { get; init; }

    /// <summary>Gets perception results included in the observation. JA: Perceptions を取得します。</summary>
    public IReadOnlyList<FramePerceptionResult> Perceptions { get; init; } = [];

    /// <summary>Gets optional observation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
