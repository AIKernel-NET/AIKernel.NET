using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Telemetry;

namespace AIKernel.Abstractions.Telemetry;

/// <summary>
/// EN: Captures runtime telemetry snapshots.
/// [EN] Documents this public package API member. [JA] IRuntimeTelemetryProvider の公開契約を定義します。
/// </summary>
public interface IRuntimeTelemetryProvider : IKernelProvider
{
    /// <summary>
    /// EN: Captures a runtime telemetry snapshot.
    /// [EN] Documents this public package API member. [JA] CaptureTelemetryAsync 操作を実行します。
    /// </summary>
    /// <param name="runtimeId">EN: The runtime identifier. JA: runtimeId パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The telemetry snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeTelemetrySnapshot> CaptureTelemetryAsync(
        string runtimeId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets runtime telemetry.
    /// [EN] Documents this public package API member. [JA] GetTelemetryAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The telemetry request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The telemetry snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeTelemetrySnapshot> GetTelemetryAsync(
        RuntimeTelemetryRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Captures evidence without mutating runtime state.
/// [EN] Documents this public package API member. [JA] IEvidenceCaptureProvider の公開契約を定義します。
/// </summary>
public interface IEvidenceCaptureProvider : IKernelProvider
{
    /// <summary>
    /// EN: Captures an evidence bundle.
    /// [EN] Documents this public package API member. [JA] CaptureAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The evidence capture request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The evidence bundle. JA: 結果を返します。</returns>
    ValueTask<EvidenceBundle> CaptureAsync(
        EvidenceCaptureRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Records replay evidence for deterministic audit.
/// [EN] Documents this public package API member. [JA] IReplayEvidenceProvider の公開契約を定義します。
/// </summary>
public interface IReplayEvidenceProvider : IKernelProvider
{
    /// <summary>
    /// EN: Records replay evidence.
    /// [EN] Documents this public package API member. [JA] RecordAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The replay evidence request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The replay evidence record. JA: 結果を返します。</returns>
    ValueTask<ReplayEvidenceRecord> RecordAsync(
        ReplayEvidenceRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
