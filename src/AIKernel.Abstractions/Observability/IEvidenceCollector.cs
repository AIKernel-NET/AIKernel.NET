using AIKernel.Dtos.Observability;

namespace AIKernel.Abstractions.Observability;

/// <summary>
/// Captures evidence bundles and evidence items.
/// JA: IEvidenceCollector の公開契約を定義します。
/// </summary>
public interface IEvidenceCollector
{
    /// <summary>
    /// Captures an evidence bundle.
    /// JA: CaptureAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The capture request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The evidence bundle. JA: 結果を返します。</returns>
    ValueTask<EvidenceBundle> CaptureAsync(
        EvidenceCaptureRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Captures frame evidence.
    /// JA: CaptureFrameAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The frame capture request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The evidence item. JA: 結果を返します。</returns>
    ValueTask<EvidenceItem> CaptureFrameAsync(
        EvidenceFrameCaptureRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Captures log evidence.
    /// JA: CaptureLogsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The log capture request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The evidence item. JA: 結果を返します。</returns>
    ValueTask<EvidenceItem> CaptureLogsAsync(
        EvidenceLogCaptureRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Captures diagnostic evidence.
    /// JA: CaptureDiagnosticsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The diagnostic capture request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The evidence item. JA: 結果を返します。</returns>
    ValueTask<EvidenceItem> CaptureDiagnosticsAsync(
        EvidenceDiagnosticsCaptureRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Exports an evidence bundle.
    /// JA: ExportBundleAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The export request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The export result. JA: 結果を返します。</returns>
    ValueTask<EvidenceExportResult> ExportBundleAsync(
        EvidenceExportRequest request,
        CancellationToken cancellationToken);
}
