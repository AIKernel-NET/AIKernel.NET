using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// Manages sandbox runtime lifecycle operations.
/// </summary>
public interface ISandboxRuntimeProvider : IProviderExtended
{
    /// <summary>
    /// Ensures the runtime is prepared and ready.
    /// </summary>
    /// <param name="context">The preparation context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The preparation result.</returns>
    ValueTask<SandboxRuntimePreparationResult> EnsureReadyAsync(
        ProviderPreparationContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Starts a sandbox runtime.
    /// </summary>
    /// <param name="request">The start request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The start result.</returns>
    ValueTask<SandboxRuntimeStartResult> StartAsync(
        SandboxRuntimeStartRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Stops a sandbox runtime.
    /// </summary>
    /// <param name="request">The stop request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The stop result.</returns>
    ValueTask<SandboxRuntimeStopResult> StopAsync(
        SandboxRuntimeStopRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Manages sandbox process snapshots.
/// </summary>
public interface ISandboxProcessProvider : IProviderExtended
{
    /// <summary>
    /// Creates a sandbox process.
    /// </summary>
    /// <param name="request">The process creation request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The process snapshot.</returns>
    ValueTask<SandboxProcessSnapshot> CreateProcessAsync(
        SandboxProcessCreateRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a sandbox process snapshot.
    /// </summary>
    /// <param name="processId">The process identifier.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The process snapshot.</returns>
    ValueTask<SandboxProcessSnapshot> GetProcessAsync(
        string processId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Lists sandbox processes for an instance.
    /// </summary>
    /// <param name="handle">The sandbox instance handle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The sandbox process descriptors.</returns>
    ValueTask<IReadOnlyList<SandboxProcessDescriptor>> ListProcessesAsync(
        SandboxInstanceHandle handle,
        CancellationToken cancellationToken);
}

/// <summary>
/// Provides runtime status and health snapshots.
/// </summary>
public interface IRuntimeStatusProvider : IProviderExtended
{
    /// <summary>
    /// Gets a runtime status snapshot.
    /// </summary>
    /// <param name="runtimeId">The runtime identifier.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The runtime status snapshot.</returns>
    ValueTask<RuntimeStatusSnapshot> GetStatusAsync(
        string runtimeId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a runtime status snapshot.
    /// </summary>
    /// <param name="request">The runtime status request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The runtime status snapshot.</returns>
    ValueTask<RuntimeStatusSnapshot> GetStatusAsync(
        RuntimeStatusRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// Provides start, stop, and health-check lifecycle operations.
/// </summary>
public interface ILifecycleManager
{
    /// <summary>
    /// Starts the managed lifecycle.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    ValueTask StartAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Stops the managed lifecycle.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    ValueTask StopAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Runs a health check.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The runtime status snapshot.</returns>
    ValueTask<RuntimeStatusSnapshot> HealthCheckAsync(CancellationToken cancellationToken);
}
