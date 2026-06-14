using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// Provides process control operations without changing the base sandbox process provider.
/// JA: IProcessControlProvider の公開契約を定義します。
/// </summary>
public interface IProcessControlProvider : ISandboxProcessProvider
{
    /// <summary>
    /// Lists processes.
    /// JA: ListProcessesAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The process list request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The process list result. JA: 結果を返します。</returns>
    ValueTask<ProcessListResult> ListProcessesAsync(
        ProcessListRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a process descriptor.
    /// JA: GetProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The process query request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The process descriptor. JA: 結果を返します。</returns>
    ValueTask<ProcessDescriptor> GetProcessAsync(
        ProcessQueryRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Controls a process.
    /// JA: ControlProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The process control request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The process control result. JA: 結果を返します。</returns>
    ValueTask<ProcessControlResult> ControlProcessAsync(
        ProcessControlRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Attaches a process.
    /// JA: AttachProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The process attach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The process attach result. JA: 結果を返します。</returns>
    ValueTask<ProcessAttachResult> AttachProcessAsync(
        ProcessAttachRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Detaches a process.
    /// JA: DetachProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The process detach request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The process detach result. JA: 結果を返します。</returns>
    ValueTask<ProcessDetachResult> DetachProcessAsync(
        ProcessDetachRequest request,
        CancellationToken cancellationToken);
}
