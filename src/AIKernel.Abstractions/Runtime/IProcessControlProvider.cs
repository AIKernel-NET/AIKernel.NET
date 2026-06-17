using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// EN: Provides process control operations without changing the base sandbox process provider.
/// [EN] Documents this public package API member. [JA] IProcessControlProvider の公開契約を定義します。
/// </summary>
public interface IProcessControlProvider : ISandboxProcessProvider
{
    /// <summary>
    /// EN: Lists processes.
    /// [EN] Documents this public package API member. [JA] ListProcessesAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The process list request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The process list result. JA: 結果を返します。</returns>
    ValueTask<ProcessListResult> ListProcessesAsync(
        ProcessListRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets a process descriptor.
    /// [EN] Documents this public package API member. [JA] GetProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The process query request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The process descriptor. JA: 結果を返します。</returns>
    ValueTask<ProcessDescriptor> GetProcessAsync(
        ProcessQueryRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Controls a process.
    /// [EN] Documents this public package API member. [JA] ControlProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The process control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The process control result. JA: 結果を返します。</returns>
    ValueTask<ProcessControlResult> ControlProcessAsync(
        ProcessControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Attaches a process.
    /// [EN] Documents this public package API member. [JA] AttachProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The process attach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The process attach result. JA: 結果を返します。</returns>
    ValueTask<ProcessAttachResult> AttachProcessAsync(
        ProcessAttachRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Detaches a process.
    /// [EN] Documents this public package API member. [JA] DetachProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The process detach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The process detach result. JA: 結果を返します。</returns>
    ValueTask<ProcessDetachResult> DetachProcessAsync(
        ProcessDetachRequest request,
        CancellationToken cancellationToken);
}
