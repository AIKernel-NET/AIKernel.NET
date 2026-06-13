using AIKernel.Dtos.Frame;
using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Frame;

/// <summary>
/// Provides frame snapshots from a source boundary.
/// </summary>
public interface IFrameSourceProvider : IProviderExtended
{
    /// <summary>
    /// Captures frame snapshots.
    /// </summary>
    /// <param name="request">The capture request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The frame snapshot stream.</returns>
    IAsyncEnumerable<FrameSnapshot> CaptureAsync(
        FrameCaptureRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Provides frames from a physical or desktop screen source.
/// </summary>
public interface IScreenFrameSourceProvider : IFrameSourceProvider
{
}

/// <summary>
/// Provides frames from a virtual runtime source.
/// </summary>
public interface IVirtualFrameSourceProvider : IFrameSourceProvider
{
    /// <summary>
    /// Lists virtual surfaces exposed by a sandbox instance.
    /// </summary>
    /// <param name="handle">The sandbox instance handle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The virtual surface descriptors.</returns>
    ValueTask<IReadOnlyList<VirtualSurfaceDescriptor>> ListSurfacesAsync(
        SandboxInstanceHandle handle,
        CancellationToken cancellationToken);
}

/// <summary>
/// Binds a frame source to a surface boundary.
/// </summary>
public interface IFrameSurfaceProvider : IProviderExtended
{
    /// <summary>
    /// Binds a frame surface.
    /// </summary>
    /// <param name="request">The binding request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The surface binding result.</returns>
    ValueTask<FrameSurfaceBinding> BindAsync(
        FrameSurfaceBindingRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
