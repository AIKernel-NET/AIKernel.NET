using AIKernel.Dtos.Telemetry;

namespace AIKernel.Abstractions.Telemetry;

/// <summary>
/// EN: Provides telemetry snapshots, streams, catalogs, and reset operations.
/// EN: Documentation for public API. JA: ITelemetryProvider の公開契約を定義します。
/// </summary>
public interface ITelemetryProvider
{
    /// <summary>
    /// EN: Captures a telemetry snapshot.
    /// EN: Documentation for public API. JA: SnapshotAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The telemetry snapshot. JA: 結果を返します。</returns>
    ValueTask<TelemetrySnapshot> SnapshotAsync(
        TelemetrySnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Streams telemetry snapshots.
    /// EN: Documentation for public API. JA: StreamAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The stream request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The telemetry snapshots. JA: 結果を返します。</returns>
    IAsyncEnumerable<TelemetrySnapshot> StreamAsync(
        TelemetryStreamRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Describes telemetry signals.
    /// EN: Documentation for public API. JA: DescribeSignalsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The signal catalog request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The telemetry signal catalog. JA: 結果を返します。</returns>
    ValueTask<TelemetrySignalCatalog> DescribeSignalsAsync(
        TelemetrySignalCatalogRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Resets telemetry state.
    /// EN: Documentation for public API. JA: ResetTelemetryAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The reset request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The reset result. JA: 結果を返します。</returns>
    ValueTask<TelemetryResetResult> ResetTelemetryAsync(
        TelemetryResetRequest request,
        CancellationToken cancellationToken);
}
