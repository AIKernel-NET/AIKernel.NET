namespace AIKernel.Providers.Perception;

/// <summary>
/// [EN] Analyzes provider-neutral frame descriptors.
/// [JA] Provider に依存しないフレーム記述子を解析します。
/// </summary>
public interface IFramePerceptionProvider
{
    /// <summary>[EN] Analyzes a frame perception request. [JA] フレーム知覚要求を解析します。</summary>
    ValueTask<FramePerceptionProviderResult> AnalyzeFrameAsync(
        FramePerceptionProviderRequest request,
        CancellationToken cancellationToken);
}
