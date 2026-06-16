using AIKernel.Enums;

namespace AIKernel.Dtos.Frame;

/// <summary>
/// EN: Carries a frame capture request.
/// EN: Documentation for public API. JA: FrameCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record FrameCaptureRequest
{
    /// <summary>EN: Gets the source identifier. JA: SourceId を取得します。</summary>
    public required string SourceId { get; init; }

    /// <summary>EN: Gets the maximum frame count to capture. JA: MaxFrames を取得します。</summary>
    public int? MaxFrames { get; init; }

    /// <summary>EN: Gets optional capture metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Describes frame buffer shape and pixel format.
/// EN: Documentation for public API. JA: FrameBufferDescriptor の公開契約を定義します。
/// </summary>
public sealed record FrameBufferDescriptor
{
    /// <summary>EN: Gets the frame width. JA: Width を取得します。</summary>
    public int Width { get; init; }

    /// <summary>EN: Gets the frame height. JA: Height を取得します。</summary>
    public int Height { get; init; }

    /// <summary>EN: Gets the stride in bytes. JA: Stride を取得します。</summary>
    public int Stride { get; init; }

    /// <summary>EN: Gets the pixel format. JA: PixelFormat を取得します。</summary>
    public FramePixelFormat PixelFormat { get; init; } = FramePixelFormat.Unknown;

    /// <summary>EN: Gets whether the frame source can provide a zero-copy path. JA: ZeroCopyHint を取得します。</summary>
    public bool ZeroCopyHint { get; init; }
}

/// <summary>
/// EN: Carries a frame snapshot.
/// EN: Documentation for public API. JA: FrameSnapshot の公開契約を定義します。
/// </summary>
public sealed record FrameSnapshot
{
    /// <summary>EN: Gets the frame identifier. JA: FrameId を取得します。</summary>
    public required string FrameId { get; init; }

    /// <summary>EN: Gets the source identifier. JA: SourceId を取得します。</summary>
    public required string SourceId { get; init; }

    /// <summary>EN: Gets the frame index. JA: FrameIndex を取得します。</summary>
    public long FrameIndex { get; init; }

    /// <summary>EN: Gets the frame buffer descriptor. JA: Buffer を取得します。</summary>
    public FrameBufferDescriptor Buffer { get; init; } = new();

    /// <summary>EN: Gets the frame hash. JA: FrameHash を取得します。</summary>
    public string? FrameHash { get; init; }

    /// <summary>EN: Gets optional frame metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a frame surface binding request.
/// EN: Documentation for public API. JA: FrameSurfaceBindingRequest の公開契約を定義します。
/// </summary>
public sealed record FrameSurfaceBindingRequest
{
    /// <summary>EN: Gets the surface identifier. JA: SurfaceId を取得します。</summary>
    public required string SurfaceId { get; init; }

    /// <summary>EN: Gets the source identifier. JA: SourceId を取得します。</summary>
    public required string SourceId { get; init; }

    /// <summary>EN: Gets optional binding metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a frame surface binding result.
/// EN: Documentation for public API. JA: FrameSurfaceBinding の公開契約を定義します。
/// </summary>
public sealed record FrameSurfaceBinding
{
    /// <summary>EN: Gets whether binding succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the surface identifier. JA: SurfaceId を取得します。</summary>
    public string? SurfaceId { get; init; }

    /// <summary>EN: Gets whether CPU fallback is used. JA: UsingCpuFallback を取得します。</summary>
    public bool UsingCpuFallback { get; init; }

    /// <summary>EN: Gets whether a zero-copy path is active. JA: ZeroCopy を取得します。</summary>
    public bool ZeroCopy { get; init; }

    /// <summary>EN: Gets optional binding metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Describes a virtual frame surface exposed by a sandbox instance.
/// EN: Documentation for public API. JA: VirtualSurfaceDescriptor の公開契約を定義します。
/// </summary>
public sealed record VirtualSurfaceDescriptor
{
    /// <summary>EN: Gets the surface identifier. JA: SurfaceId を取得します。</summary>
    public required string SurfaceId { get; init; }

    /// <summary>EN: Gets the surface name. JA: Name を取得します。</summary>
    public string? Name { get; init; }

    /// <summary>EN: Gets the frame buffer descriptor. JA: Buffer を取得します。</summary>
    public FrameBufferDescriptor Buffer { get; init; } = new();

    /// <summary>EN: Gets optional surface metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
