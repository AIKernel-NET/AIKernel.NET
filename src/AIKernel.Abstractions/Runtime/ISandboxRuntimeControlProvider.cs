using AIKernel.Dtos.Runtime;
using AIKernel.Dtos.Telemetry;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// Provides sandbox runtime control operations without changing the base sandbox runtime provider.
/// JA: ISandboxRuntimeControlProvider の公開契約を定義します。
/// </summary>
public interface ISandboxRuntimeControlProvider : ISandboxRuntimeProvider
{
    /// <summary>
    /// Starts a runtime.
    /// JA: StartAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The control result. JA: 結果を返します。</returns>
    ValueTask<RuntimeControlResult> StartAsync(
        RuntimeControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Stops a runtime.
    /// JA: StopAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The control result. JA: 結果を返します。</returns>
    ValueTask<RuntimeControlResult> StopAsync(
        RuntimeControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Restarts a runtime.
    /// JA: RestartAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The control result. JA: 結果を返します。</returns>
    ValueTask<RuntimeControlResult> RestartAsync(
        RuntimeControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Attaches a runtime.
    /// JA: AttachAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The attach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The attach result. JA: 結果を返します。</returns>
    ValueTask<RuntimeAttachResult> AttachAsync(
        RuntimeAttachRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Detaches a runtime.
    /// JA: DetachAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The detach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The detach result. JA: 結果を返します。</returns>
    ValueTask<RuntimeDetachResult> DetachAsync(
        RuntimeDetachRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets runtime status.
    /// JA: GetStatusAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> GetStatusAsync(
        RuntimeSnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets runtime telemetry.
    /// JA: GetTelemetryAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The telemetry snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The telemetry snapshot. JA: 結果を返します。</returns>
    ValueTask<TelemetrySnapshot> GetTelemetryAsync(
        TelemetrySnapshotRequest request,
        CancellationToken cancellationToken);
}
