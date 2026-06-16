using AIKernel.Dtos.Perception;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// EN: Builds debug or evidence overlay annotation DTOs without rendering them.
/// EN: Documentation for public API. JA: IOverlayAnnotationProvider の公開契約を定義します。
/// </summary>
public interface IOverlayAnnotationProvider
{
    /// <summary>
    /// EN: Builds overlay annotations.
    /// EN: Documentation for public API. JA: BuildOverlayAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The overlay annotation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The overlay annotation set. JA: 結果を返します。</returns>
    ValueTask<OverlayAnnotationSet> BuildOverlayAsync(
        OverlayAnnotationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Describes supported overlay layers.
    /// EN: Documentation for public API. JA: DescribeLayersAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The overlay layer catalog request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The overlay layer catalog. JA: 結果を返します。</returns>
    ValueTask<OverlayLayerCatalog> DescribeLayersAsync(
        OverlayLayerCatalogRequest request,
        CancellationToken cancellationToken);
}
