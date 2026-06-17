using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// EN: Manages sandbox runtime lifecycle operations.
/// [EN] Documents this public package API member. [JA] ISandboxRuntimeProvider の公開契約を定義します。
/// </summary>
public interface ISandboxRuntimeProvider : IKernelProvider
{
    /// <summary>
    /// EN: Ensures the runtime is prepared and ready.
    /// [EN] Documents this public package API member. [JA] EnsureReadyAsync 操作を実行します。
    /// </summary>
    /// <param name="context">EN: The preparation context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The preparation result. JA: 結果を返します。</returns>
    ValueTask<SandboxRuntimePreparationResult> EnsureReadyAsync(
        ProviderPreparationContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Starts a sandbox runtime.
    /// [EN] Documents this public package API member. [JA] StartAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The start request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The start result. JA: 結果を返します。</returns>
    ValueTask<SandboxRuntimeStartResult> StartAsync(
        SandboxRuntimeStartRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Stops a sandbox runtime.
    /// [EN] Documents this public package API member. [JA] StopAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The stop request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The stop result. JA: 結果を返します。</returns>
    ValueTask<SandboxRuntimeStopResult> StopAsync(
        SandboxRuntimeStopRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Manages sandbox process snapshots.
/// [EN] Documents this public package API member. [JA] ISandboxProcessProvider の公開契約を定義します。
/// </summary>
public interface ISandboxProcessProvider : IKernelProvider
{
    /// <summary>
    /// EN: Creates a sandbox process.
    /// [EN] Documents this public package API member. [JA] CreateProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The process creation request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The process snapshot. JA: 結果を返します。</returns>
    ValueTask<SandboxProcessSnapshot> CreateProcessAsync(
        SandboxProcessCreateRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets a sandbox process snapshot.
    /// [EN] Documents this public package API member. [JA] GetProcessAsync 操作を実行します。
    /// </summary>
    /// <param name="processId">EN: The process identifier. JA: processId パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The process snapshot. JA: 結果を返します。</returns>
    ValueTask<SandboxProcessSnapshot> GetProcessAsync(
        string processId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Lists sandbox processes for an instance.
    /// [EN] Documents this public package API member. [JA] ListProcessesAsync 操作を実行します。
    /// </summary>
    /// <param name="handle">EN: The sandbox instance handle. JA: handle パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The sandbox process descriptors. JA: 結果を返します。</returns>
    ValueTask<IReadOnlyList<SandboxProcessDescriptor>> ListProcessesAsync(
        SandboxInstanceHandle handle,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Provides runtime status and health snapshots.
/// [EN] Documents this public package API member. [JA] IRuntimeStatusProvider の公開契約を定義します。
/// </summary>
public interface IRuntimeStatusProvider : IKernelProvider
{
    /// <summary>
    /// EN: Gets a runtime status snapshot.
    /// [EN] Documents this public package API member. [JA] GetStatusAsync 操作を実行します。
    /// </summary>
    /// <param name="runtimeId">EN: The runtime identifier. JA: runtimeId パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> GetStatusAsync(
        string runtimeId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets a runtime status snapshot.
    /// [EN] Documents this public package API member. [JA] GetStatusAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The runtime status request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> GetStatusAsync(
        RuntimeStatusRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Provides start, stop, and health-check lifecycle operations.
/// [EN] Documents this public package API member. [JA] ILifecycleManager の公開契約を定義します。
/// </summary>
public interface ILifecycleManager
{
    /// <summary>
    /// EN: Starts the managed lifecycle.
    /// [EN] Documents this public package API member. [JA] StartAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    ValueTask StartAsync(CancellationToken cancellationToken);

    /// <summary>
    /// EN: Stops the managed lifecycle.
    /// [EN] Documents this public package API member. [JA] StopAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    ValueTask StopAsync(CancellationToken cancellationToken);

    /// <summary>
    /// EN: Runs a health check.
    /// [EN] Documents this public package API member. [JA] HealthCheckAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The runtime status snapshot. JA: 結果を返します。</returns>
    ValueTask<RuntimeStatusSnapshot> HealthCheckAsync(CancellationToken cancellationToken);
}
