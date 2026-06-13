using AIKernel.Dtos.Telemetry;

namespace AIKernel.Abstractions.Telemetry;

/// <summary>
/// Provides telemetry snapshots, streams, catalogs, and reset operations.
/// JA: ITelemetryProvider の公開契約を定義します。
/// </summary>
public interface ITelemetryProvider
{
    /// <summary>
    /// Captures a telemetry snapshot.
    /// JA: SnapshotAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The telemetry snapshot. JA: 結果を返します。</returns>
    ValueTask<TelemetrySnapshot> SnapshotAsync(
        TelemetrySnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Streams telemetry snapshots.
    /// JA: StreamAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The stream request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The telemetry snapshots. JA: 結果を返します。</returns>
    IAsyncEnumerable<TelemetrySnapshot> StreamAsync(
        TelemetryStreamRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Describes telemetry signals.
    /// JA: DescribeSignalsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The signal catalog request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The telemetry signal catalog. JA: 結果を返します。</returns>
    ValueTask<TelemetrySignalCatalog> DescribeSignalsAsync(
        TelemetrySignalCatalogRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Resets telemetry state.
    /// JA: ResetTelemetryAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The reset request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The reset result. JA: 結果を返します。</returns>
    ValueTask<TelemetryResetResult> ResetTelemetryAsync(
        TelemetryResetRequest request,
        CancellationToken cancellationToken);
}
