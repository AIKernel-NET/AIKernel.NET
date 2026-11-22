namespace AIKernel.Providers.Perception;

/// <summary>
/// [EN] Performs provider-neutral frame perception without owning browser or scenario-specific runtime code.
/// [JA] browser や scenario 固有 runtime code を所有せず provider-neutral な frame perception を実行します。
/// </summary>
public interface IFramePerceptionProvider
{
    /// <summary>
    /// [EN] Analyzes a frame perception request.
    /// [JA] frame perception request を解析します。
    /// </summary>
    /// <param name="request">[EN] Frame perception request. [JA] frame perception request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Frame perception result. [JA] frame perception result を返します。</returns>
    ValueTask<FramePerceptionProviderResult> AnalyzeFrameAsync(
        FramePerceptionProviderRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// [EN] Performs provider-neutral auditory perception over PCM-like descriptors.
/// [JA] PCM 風 descriptor に対する provider-neutral な auditory perception を実行します。
/// </summary>
public interface IAuditoryPerceptionProvider
{
    /// <summary>
    /// [EN] Analyzes an auditory perception request.
    /// [JA] auditory perception request を解析します。
    /// </summary>
    /// <param name="request">[EN] Auditory perception request. [JA] auditory perception request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Auditory perception result. [JA] auditory perception result を返します。</returns>
    ValueTask<AuditoryPerceptionResult> AnalyzeAudioAsync(
        AuditoryPerceptionRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// [EN] Composes perception outputs into provider-neutral spatial cognition snapshots.
/// [JA] perception output を provider-neutral な spatial cognition snapshot に合成します。
/// </summary>
public interface ISpatialCognitionProvider
{
    /// <summary>
    /// [EN] Builds a spatial cognition snapshot.
    /// [JA] spatial cognition snapshot を構築します。
    /// </summary>
    /// <param name="request">[EN] Spatial cognition request. [JA] spatial cognition request です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Spatial cognition snapshot. [JA] spatial cognition snapshot を返します。</returns>
    ValueTask<SpatialCognitionSnapshot> BuildSnapshotAsync(
        SpatialCognitionRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// [EN] Normalizes arbitrary sensor inputs into a deterministic sensor map.
/// [JA] 任意の sensor input を deterministic な sensor map に正規化します。
/// </summary>
public interface ISensorStateNormalizer
{
    /// <summary>
    /// [EN] Normalizes named sensor inputs for downstream cognition.
    /// [JA] downstream cognition 用に名前付き sensor input を正規化します。
    /// </summary>
    /// <param name="sensorInputs">[EN] Raw named sensor inputs. [JA] raw な名前付き sensor input です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Normalized sensor map. [JA] 正規化済み sensor map を返します。</returns>
    ValueTask<IReadOnlyDictionary<string, SensorStateDescriptor>> NormalizeAsync(
        IReadOnlyDictionary<string, SensorStateDescriptor> sensorInputs,
        CancellationToken cancellationToken);
}

/// <summary>
/// [EN] Fuses normalized sensor inputs into provider-neutral spatial cognition carriers.
/// [JA] 正規化済み sensor input を provider-neutral な spatial cognition carrier に融合します。
/// </summary>
public interface ISpatialSensorFusionKernel
{
    /// <summary>
    /// [EN] Fuses named sensor inputs into a spatial vector.
    /// [JA] 名前付き sensor input を spatial vector に融合します。
    /// </summary>
    /// <param name="sensorInputs">[EN] Named sensor inputs. [JA] 名前付き sensor input です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Fused spatial vector. [JA] 融合済み spatial vector を返します。</returns>
    ValueTask<SpatialFusionVector> FuseAsync(
        IReadOnlyDictionary<string, SensorStateDescriptor> sensorInputs,
        CancellationToken cancellationToken);
}

/// <summary>
/// [EN] Resolves high-priority retry intent from normalized sensor inputs.
/// [JA] 正規化済み sensor input から高優先 retry intent を解決します。
/// </summary>
public interface IRetryIntentResolver
{
    /// <summary>
    /// [EN] Resolves retry intent without invoking Control or Gate logic.
    /// [JA] Control / Gate logic を呼び出さず retry intent を解決します。
    /// </summary>
    /// <param name="sensorInputs">[EN] Named sensor inputs. [JA] 名前付き sensor input です。</param>
    /// <param name="cancellationToken">[EN] Cancellation token. [JA] キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Retry carrier when requested; otherwise null. [JA] retry 要求時は retry carrier、それ以外は null を返します。</returns>
    ValueTask<RetryIntentCarrier?> ResolveAsync(
        IReadOnlyDictionary<string, SensorStateDescriptor> sensorInputs,
        CancellationToken cancellationToken);
}
