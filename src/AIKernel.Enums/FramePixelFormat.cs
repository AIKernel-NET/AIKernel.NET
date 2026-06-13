namespace AIKernel.Enums;

/// <summary>
/// Describes a frame buffer pixel format.
/// </summary>
public enum FramePixelFormat
{
    /// <summary>The pixel format is unknown.</summary>
    Unknown = 0,

    /// <summary>Eight-bit indexed or paletted pixels.</summary>
    Indexed8 = 1,

    /// <summary>RGB24 pixels.</summary>
    Rgb24 = 2,

    /// <summary>RGBA32 pixels.</summary>
    Rgba32 = 3,

    /// <summary>BGRA32 pixels.</summary>
    Bgra32 = 4,

    /// <summary>Single-channel luminance pixels.</summary>
    Luminance8 = 5
}
