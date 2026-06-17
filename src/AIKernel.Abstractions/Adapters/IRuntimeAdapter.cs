using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Adapters;

/// <summary>
/// EN: Attaches, detaches, controls, and probes runtime adapters.
/// [EN] Documents this public package API member. [JA] IRuntimeAdapter の公開契約を定義します。
/// </summary>
public interface IRuntimeAdapter
{
    /// <summary>
    /// EN: Attaches a runtime.
    /// [EN] Documents this public package API member. [JA] AttachAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The attach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The attach result. JA: 結果を返します。</returns>
    ValueTask<RuntimeAttachResult> AttachAsync(
        RuntimeAttachRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Detaches a runtime.
    /// [EN] Documents this public package API member. [JA] DetachAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The detach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The detach result. JA: 結果を返します。</returns>
    ValueTask<RuntimeDetachResult> DetachAsync(
        RuntimeDetachRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Controls a runtime.
    /// [EN] Documents this public package API member. [JA] ControlAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The control result. JA: 結果を返します。</returns>
    ValueTask<RuntimeControlResult> ControlAsync(
        RuntimeControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets a runtime status snapshot.
    /// [EN] Documents this public package API member. [JA] SnapshotAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> SnapshotAsync(
        RuntimeSnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Probes runtime availability.
    /// [EN] Documents this public package API member. [JA] ProbeRuntimeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The probe request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The probe result. JA: 結果を返します。</returns>
    ValueTask<RuntimeProbeResult> ProbeRuntimeAsync(
        RuntimeProbeRequest request,
        CancellationToken cancellationToken);
}
