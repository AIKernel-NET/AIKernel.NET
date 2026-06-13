namespace AIKernel.Enums;

/// <summary>
/// Describes a frame buffer pixel format.
/// JA: FramePixelFormat の公開契約を定義します。
/// </summary>
public enum FramePixelFormat
{
    /// <summary>The pixel format is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Eight-bit indexed or paletted pixels. JA: Indexed8 値を表します。</summary>
    Indexed8 = 1,

    /// <summary>RGB24 pixels. JA: Rgb24 値を表します。</summary>
    Rgb24 = 2,

    /// <summary>RGBA32 pixels. JA: Rgba32 値を表します。</summary>
    Rgba32 = 3,

    /// <summary>BGRA32 pixels. JA: Bgra32 値を表します。</summary>
    Bgra32 = 4,

    /// <summary>Single-channel luminance pixels. JA: Luminance8 値を表します。</summary>
    Luminance8 = 5
}
