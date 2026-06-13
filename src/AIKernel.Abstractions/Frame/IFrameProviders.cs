using AIKernel.Dtos.Frame;
using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Frame;

/// <summary>
/// Provides frame snapshots from a source boundary.
/// JA: IFrameSourceProvider の公開契約を定義します。
/// </summary>
public interface IFrameSourceProvider : IKernelProvider
{
    /// <summary>
    /// Captures frame snapshots.
    /// JA: CaptureAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The capture request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The frame snapshot stream. JA: 結果を返します。</returns>
    IAsyncEnumerable<FrameSnapshot> CaptureAsync(
        FrameCaptureRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Provides frames from a physical or desktop screen source.
/// JA: IScreenFrameSourceProvider の公開契約を定義します。
/// </summary>
public interface IScreenFrameSourceProvider : IFrameSourceProvider
{
}

/// <summary>
/// Provides frames from a virtual runtime source.
/// JA: IVirtualFrameSourceProvider の公開契約を定義します。
/// </summary>
public interface IVirtualFrameSourceProvider : IFrameSourceProvider
{
    /// <summary>
    /// Lists virtual surfaces exposed by a sandbox instance.
    /// JA: ListSurfacesAsync 操作を実行します。
    /// </summary>
    /// <param name="handle">The sandbox instance handle. JA: handle パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The virtual surface descriptors. JA: 結果を返します。</returns>
    ValueTask<IReadOnlyList<VirtualSurfaceDescriptor>> ListSurfacesAsync(
        SandboxInstanceHandle handle,
        CancellationToken cancellationToken);
}

/// <summary>
/// Binds a frame source to a surface boundary.
/// JA: IFrameSurfaceProvider の公開契約を定義します。
/// </summary>
public interface IFrameSurfaceProvider : IKernelProvider
{
    /// <summary>
    /// Binds a frame surface.
    /// JA: BindAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The binding request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The surface binding result. JA: 結果を返します。</returns>
    ValueTask<FrameSurfaceBinding> BindAsync(
        FrameSurfaceBindingRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
