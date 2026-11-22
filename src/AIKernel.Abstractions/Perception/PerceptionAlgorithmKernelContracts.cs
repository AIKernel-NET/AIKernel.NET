namespace AIKernel.Providers.Perception;

/// <summary>
/// [EN] Provides provider-neutral perception filters and quantizers for Aisthesis to Phantasia processing.
/// [JA] Aisthesis から Phantasia への処理に使う provider-neutral な perception filter / quantizer を提供します。
/// </summary>
public interface IPerceptionAlgorithmKernel
{
    /// <summary>
    /// [EN] Quantizes RGB pixels into a semantic palette.
    /// [JA] RGB pixel を semantic palette に量子化します。
    /// </summary>
    /// <param name="request">[EN] Quantization request. [JA] 量子化 request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Quantization result. [JA] 量子化 result を返します。</returns>
    ValueTask<SemanticPaletteQuantizationResult> QuantizePaletteAsync(
        SemanticPaletteQuantizationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Calculates temporal differences between two scalar frame maps.
    /// [JA] 2 つの scalar frame map の時間差分を計算します。
    /// </summary>
    /// <param name="request">[EN] Temporal difference request. [JA] 時間差分 request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Temporal difference result. [JA] 時間差分 result を返します。</returns>
    ValueTask<TemporalDifferenceResult> CalculateTemporalDifferenceAsync(
        TemporalDifferenceRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Calculates Laplacian edge strength over a scalar frame map.
    /// [JA] scalar frame map に対する Laplacian edge strength を計算します。
    /// </summary>
    /// <param name="request">[EN] Edge detection request. [JA] edge detection request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Edge detection result. [JA] edge detection result を返します。</returns>
    ValueTask<LaplacianEdgeResult> DetectEdgesAsync(
        LaplacianEdgeRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Quantizes stereo energy balance and delay into a direction bin.
    /// [JA] stereo energy balance と delay を direction bin に量子化します。
    /// </summary>
    /// <param name="request">[EN] Binaural quantization request. [JA] binaural quantization request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Binaural direction result. [JA] binaural direction result を返します。</returns>
    ValueTask<BinauralDirectionQuantizationResult> QuantizeBinauralDirectionAsync(
        BinauralDirectionQuantizationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// [EN] Estimates low, mid, and high audio band energy.
    /// [JA] low / mid / high audio band energy を推定します。
    /// </summary>
    /// <param name="request">[EN] Frequency band request. [JA] frequency band request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Frequency band result. [JA] frequency band result を返します。</returns>
    ValueTask<FrequencyBandEnergyResult> SplitFrequencyBandsAsync(
        FrequencyBandRequest request,
        CancellationToken cancellationToken);
}
