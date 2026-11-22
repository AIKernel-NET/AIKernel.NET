namespace AIKernel.Providers.Perception;

/// <summary>
/// [EN] Describes one semantic palette color target.
/// [JA] semantic palette の 1 つの color target を記述します。
/// </summary>
public sealed record SemanticPaletteColorDescriptor
{
    /// <summary>[EN] Gets the stable semantic label. [JA] stable な semantic label を取得します。</summary>
    public string Label { get; init; } = string.Empty;

    /// <summary>[EN] Gets the red channel target. [JA] red channel target を取得します。</summary>
    public byte Red { get; init; }

    /// <summary>[EN] Gets the green channel target. [JA] green channel target を取得します。</summary>
    public byte Green { get; init; }

    /// <summary>[EN] Gets the blue channel target. [JA] blue channel target を取得します。</summary>
    public byte Blue { get; init; }

    /// <summary>[EN] Gets the maximum RGB distance accepted for this color. [JA] この color に許容する最大 RGB distance を取得します。</summary>
    public double Tolerance { get; init; } = 96;

    /// <summary>[EN] Gets deterministic color metadata. [JA] deterministic color metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// [EN] Carries semantic palette quantization input.
/// [JA] semantic palette quantization input を保持します。
/// </summary>
public sealed record SemanticPaletteQuantizationRequest
{
    /// <summary>[EN] Gets packed RGB bytes. [JA] packed RGB byte を取得します。</summary>
    public IReadOnlyList<byte> RgbBytes { get; init; } = [];

    /// <summary>[EN] Gets frame width in pixels. [JA] pixel 単位の frame width を取得します。</summary>
    public int Width { get; init; }

    /// <summary>[EN] Gets frame height in pixels. [JA] pixel 単位の frame height を取得します。</summary>
    public int Height { get; init; }

    /// <summary>[EN] Gets semantic palette colors. [JA] semantic palette color を取得します。</summary>
    public IReadOnlyList<SemanticPaletteColorDescriptor> Palette { get; init; } = [];
}

/// <summary>
/// [EN] Carries semantic palette quantization output.
/// [JA] semantic palette quantization output を保持します。
/// </summary>
public sealed record SemanticPaletteQuantizationResult
{
    /// <summary>[EN] Gets whether quantization succeeded. [JA] quantization が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets frame width in pixels. [JA] pixel 単位の frame width を取得します。</summary>
    public int Width { get; init; }

    /// <summary>[EN] Gets frame height in pixels. [JA] pixel 単位の frame height を取得します。</summary>
    public int Height { get; init; }

    /// <summary>[EN] Gets palette indexes per pixel where -1 means no match. [JA] pixel ごとの palette index を取得し、-1 は unmatched を表します。</summary>
    public IReadOnlyList<int> PaletteIndexes { get; init; } = [];

    /// <summary>[EN] Gets labels per pixel. [JA] pixel ごとの label を取得します。</summary>
    public IReadOnlyList<string> Labels { get; init; } = [];

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries temporal difference input.
/// [JA] temporal difference input を保持します。
/// </summary>
public sealed record TemporalDifferenceRequest
{
    /// <summary>[EN] Gets previous scalar values. [JA] previous scalar value を取得します。</summary>
    public IReadOnlyList<double> Previous { get; init; } = [];

    /// <summary>[EN] Gets current scalar values. [JA] current scalar value を取得します。</summary>
    public IReadOnlyList<double> Current { get; init; } = [];

    /// <summary>[EN] Gets frame width. [JA] frame width を取得します。</summary>
    public int Width { get; init; }

    /// <summary>[EN] Gets frame height. [JA] frame height を取得します。</summary>
    public int Height { get; init; }

    /// <summary>[EN] Gets the minimum absolute delta retained in output. [JA] output に残す最小 absolute delta を取得します。</summary>
    public double Threshold { get; init; }
}

/// <summary>
/// [EN] Carries temporal difference output.
/// [JA] temporal difference output を保持します。
/// </summary>
public sealed record TemporalDifferenceResult
{
    /// <summary>[EN] Gets whether calculation succeeded. [JA] calculation が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets difference values. [JA] difference value を取得します。</summary>
    public IReadOnlyList<double> Values { get; init; } = [];

    /// <summary>[EN] Gets average absolute delta. [JA] average absolute delta を取得します。</summary>
    public double MeanDelta { get; init; }

    /// <summary>[EN] Gets maximum absolute delta. [JA] maximum absolute delta を取得します。</summary>
    public double MaxDelta { get; init; }

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries Laplacian edge detection input.
/// [JA] Laplacian edge detection input を保持します。
/// </summary>
public sealed record LaplacianEdgeRequest
{
    /// <summary>[EN] Gets scalar frame values. [JA] scalar frame value を取得します。</summary>
    public IReadOnlyList<double> Values { get; init; } = [];

    /// <summary>[EN] Gets frame width. [JA] frame width を取得します。</summary>
    public int Width { get; init; }

    /// <summary>[EN] Gets frame height. [JA] frame height を取得します。</summary>
    public int Height { get; init; }
}

/// <summary>
/// [EN] Carries Laplacian edge detection output.
/// [JA] Laplacian edge detection output を保持します。
/// </summary>
public sealed record LaplacianEdgeResult
{
    /// <summary>[EN] Gets whether detection succeeded. [JA] detection が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets edge strength values. [JA] edge strength value を取得します。</summary>
    public IReadOnlyList<double> Values { get; init; } = [];

    /// <summary>[EN] Gets maximum edge strength. [JA] maximum edge strength を取得します。</summary>
    public double MaxEdge { get; init; }

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries binaural direction quantization input.
/// [JA] binaural direction quantization input を保持します。
/// </summary>
public sealed record BinauralDirectionQuantizationRequest
{
    /// <summary>[EN] Gets interleaved PCM samples. [JA] interleaved PCM sample を取得します。</summary>
    public IReadOnlyList<float> InterleavedSamples { get; init; } = [];

    /// <summary>[EN] Gets the number of channels. [JA] channel 数を取得します。</summary>
    public int Channels { get; init; } = 2;

    /// <summary>[EN] Gets the number of output direction bins. [JA] output direction bin 数を取得します。</summary>
    public int DirectionBins { get; init; } = 8;
}

/// <summary>
/// [EN] Carries binaural direction quantization output.
/// [JA] binaural direction quantization output を保持します。
/// </summary>
public sealed record BinauralDirectionQuantizationResult
{
    /// <summary>[EN] Gets whether quantization succeeded. [JA] quantization が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets normalized right-minus-left balance. [JA] 正規化済み right-minus-left balance を取得します。</summary>
    public double Balance { get; init; }

    /// <summary>[EN] Gets estimated signed inter-channel delay in samples. [JA] sample 単位の signed inter-channel delay 推定値を取得します。</summary>
    public int DelaySamples { get; init; }

    /// <summary>[EN] Gets direction bin index. [JA] direction bin index を取得します。</summary>
    public int DirectionIndex { get; init; }

    /// <summary>[EN] Gets direction bin name. [JA] direction bin name を取得します。</summary>
    public string DirectionName { get; init; } = "unknown";

    /// <summary>[EN] Gets normalized confidence. [JA] 正規化済み confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries frequency band split input.
/// [JA] frequency band split input を保持します。
/// </summary>
public sealed record FrequencyBandRequest
{
    /// <summary>[EN] Gets PCM samples. [JA] PCM sample を取得します。</summary>
    public IReadOnlyList<float> Samples { get; init; } = [];

    /// <summary>[EN] Gets sample rate in hertz. [JA] hertz 単位の sample rate を取得します。</summary>
    public int SampleRate { get; init; } = 48_000;

    /// <summary>[EN] Gets the number of channels. [JA] channel 数を取得します。</summary>
    public int Channels { get; init; } = 1;
}

/// <summary>
/// [EN] Carries low, mid, and high frequency band energy.
/// [JA] low / mid / high frequency band energy を保持します。
/// </summary>
public sealed record FrequencyBandEnergyResult
{
    /// <summary>[EN] Gets whether split succeeded. [JA] split が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets normalized low-band energy. [JA] 正規化済み low-band energy を取得します。</summary>
    public double LowEnergy { get; init; }

    /// <summary>[EN] Gets normalized mid-band energy. [JA] 正規化済み mid-band energy を取得します。</summary>
    public double MidEnergy { get; init; }

    /// <summary>[EN] Gets normalized high-band energy. [JA] 正規化済み high-band energy を取得します。</summary>
    public double HighEnergy { get; init; }

    /// <summary>[EN] Gets dominant band name. [JA] dominant band name を取得します。</summary>
    public string DominantBand { get; init; } = "unknown";

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries scalar Kalman filter state.
/// [JA] scalar Kalman filter state を保持します。
/// </summary>
public readonly record struct KalmanFilterState
{
    /// <summary>[EN] Gets the estimated value. [JA] estimated value を取得します。</summary>
    public double Estimate { get; init; }

    /// <summary>[EN] Gets the error covariance. [JA] error covariance を取得します。</summary>
    public double ErrorCovariance { get; init; }
}

/// <summary>
/// [EN] Carries scalar spatial hash output.
/// [JA] scalar spatial hash output を保持します。
/// </summary>
public readonly record struct SpatialHashCell
{
    /// <summary>[EN] Gets quantized X cell. [JA] 量子化済み X cell を取得します。</summary>
    public int CellX { get; init; }

    /// <summary>[EN] Gets quantized Y cell. [JA] 量子化済み Y cell を取得します。</summary>
    public int CellY { get; init; }

    /// <summary>[EN] Gets stable cell key. [JA] stable cell key を取得します。</summary>
    public string Key { get; init; }
}
