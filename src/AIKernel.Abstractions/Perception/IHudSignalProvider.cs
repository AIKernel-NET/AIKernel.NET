using AIKernel.Dtos.Perception;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// Extracts lightweight HUD signals from frames or observations.
/// JA: IHudSignalProvider の公開契約を定義します。
/// </summary>
public interface IHudSignalProvider
{
    /// <summary>
    /// Extracts HUD signals.
    /// JA: ExtractAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The HUD signal request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The HUD signal set. JA: 結果を返します。</returns>
    ValueTask<HudSignalSet> ExtractAsync(
        HudSignalRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Describes supported HUD signals.
    /// JA: DescribeSignalsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The HUD signal catalog request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The HUD signal catalog. JA: 結果を返します。</returns>
    ValueTask<HudSignalCatalog> DescribeSignalsAsync(
        HudSignalCatalogRequest request,
        CancellationToken cancellationToken);
}
