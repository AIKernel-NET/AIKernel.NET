using AIKernel.Enums;

namespace AIKernel.Dtos.Frame;

/// <summary>
/// Carries a frame capture request.
/// </summary>
public sealed record FrameCaptureRequest
{
    /// <summary>Gets the source identifier.</summary>
    public required string SourceId { get; init; }

    /// <summary>Gets the maximum frame count to capture.</summary>
    public int? MaxFrames { get; init; }

    /// <summary>Gets optional capture metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes frame buffer shape and pixel format.
/// </summary>
public sealed record FrameBufferDescriptor
{
    /// <summary>Gets the frame width.</summary>
    public int Width { get; init; }

    /// <summary>Gets the frame height.</summary>
    public int Height { get; init; }

    /// <summary>Gets the stride in bytes.</summary>
    public int Stride { get; init; }

    /// <summary>Gets the pixel format.</summary>
    public FramePixelFormat PixelFormat { get; init; } = FramePixelFormat.Unknown;

    /// <summary>Gets whether the frame source can provide a zero-copy path.</summary>
    public bool ZeroCopyHint { get; init; }
}

/// <summary>
/// Carries a frame snapshot.
/// </summary>
public sealed record FrameSnapshot
{
    /// <summary>Gets the frame identifier.</summary>
    public required string FrameId { get; init; }

    /// <summary>Gets the source identifier.</summary>
    public required string SourceId { get; init; }

    /// <summary>Gets the frame index.</summary>
    public long FrameIndex { get; init; }

    /// <summary>Gets the frame buffer descriptor.</summary>
    public FrameBufferDescriptor Buffer { get; init; } = new();

    /// <summary>Gets the frame hash.</summary>
    public string? FrameHash { get; init; }

    /// <summary>Gets optional frame metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a frame surface binding request.
/// </summary>
public sealed record FrameSurfaceBindingRequest
{
    /// <summary>Gets the surface identifier.</summary>
    public required string SurfaceId { get; init; }

    /// <summary>Gets the source identifier.</summary>
    public required string SourceId { get; init; }

    /// <summary>Gets optional binding metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a frame surface binding result.
/// </summary>
public sealed record FrameSurfaceBinding
{
    /// <summary>Gets whether binding succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the surface identifier.</summary>
    public string? SurfaceId { get; init; }

    /// <summary>Gets whether CPU fallback is used.</summary>
    public bool UsingCpuFallback { get; init; }

    /// <summary>Gets whether a zero-copy path is active.</summary>
    public bool ZeroCopy { get; init; }

    /// <summary>Gets optional binding metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a virtual frame surface exposed by a sandbox instance.
/// </summary>
public sealed record VirtualSurfaceDescriptor
{
    /// <summary>Gets the surface identifier.</summary>
    public required string SurfaceId { get; init; }

    /// <summary>Gets the surface name.</summary>
    public string? Name { get; init; }

    /// <summary>Gets the frame buffer descriptor.</summary>
    public FrameBufferDescriptor Buffer { get; init; } = new();

    /// <summary>Gets optional surface metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
