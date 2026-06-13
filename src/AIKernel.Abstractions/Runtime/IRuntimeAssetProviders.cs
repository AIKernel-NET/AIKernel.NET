using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// Resolves runtime artifacts without exposing technology-specific names.
/// </summary>
public interface IRuntimeAssetResolver : IProviderExtended
{
    /// <summary>
    /// Resolves a runtime asset request.
    /// </summary>
    /// <param name="request">The runtime asset request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The asset resolution result.</returns>
    ValueTask<RuntimeAssetResolutionResult> ResolveAsync(
        RuntimeAssetRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Mounts resolved artifacts into a memory-backed runtime boundary.
/// </summary>
public interface IMemoryAssetMountProvider : IProviderExtended
{
    /// <summary>
    /// Mounts an asset into memory.
    /// </summary>
    /// <param name="request">The mount request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The mount result.</returns>
    ValueTask<MemoryAssetMountResult> MountAsync(
        MemoryAssetMountRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
