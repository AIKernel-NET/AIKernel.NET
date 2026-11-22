namespace AIKernel.Providers.Perception;

/// <summary>
/// [EN] Exposes perception algorithms that can run either as pure managed fallbacks or resident accelerator kernels.
/// [JA] pure managed fallback または resident accelerator kernel として実行できる perception algorithm を公開します。
/// </summary>
public interface IResidentPerceptionAlgorithmKernel : IPerceptionAlgorithmKernel
{
    /// <summary>
    /// [EN] Converts RGB pixels to HSV and emits a threshold mask.
    /// [JA] RGB pixel を HSV に変換し threshold mask を出力します。
    /// </summary>
    /// <param name="request">[EN] HSV mask request. [JA] HSV mask request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] HSV mask result. [JA] HSV mask result を返します。</returns>
    ValueTask<HsvThresholdMaskResult> CreateHsvThresholdMaskAsync(
        HsvThresholdMaskRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Performs max-pooling downsampling while preserving high-importance values.
    /// [JA] high-importance value を保持しながら max-pooling downsampling を実行します。
    /// </summary>
    /// <param name="request">[EN] Max pooling request. [JA] max pooling request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Max pooling result. [JA] max pooling result を返します。</returns>
    ValueTask<MaxPoolingResult> MaxPoolAsync(
        MaxPoolingRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Applies morphology dilation or erosion over a scalar mask.
    /// [JA] scalar mask に morphology dilation または erosion を適用します。
    /// </summary>
    /// <param name="request">[EN] Morphology request. [JA] morphology request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Morphology result. [JA] morphology result を返します。</returns>
    ValueTask<MorphologyResult> ApplyMorphologyAsync(
        MorphologyRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Estimates dense optical flow vectors between two scalar frames.
    /// [JA] 2 つの scalar frame 間の dense optical flow vector を推定します。
    /// </summary>
    /// <param name="request">[EN] Optical flow request. [JA] optical flow request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Optical flow result. [JA] optical flow result を返します。</returns>
    ValueTask<DenseOpticalFlowResult> EstimateDenseOpticalFlowAsync(
        DenseOpticalFlowRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Computes an FFT-like spectrum carrier for audio perception.
    /// [JA] auditory perception 用の FFT 風 spectrum carrier を計算します。
    /// </summary>
    /// <param name="request">[EN] Spectrum request. [JA] spectrum request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Spectrum result. [JA] spectrum result を返します。</returns>
    ValueTask<AudioSpectrumResult> ComputeAudioSpectrumAsync(
        AudioSpectrumRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Applies an exponential moving average to scalar streams.
    /// [JA] scalar stream に exponential moving average を適用します。
    /// </summary>
    /// <param name="request">[EN] EMA request. [JA] EMA request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] EMA result. [JA] EMA result を返します。</returns>
    ValueTask<EmaFilterResult> ApplyEmaAsync(
        EmaFilterRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Applies a leaky integrator to scalar streams.
    /// [JA] scalar stream に leaky integrator を適用します。
    /// </summary>
    /// <param name="request">[EN] Leaky integrator request. [JA] leaky integrator request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Leaky integrator result. [JA] leaky integrator result を返します。</returns>
    ValueTask<LeakyIntegratorResult> ApplyLeakyIntegratorAsync(
        LeakyIntegratorRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Quantizes points into grid-based spatial hash cells.
    /// [JA] point を grid-based spatial hash cell に量子化します。
    /// </summary>
    /// <param name="request">[EN] Spatial hash request. [JA] spatial hash request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Spatial hash result. [JA] spatial hash result を返します。</returns>
    ValueTask<SpatialHashResult> QuantizeSpatialHashAsync(
        SpatialHashRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Applies scalar Kalman filter updates.
    /// [JA] scalar Kalman filter update を適用します。
    /// </summary>
    /// <param name="request">[EN] Kalman filter request. [JA] Kalman filter request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Kalman filter result. [JA] Kalman filter result を返します。</returns>
    ValueTask<KalmanFilterResult> ApplyKalmanAsync(
        KalmanFilterRequest request,
        CancellationToken cancellationToken);
}
