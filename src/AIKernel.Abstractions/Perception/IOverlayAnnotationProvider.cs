using AIKernel.Dtos.Perception;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// Builds debug or evidence overlay annotation DTOs without rendering them.
/// JA: IOverlayAnnotationProvider の公開契約を定義します。
/// </summary>
public interface IOverlayAnnotationProvider
{
    /// <summary>
    /// Builds overlay annotations.
    /// JA: BuildOverlayAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The overlay annotation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The overlay annotation set. JA: 結果を返します。</returns>
    ValueTask<OverlayAnnotationSet> BuildOverlayAsync(
        OverlayAnnotationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Describes supported overlay layers.
    /// JA: DescribeLayersAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The overlay layer catalog request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The overlay layer catalog. JA: 結果を返します。</returns>
    ValueTask<OverlayLayerCatalog> DescribeLayersAsync(
        OverlayLayerCatalogRequest request,
        CancellationToken cancellationToken);
}
