using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Adapters;

/// <summary>
/// Attaches, detaches, controls, and probes runtime adapters.
/// JA: IRuntimeAdapter の公開契約を定義します。
/// </summary>
public interface IRuntimeAdapter
{
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
    /// Controls a runtime.
    /// JA: ControlAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The control result. JA: 結果を返します。</returns>
    ValueTask<RuntimeControlResult> ControlAsync(
        RuntimeControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a runtime status snapshot.
    /// JA: SnapshotAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> SnapshotAsync(
        RuntimeSnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Probes runtime availability.
    /// JA: ProbeRuntimeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The probe request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The probe result. JA: 結果を返します。</returns>
    ValueTask<RuntimeProbeResult> ProbeRuntimeAsync(
        RuntimeProbeRequest request,
        CancellationToken cancellationToken);
}
