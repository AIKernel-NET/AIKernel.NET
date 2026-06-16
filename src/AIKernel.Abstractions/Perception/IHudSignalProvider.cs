using AIKernel.Dtos.Perception;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// EN: Extracts lightweight HUD signals from frames or observations.
/// EN: Documentation for public API. JA: IHudSignalProvider の公開契約を定義します。
/// </summary>
public interface IHudSignalProvider
{
    /// <summary>
    /// EN: Extracts HUD signals.
    /// EN: Documentation for public API. JA: ExtractAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The HUD signal request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The HUD signal set. JA: 結果を返します。</returns>
    ValueTask<HudSignalSet> ExtractAsync(
        HudSignalRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Describes supported HUD signals.
    /// EN: Documentation for public API. JA: DescribeSignalsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The HUD signal catalog request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The HUD signal catalog. JA: 結果を返します。</returns>
    ValueTask<HudSignalCatalog> DescribeSignalsAsync(
        HudSignalCatalogRequest request,
        CancellationToken cancellationToken);
}
