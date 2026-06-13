using AIKernel.Dtos.Providers;

namespace AIKernel.Dtos.Perception;

/// <summary>
/// Carries frame perception options.
/// </summary>
public sealed record FramePerceptionOptions
{
    /// <summary>Gets whether HUD extraction is requested.</summary>
    public bool IncludeHud { get; init; } = true;

    /// <summary>Gets whether motion extraction is requested.</summary>
    public bool IncludeMotion { get; init; } = true;

    /// <summary>Gets optional perception metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a symbolic region extracted from a frame.
/// </summary>
public sealed record PerceptionRegion
{
    /// <summary>Gets the region identifier.</summary>
    public required string RegionId { get; init; }

    /// <summary>Gets the normalized X coordinate.</summary>
    public double X { get; init; }

    /// <summary>Gets the normalized Y coordinate.</summary>
    public double Y { get; init; }

    /// <summary>Gets the normalized width.</summary>
    public double Width { get; init; }

    /// <summary>Gets the normalized height.</summary>
    public double Height { get; init; }

    /// <summary>Gets optional region metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a bounded symbolic perception signal.
/// </summary>
public sealed record PerceptionSignal
{
    /// <summary>Gets the signal identifier.</summary>
    public required string SignalId { get; init; }

    /// <summary>Gets the signal kind.</summary>
    public required string Kind { get; init; }

    /// <summary>Gets confidence from 0 to 1.</summary>
    public double Confidence { get; init; }

    /// <summary>Gets optional signal metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a semantic frame signature.
/// </summary>
public sealed record SemanticSignature
{
    /// <summary>Gets the signature identifier.</summary>
    public required string SignatureId { get; init; }

    /// <summary>Gets the signature hash.</summary>
    public required string Hash { get; init; }

    /// <summary>Gets optional signature metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes bounded motion metadata across frames.
/// </summary>
public sealed record MotionSignature
{
    /// <summary>Gets a motion vector X component.</summary>
    public double DeltaX { get; init; }

    /// <summary>Gets a motion vector Y component.</summary>
    public double DeltaY { get; init; }

    /// <summary>Gets confidence from 0 to 1.</summary>
    public double Confidence { get; init; }

    /// <summary>Gets optional motion metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a frame perception result.
/// </summary>
public sealed record FramePerceptionResult
{
    /// <summary>Gets the observation identifier.</summary>
    public required string ObservationId { get; init; }

    /// <summary>Gets the source surface identifier.</summary>
    public string? SurfaceId { get; init; }

    /// <summary>Gets the source frame identifier.</summary>
    public required string FrameId { get; init; }

    /// <summary>Gets the source frame index.</summary>
    public long FrameIndex { get; init; }

    /// <summary>Gets extracted regions.</summary>
    public IReadOnlyList<PerceptionRegion> Regions { get; init; } = [];

    /// <summary>Gets extracted signals.</summary>
    public IReadOnlyList<PerceptionSignal> Signals { get; init; } = [];

    /// <summary>Gets extracted semantic signatures.</summary>
    public IReadOnlyList<SemanticSignature> Signatures { get; init; } = [];

    /// <summary>Gets extracted motion metadata.</summary>
    public MotionSignature? Motion { get; init; }

    /// <summary>Gets provider diagnostics.</summary>
    public IReadOnlyList<ProviderDiagnostic> Diagnostics { get; init; } = [];

    /// <summary>Gets optional perception metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an observation request.
/// </summary>
public sealed record ObservationRequest
{
    /// <summary>Gets the observation identifier.</summary>
    public required string ObservationId { get; init; }

    /// <summary>Gets optional observation metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a read-only observation snapshot.
/// </summary>
public sealed record ObservationSnapshot
{
    /// <summary>Gets the observation identifier.</summary>
    public required string ObservationId { get; init; }

    /// <summary>Gets perception results included in the observation.</summary>
    public IReadOnlyList<FramePerceptionResult> Perceptions { get; init; } = [];

    /// <summary>Gets optional observation metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
