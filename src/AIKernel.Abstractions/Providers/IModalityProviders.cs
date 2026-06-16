using AIKernel.Dtos.Cognition;

namespace AIKernel.Abstractions.Providers;

/// <summary>
/// EN: Captures visual semantic material as sensory snapshots without deciding actions. JA: 行動を決定せず視覚的意味材料を感覚スナップショットとして取得します。
/// </summary>
public interface IVisionProvider : IProvider
{
    /// <summary>
    /// EN: Captures visual sensory material. JA: 視覚感覚材料を取得します。
    /// </summary>
    /// <param name="request">EN: The sensory request. JA: 感覚要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The sensory snapshot. JA: 感覚スナップショットを返します。</returns>
    ValueTask<AisthesisSnapshot> CaptureVisionAsync(AisthesisRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Captures audio semantic material as sensory snapshots without deciding actions. JA: 行動を決定せず聴覚的意味材料を感覚スナップショットとして取得します。
/// </summary>
public interface IAudioProvider : IProvider
{
    /// <summary>
    /// EN: Captures audio sensory material. JA: 聴覚感覚材料を取得します。
    /// </summary>
    /// <param name="request">EN: The sensory request. JA: 感覚要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The sensory snapshot. JA: 感覚スナップショットを返します。</returns>
    ValueTask<AisthesisSnapshot> CaptureAudioAsync(AisthesisRequest request, CancellationToken cancellationToken);
}
