using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// Manages sandbox runtime lifecycle operations.
/// JA: ISandboxRuntimeProvider の公開契約を定義します。
/// </summary>
public interface ISandboxRuntimeProvider : IKernelProvider
{
    /// <summary>
    /// Ensures the runtime is prepared and ready.
    /// JA: EnsureReadyAsync 操作を実行します。
    /// </summary>
    /// <param name="context">The preparation context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The preparation result. JA: 結果を返します。</returns>
    ValueTask<SandboxRuntimePreparationResult> EnsureReadyAsync(
        ProviderPreparationContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Starts a sandbox runtime.
    /// JA: StartAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The start request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The start result. JA: 結果を返します。</returns>
    ValueTask<SandboxRuntimeStartResult> StartAsync(
        SandboxRuntimeStartRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Stops a sandbox runtime.
    /// JA: StopAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The stop request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The stop result. JA: 結果を返します。</returns>
    ValueTask<SandboxRuntimeStopResult> StopAsync(
        SandboxRuntimeStopRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Manages sandbox process snapshots.
/// JA: ISandboxProcessProvider の公開契約を定義します。
/// </summary>
public interface ISandboxProcessProvider : IKernelProvider
{
    /// <summary>
    /// Creates a sandbox process.
    /// JA: CreateProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The process creation request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The process snapshot. JA: 結果を返します。</returns>
    ValueTask<SandboxProcessSnapshot> CreateProcessAsync(
        SandboxProcessCreateRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a sandbox process snapshot.
    /// JA: GetProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="processId">The process identifier. JA: processId パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The process snapshot. JA: 結果を返します。</returns>
    ValueTask<SandboxProcessSnapshot> GetProcessAsync(
        string processId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Lists sandbox processes for an instance.
    /// JA: ListProcessesAsync 操作を実行します。
    /// </summary>
    /// <param name="handle">The sandbox instance handle. JA: handle パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The sandbox process descriptors. JA: 結果を返します。</returns>
    ValueTask<IReadOnlyList<SandboxProcessDescriptor>> ListProcessesAsync(
        SandboxInstanceHandle handle,
        CancellationToken cancellationToken);
}

/// <summary>
/// Provides runtime status and health snapshots.
/// JA: IRuntimeStatusProvider の公開契約を定義します。
/// </summary>
public interface IRuntimeStatusProvider : IKernelProvider
{
    /// <summary>
    /// Gets a runtime status snapshot.
    /// JA: GetStatusAsync 操作を実行します。
    /// </summary>
    /// <param name="runtimeId">The runtime identifier. JA: runtimeId パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> GetStatusAsync(
        string runtimeId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a runtime status snapshot.
    /// JA: GetStatusAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The runtime status request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> GetStatusAsync(
        RuntimeStatusRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// Provides start, stop, and health-check lifecycle operations.
/// JA: ILifecycleManager の公開契約を定義します。
/// </summary>
public interface ILifecycleManager
{
    /// <summary>
    /// Starts the managed lifecycle.
    /// JA: StartAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    ValueTask StartAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Stops the managed lifecycle.
    /// JA: StopAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    ValueTask StopAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Runs a health check.
    /// JA: HealthCheckAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> HealthCheckAsync(CancellationToken cancellationToken);
}
