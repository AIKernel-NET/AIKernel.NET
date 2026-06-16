using AIKernel.Dtos.Runtime;
using AIKernel.Dtos.Telemetry;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// EN: Provides sandbox runtime control operations without changing the base sandbox runtime provider.
/// EN: Documentation for public API. JA: ISandboxRuntimeControlProvider の公開契約を定義します。
/// </summary>
public interface ISandboxRuntimeControlProvider : ISandboxRuntimeProvider
{
    /// <summary>
    /// EN: Starts a runtime.
    /// EN: Documentation for public API. JA: StartAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The control result. JA: 結果を返します。</returns>
    ValueTask<RuntimeControlResult> StartAsync(
        RuntimeControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Stops a runtime.
    /// EN: Documentation for public API. JA: StopAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The control result. JA: 結果を返します。</returns>
    ValueTask<RuntimeControlResult> StopAsync(
        RuntimeControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Restarts a runtime.
    /// EN: Documentation for public API. JA: RestartAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The control result. JA: 結果を返します。</returns>
    ValueTask<RuntimeControlResult> RestartAsync(
        RuntimeControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Attaches a runtime.
    /// EN: Documentation for public API. JA: AttachAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The attach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The attach result. JA: 結果を返します。</returns>
    ValueTask<RuntimeAttachResult> AttachAsync(
        RuntimeAttachRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Detaches a runtime.
    /// EN: Documentation for public API. JA: DetachAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The detach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The detach result. JA: 結果を返します。</returns>
    ValueTask<RuntimeDetachResult> DetachAsync(
        RuntimeDetachRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets runtime status.
    /// EN: Documentation for public API. JA: GetStatusAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> GetStatusAsync(
        RuntimeSnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets runtime telemetry.
    /// EN: Documentation for public API. JA: GetTelemetryAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The telemetry snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The telemetry snapshot. JA: 結果を返します。</returns>
    ValueTask<TelemetrySnapshot> GetTelemetryAsync(
        TelemetrySnapshotRequest request,
        CancellationToken cancellationToken);
}
