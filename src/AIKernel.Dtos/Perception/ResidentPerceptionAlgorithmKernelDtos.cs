namespace AIKernel.Providers.Perception;

/// <summary>
/// [EN] Carries RGB to HSV threshold mask input.
/// [JA] RGB から HSV threshold mask への input を保持します。
/// </summary>
public sealed record HsvThresholdMaskRequest
{
    /// <summary>[EN] Gets packed RGB bytes. [JA] packed RGB byte を取得します。</summary>
    public IReadOnlyList<byte> RgbBytes { get; init; } = [];

    /// <summary>[EN] Gets frame width. [JA] frame width を取得します。</summary>
    public int Width { get; init; }

    /// <summary>[EN] Gets frame height. [JA] frame height を取得します。</summary>
    public int Height { get; init; }

    /// <summary>[EN] Gets the minimum hue in degrees. [JA] degree 単位の minimum hue を取得します。</summary>
    public double MinHue { get; init; }

    /// <summary>[EN] Gets the maximum hue in degrees. [JA] degree 単位の maximum hue を取得します。</summary>
    public double MaxHue { get; init; } = 360;

    /// <summary>[EN] Gets the minimum saturation. [JA] minimum saturation を取得します。</summary>
    public double MinSaturation { get; init; }

    /// <summary>[EN] Gets the minimum value. [JA] minimum value を取得します。</summary>
    public double MinValue { get; init; }

    /// <summary>[EN] Gets whether value should be ignored after conversion. [JA] 変換後に value を無視するかどうかを取得します。</summary>
    public bool IgnoreValue { get; init; }
}

/// <summary>
/// [EN] Carries RGB to HSV threshold mask output.
/// [JA] RGB から HSV threshold mask への output を保持します。
/// </summary>
public sealed record HsvThresholdMaskResult
{
    /// <summary>[EN] Gets whether mask creation succeeded. [JA] mask creation が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets binary mask values. [JA] binary mask value を取得します。</summary>
    public IReadOnlyList<byte> Mask { get; init; } = [];

    /// <summary>[EN] Gets matched pixel ratio. [JA] matched pixel ratio を取得します。</summary>
    public double MatchRatio { get; init; }

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries max-pooling input.
/// [JA] max-pooling input を保持します。
/// </summary>
public sealed record MaxPoolingRequest
{
    /// <summary>[EN] Gets scalar input values. [JA] scalar input value を取得します。</summary>
    public IReadOnlyList<double> Values { get; init; } = [];

    /// <summary>[EN] Gets input width. [JA] input width を取得します。</summary>
    public int Width { get; init; }

    /// <summary>[EN] Gets input height. [JA] input height を取得します。</summary>
    public int Height { get; init; }

    /// <summary>[EN] Gets output width. [JA] output width を取得します。</summary>
    public int OutputWidth { get; init; }

    /// <summary>[EN] Gets output height. [JA] output height を取得します。</summary>
    public int OutputHeight { get; init; }
}

/// <summary>
/// [EN] Carries max-pooling output.
/// [JA] max-pooling output を保持します。
/// </summary>
public sealed record MaxPoolingResult
{
    /// <summary>[EN] Gets whether pooling succeeded. [JA] pooling が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets pooled values. [JA] pooled value を取得します。</summary>
    public IReadOnlyList<double> Values { get; init; } = [];

    /// <summary>[EN] Gets output width. [JA] output width を取得します。</summary>
    public int OutputWidth { get; init; }

    /// <summary>[EN] Gets output height. [JA] output height を取得します。</summary>
    public int OutputHeight { get; init; }

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries morphology input.
/// [JA] morphology input を保持します。
/// </summary>
public sealed record MorphologyRequest
{
    /// <summary>[EN] Gets scalar mask values. [JA] scalar mask value を取得します。</summary>
    public IReadOnlyList<double> Values { get; init; } = [];

    /// <summary>[EN] Gets mask width. [JA] mask width を取得します。</summary>
    public int Width { get; init; }

    /// <summary>[EN] Gets mask height. [JA] mask height を取得します。</summary>
    public int Height { get; init; }

    /// <summary>[EN] Gets operation name such as dilation or erosion. [JA] dilation / erosion などの operation 名を取得します。</summary>
    public string Operation { get; init; } = "dilation";

    /// <summary>[EN] Gets neighborhood radius. [JA] neighborhood radius を取得します。</summary>
    public int Radius { get; init; } = 1;
}

/// <summary>
/// [EN] Carries morphology output.
/// [JA] morphology output を保持します。
/// </summary>
public sealed record MorphologyResult
{
    /// <summary>[EN] Gets whether morphology succeeded. [JA] morphology が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets morphology output values. [JA] morphology output value を取得します。</summary>
    public IReadOnlyList<double> Values { get; init; } = [];

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries dense optical flow input.
/// [JA] dense optical flow input を保持します。
/// </summary>
public sealed record DenseOpticalFlowRequest
{
    /// <summary>[EN] Gets previous scalar frame values. [JA] previous scalar frame value を取得します。</summary>
    public IReadOnlyList<double> Previous { get; init; } = [];

    /// <summary>[EN] Gets current scalar frame values. [JA] current scalar frame value を取得します。</summary>
    public IReadOnlyList<double> Current { get; init; } = [];

    /// <summary>[EN] Gets frame width. [JA] frame width を取得します。</summary>
    public int Width { get; init; }

    /// <summary>[EN] Gets frame height. [JA] frame height を取得します。</summary>
    public int Height { get; init; }

    /// <summary>[EN] Gets local search radius. [JA] local search radius を取得します。</summary>
    public int SearchRadius { get; init; } = 1;
}

/// <summary>
/// [EN] Carries one optical flow vector.
/// [JA] 1 つの optical flow vector を保持します。
/// </summary>
public readonly record struct OpticalFlowVector
{
    /// <summary>[EN] Gets X displacement. [JA] X displacement を取得します。</summary>
    public double X { get; init; }

    /// <summary>[EN] Gets Y displacement. [JA] Y displacement を取得します。</summary>
    public double Y { get; init; }

    /// <summary>[EN] Gets vector confidence. [JA] vector confidence を取得します。</summary>
    public double Confidence { get; init; }
}

/// <summary>
/// [EN] Carries dense optical flow output.
/// [JA] dense optical flow output を保持します。
/// </summary>
public sealed record DenseOpticalFlowResult
{
    /// <summary>[EN] Gets whether optical flow succeeded. [JA] optical flow が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets flow vectors per pixel. [JA] pixel ごとの flow vector を取得します。</summary>
    public IReadOnlyList<OpticalFlowVector> Vectors { get; init; } = [];

    /// <summary>[EN] Gets average X displacement. [JA] average X displacement を取得します。</summary>
    public double AverageX { get; init; }

    /// <summary>[EN] Gets average Y displacement. [JA] average Y displacement を取得します。</summary>
    public double AverageY { get; init; }

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries audio spectrum input.
/// [JA] audio spectrum input を保持します。
/// </summary>
public sealed record AudioSpectrumRequest
{
    /// <summary>[EN] Gets PCM samples. [JA] PCM sample を取得します。</summary>
    public IReadOnlyList<float> Samples { get; init; } = [];

    /// <summary>[EN] Gets sample rate in hertz. [JA] hertz 単位の sample rate を取得します。</summary>
    public int SampleRate { get; init; } = 48_000;

    /// <summary>[EN] Gets channel count. [JA] channel count を取得します。</summary>
    public int Channels { get; init; } = 1;

    /// <summary>[EN] Gets the maximum FFT size. [JA] maximum FFT size を取得します。</summary>
    public int MaxFftSize { get; init; } = 1024;
}

/// <summary>
/// [EN] Carries audio spectrum output.
/// [JA] audio spectrum output を保持します。
/// </summary>
public sealed record AudioSpectrumResult
{
    /// <summary>[EN] Gets whether spectrum calculation succeeded. [JA] spectrum calculation が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets magnitude values. [JA] magnitude value を取得します。</summary>
    public IReadOnlyList<double> Magnitudes { get; init; } = [];

    /// <summary>[EN] Gets FFT size used by calculation. [JA] calculation で使用した FFT size を取得します。</summary>
    public int FftSize { get; init; }

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries exponential moving average input.
/// [JA] exponential moving average input を保持します。
/// </summary>
public sealed record EmaFilterRequest
{
    /// <summary>[EN] Gets previous values. [JA] previous value を取得します。</summary>
    public IReadOnlyList<double> Previous { get; init; } = [];

    /// <summary>[EN] Gets current values. [JA] current value を取得します。</summary>
    public IReadOnlyList<double> Current { get; init; } = [];

    /// <summary>[EN] Gets smoothing factor. [JA] smoothing factor を取得します。</summary>
    public double Alpha { get; init; } = 0.35;
}

/// <summary>
/// [EN] Carries exponential moving average output.
/// [JA] exponential moving average output を保持します。
/// </summary>
public sealed record EmaFilterResult
{
    /// <summary>[EN] Gets whether smoothing succeeded. [JA] smoothing が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets smoothed values. [JA] smoothed value を取得します。</summary>
    public IReadOnlyList<double> Values { get; init; } = [];

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries leaky integrator input.
/// [JA] leaky integrator input を保持します。
/// </summary>
public sealed record LeakyIntegratorRequest
{
    /// <summary>[EN] Gets previous values. [JA] previous value を取得します。</summary>
    public IReadOnlyList<double> Previous { get; init; } = [];

    /// <summary>[EN] Gets input impulses. [JA] input impulse を取得します。</summary>
    public IReadOnlyList<double> Inputs { get; init; } = [];

    /// <summary>[EN] Gets leak rate. [JA] leak rate を取得します。</summary>
    public double LeakRate { get; init; } = 0.1;

    /// <summary>[EN] Gets maximum value. [JA] maximum value を取得します。</summary>
    public double MaxValue { get; init; } = 1;
}

/// <summary>
/// [EN] Carries leaky integrator output.
/// [JA] leaky integrator output を保持します。
/// </summary>
public sealed record LeakyIntegratorResult
{
    /// <summary>[EN] Gets whether integration succeeded. [JA] integration が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets integrated values. [JA] integrated value を取得します。</summary>
    public IReadOnlyList<double> Values { get; init; } = [];

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries spatial hash input.
/// [JA] spatial hash input を保持します。
/// </summary>
public sealed record SpatialHashRequest
{
    /// <summary>[EN] Gets X coordinates. [JA] X coordinate を取得します。</summary>
    public IReadOnlyList<double> X { get; init; } = [];

    /// <summary>[EN] Gets Y coordinates. [JA] Y coordinate を取得します。</summary>
    public IReadOnlyList<double> Y { get; init; } = [];

    /// <summary>[EN] Gets cell size. [JA] cell size を取得します。</summary>
    public double CellSize { get; init; } = 1;
}

/// <summary>
/// [EN] Carries spatial hash output.
/// [JA] spatial hash output を保持します。
/// </summary>
public sealed record SpatialHashResult
{
    /// <summary>[EN] Gets whether hashing succeeded. [JA] hashing が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets quantized cells. [JA] 量子化済み cell を取得します。</summary>
    public IReadOnlyList<SpatialHashCell> Cells { get; init; } = [];

    /// <summary>[EN] Gets visit counts by cell key. [JA] cell key ごとの visit count を取得します。</summary>
    public IReadOnlyDictionary<string, int> VisitCounts { get; init; } =
        new Dictionary<string, int>(StringComparer.Ordinal);

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// [EN] Carries Kalman filter input.
/// [JA] Kalman filter input を保持します。
/// </summary>
public sealed record KalmanFilterRequest
{
    /// <summary>[EN] Gets previous states. [JA] previous state を取得します。</summary>
    public IReadOnlyList<KalmanFilterState> States { get; init; } = [];

    /// <summary>[EN] Gets measurement values. [JA] measurement value を取得します。</summary>
    public IReadOnlyList<double> Measurements { get; init; } = [];

    /// <summary>[EN] Gets control deltas. [JA] control delta を取得します。</summary>
    public IReadOnlyList<double> Controls { get; init; } = [];

    /// <summary>[EN] Gets process noise. [JA] process noise を取得します。</summary>
    public double ProcessNoise { get; init; } = 0.01;

    /// <summary>[EN] Gets measurement noise. [JA] measurement noise を取得します。</summary>
    public double MeasurementNoise { get; init; } = 0.1;
}

/// <summary>
/// [EN] Carries Kalman filter output.
/// [JA] Kalman filter output を保持します。
/// </summary>
public sealed record KalmanFilterResult
{
    /// <summary>[EN] Gets whether update succeeded. [JA] update が成功したかを取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>[EN] Gets updated states. [JA] updated state を取得します。</summary>
    public IReadOnlyList<KalmanFilterState> States { get; init; } = [];

    /// <summary>[EN] Gets stable failure code. [JA] stable failure code を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>[EN] Gets human-readable failure message. [JA] 人間可読 failure message を取得します。</summary>
    public string? ErrorMessage { get; init; }
}
