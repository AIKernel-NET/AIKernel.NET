using AIKernel.Dtos.Observability;

namespace AIKernel.Abstractions.Observability;

/// <summary>
/// EN: Captures evidence bundles and evidence items.
/// EN: Documentation for public API. JA: IEvidenceCollector の公開契約を定義します。
/// </summary>
public interface IEvidenceCollector
{
    /// <summary>
    /// EN: Captures an evidence bundle.
    /// EN: Documentation for public API. JA: CaptureAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The capture request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The evidence bundle. JA: 結果を返します。</returns>
    ValueTask<EvidenceBundle> CaptureAsync(
        EvidenceCaptureRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Captures frame evidence.
    /// EN: Documentation for public API. JA: CaptureFrameAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The frame capture request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The evidence item. JA: 結果を返します。</returns>
    ValueTask<EvidenceItem> CaptureFrameAsync(
        EvidenceFrameCaptureRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Captures log evidence.
    /// EN: Documentation for public API. JA: CaptureLogsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The log capture request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The evidence item. JA: 結果を返します。</returns>
    ValueTask<EvidenceItem> CaptureLogsAsync(
        EvidenceLogCaptureRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Captures diagnostic evidence.
    /// EN: Documentation for public API. JA: CaptureDiagnosticsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The diagnostic capture request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The evidence item. JA: 結果を返します。</returns>
    ValueTask<EvidenceItem> CaptureDiagnosticsAsync(
        EvidenceDiagnosticsCaptureRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Exports an evidence bundle.
    /// EN: Documentation for public API. JA: ExportBundleAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The export request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The export result. JA: 結果を返します。</returns>
    ValueTask<EvidenceExportResult> ExportBundleAsync(
        EvidenceExportRequest request,
        CancellationToken cancellationToken);
}
