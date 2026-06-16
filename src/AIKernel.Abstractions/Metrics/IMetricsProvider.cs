using AIKernel.Dtos.Metrics;

namespace AIKernel.Abstractions.Metrics;

/// <summary>
/// EN: Provides metrics snapshots, series, catalogs, and reset operations.
/// [EN] Documents this public package API member. [JA] IMetricsProvider の公開契約を定義します。
/// </summary>
public interface IMetricsProvider
{
    /// <summary>
    /// EN: Captures a metrics snapshot.
    /// [EN] Documents this public package API member. [JA] SnapshotAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The metrics snapshot. JA: 結果を返します。</returns>
    ValueTask<MetricsSnapshot> SnapshotAsync(
        MetricsSnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Queries metric points.
    /// [EN] Documents this public package API member. [JA] QuerySeriesAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The series query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The metric points. JA: 結果を返します。</returns>
    IAsyncEnumerable<MetricPoint> QuerySeriesAsync(
        MetricSeriesQuery request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Describes supported metrics.
    /// [EN] Documents this public package API member. [JA] DescribeMetricsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The metric catalog request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The metric catalog. JA: 結果を返します。</returns>
    ValueTask<MetricCatalog> DescribeMetricsAsync(
        MetricCatalogRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Resets metrics state.
    /// [EN] Documents this public package API member. [JA] ResetMetricsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The reset request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The reset result. JA: 結果を返します。</returns>
    ValueTask<MetricsResetResult> ResetMetricsAsync(
        MetricsResetRequest request,
        CancellationToken cancellationToken);
}
