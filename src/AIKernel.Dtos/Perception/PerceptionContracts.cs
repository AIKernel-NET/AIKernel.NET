using AIKernel.Dtos.Providers;

namespace AIKernel.Dtos.Perception;

/// <summary>
/// EN: Carries frame perception options.
/// [EN] Documents this public package API member. [JA] FramePerceptionOptions の公開契約を定義します。
/// </summary>
public sealed record FramePerceptionOptions
{
    /// <summary>EN: Gets whether HUD extraction is requested. JA: IncludeHud を取得します。</summary>
    public bool IncludeHud { get; init; } = true;

    /// <summary>EN: Gets whether motion extraction is requested. JA: IncludeMotion を取得します。</summary>
    public bool IncludeMotion { get; init; } = true;

    /// <summary>EN: Gets optional perception metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Describes a symbolic region extracted from a frame.
/// [EN] Documents this public package API member. [JA] PerceptionRegion の公開契約を定義します。
/// </summary>
public sealed record PerceptionRegion
{
    /// <summary>EN: Gets the region identifier. JA: RegionId を取得します。</summary>
    public required string RegionId { get; init; }

    /// <summary>EN: Gets the normalized X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>EN: Gets the normalized Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>EN: Gets the normalized width. JA: Width を取得します。</summary>
    public double Width { get; init; }

    /// <summary>EN: Gets the normalized height. JA: Height を取得します。</summary>
    public double Height { get; init; }

    /// <summary>EN: Gets optional region metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Describes a bounded symbolic perception signal.
/// [EN] Documents this public package API member. [JA] PerceptionSignal の公開契約を定義します。
/// </summary>
public sealed record PerceptionSignal
{
    /// <summary>EN: Gets the signal identifier. JA: SignalId を取得します。</summary>
    public required string SignalId { get; init; }

    /// <summary>EN: Gets the signal kind. JA: Kind を取得します。</summary>
    public required string Kind { get; init; }

    /// <summary>EN: Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets optional signal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Describes a semantic frame signature.
/// [EN] Documents this public package API member. [JA] SemanticSignature の公開契約を定義します。
/// </summary>
public sealed record SemanticSignature
{
    /// <summary>EN: Gets the signature identifier. JA: SignatureId を取得します。</summary>
    public required string SignatureId { get; init; }

    /// <summary>EN: Gets the signature hash. JA: Hash を取得します。</summary>
    public required string Hash { get; init; }

    /// <summary>EN: Gets optional signature metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Describes bounded motion metadata across frames.
/// [EN] Documents this public package API member. [JA] MotionSignature の公開契約を定義します。
/// </summary>
public sealed record MotionSignature
{
    /// <summary>EN: Gets a motion vector X component. JA: DeltaX を取得します。</summary>
    public double DeltaX { get; init; }

    /// <summary>EN: Gets a motion vector Y component. JA: DeltaY を取得します。</summary>
    public double DeltaY { get; init; }

    /// <summary>EN: Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets optional motion metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a frame perception result.
/// [EN] Documents this public package API member. [JA] FramePerceptionResult の公開契約を定義します。
/// </summary>
public sealed record FramePerceptionResult
{
    /// <summary>EN: Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public required string ObservationId { get; init; }

    /// <summary>EN: Gets the source surface identifier. JA: SurfaceId を取得します。</summary>
    public string? SurfaceId { get; init; }

    /// <summary>EN: Gets the source frame identifier. JA: FrameId を取得します。</summary>
    public required string FrameId { get; init; }

    /// <summary>EN: Gets the source frame index. JA: FrameIndex を取得します。</summary>
    public long FrameIndex { get; init; }

    /// <summary>EN: Gets extracted regions. JA: Regions を取得します。</summary>
    public IReadOnlyList<PerceptionRegion> Regions { get; init; } = [];

    /// <summary>EN: Gets extracted signals. JA: Signals を取得します。</summary>
    public IReadOnlyList<PerceptionSignal> Signals { get; init; } = [];

    /// <summary>EN: Gets extracted semantic signatures. JA: Signatures を取得します。</summary>
    public IReadOnlyList<SemanticSignature> Signatures { get; init; } = [];

    /// <summary>EN: Gets extracted motion metadata. JA: Motion を取得します。</summary>
    public MotionSignature? Motion { get; init; }

    /// <summary>EN: Gets provider diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<ProviderDiagnostic> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets optional perception metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries an observation request.
/// [EN] Documents this public package API member. [JA] ObservationRequest の公開契約を定義します。
/// </summary>
public sealed record ObservationRequest
{
    /// <summary>EN: Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public required string ObservationId { get; init; }

    /// <summary>EN: Gets optional observation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a read-only observation snapshot.
/// [EN] Documents this public package API member. [JA] ObservationSnapshot の公開契約を定義します。
/// </summary>
public sealed record ObservationSnapshot
{
    /// <summary>EN: Gets the observation identifier. JA: ObservationId を取得します。</summary>
    public required string ObservationId { get; init; }

    /// <summary>EN: Gets perception results included in the observation. JA: Perceptions を取得します。</summary>
    public IReadOnlyList<FramePerceptionResult> Perceptions { get; init; } = [];

    /// <summary>EN: Gets optional observation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
