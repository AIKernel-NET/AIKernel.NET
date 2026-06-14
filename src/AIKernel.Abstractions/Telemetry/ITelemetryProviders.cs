using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Telemetry;

namespace AIKernel.Abstractions.Telemetry;

/// <summary>
/// Captures runtime telemetry snapshots.
/// JA: IRuntimeTelemetryProvider の公開契約を定義します。
/// </summary>
public interface IRuntimeTelemetryProvider : IKernelProvider
{
    /// <summary>
    /// Captures a runtime telemetry snapshot.
    /// JA: CaptureTelemetryAsync 操作を実行します。
    /// </summary>
    /// <param name="runtimeId">The runtime identifier. JA: runtimeId パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The telemetry snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeTelemetrySnapshot> CaptureTelemetryAsync(
        string runtimeId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets runtime telemetry.
    /// JA: GetTelemetryAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The telemetry request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The telemetry snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeTelemetrySnapshot> GetTelemetryAsync(
        RuntimeTelemetryRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// Captures evidence without mutating runtime state.
/// JA: IEvidenceCaptureProvider の公開契約を定義します。
/// </summary>
public interface IEvidenceCaptureProvider : IKernelProvider
{
    /// <summary>
    /// Captures an evidence bundle.
    /// JA: CaptureAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The evidence capture request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The evidence bundle. JA: 結果を返します。</returns>
    ValueTask<EvidenceBundle> CaptureAsync(
        EvidenceCaptureRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Records replay evidence for deterministic audit.
/// JA: IReplayEvidenceProvider の公開契約を定義します。
/// </summary>
public interface IReplayEvidenceProvider : IKernelProvider
{
    /// <summary>
    /// Records replay evidence.
    /// JA: RecordAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The replay evidence request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The replay evidence record. JA: 結果を返します。</returns>
    ValueTask<ReplayEvidenceRecord> RecordAsync(
        ReplayEvidenceRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
