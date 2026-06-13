using AIKernel.Dtos.Metrics;

namespace AIKernel.Abstractions.Metrics;

/// <summary>
/// Provides metrics snapshots, series, catalogs, and reset operations.
/// JA: IMetricsProvider の公開契約を定義します。
/// </summary>
public interface IMetricsProvider
{
    /// <summary>
    /// Captures a metrics snapshot.
    /// JA: SnapshotAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The metrics snapshot. JA: 結果を返します。</returns>
    ValueTask<MetricsSnapshot> SnapshotAsync(
        MetricsSnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Queries metric points.
    /// JA: QuerySeriesAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The series query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The metric points. JA: 結果を返します。</returns>
    IAsyncEnumerable<MetricPoint> QuerySeriesAsync(
        MetricSeriesQuery request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Describes supported metrics.
    /// JA: DescribeMetricsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The metric catalog request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The metric catalog. JA: 結果を返します。</returns>
    ValueTask<MetricCatalog> DescribeMetricsAsync(
        MetricCatalogRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Resets metrics state.
    /// JA: ResetMetricsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The reset request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The reset result. JA: 結果を返します。</returns>
    ValueTask<MetricsResetResult> ResetMetricsAsync(
        MetricsResetRequest request,
        CancellationToken cancellationToken);
}
