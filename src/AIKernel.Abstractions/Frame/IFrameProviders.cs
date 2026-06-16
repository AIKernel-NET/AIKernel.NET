using AIKernel.Dtos.Frame;
using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Frame;

/// <summary>
/// EN: Provides frame snapshots from a source boundary.
/// [EN] Documents this public package API member. [JA] IFrameSourceProvider の公開契約を定義します。
/// </summary>
public interface IFrameSourceProvider : IKernelProvider
{
    /// <summary>
    /// EN: Captures frame snapshots.
    /// [EN] Documents this public package API member. [JA] CaptureAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The capture request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The frame snapshot stream. JA: 結果を返します。</returns>
    IAsyncEnumerable<FrameSnapshot> CaptureAsync(
        FrameCaptureRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Provides frames from a physical or desktop screen source.
/// [EN] Documents this public package API member. [JA] IScreenFrameSourceProvider の公開契約を定義します。
/// </summary>
public interface IScreenFrameSourceProvider : IFrameSourceProvider
{
}

/// <summary>
/// EN: Provides frames from a virtual runtime source.
/// [EN] Documents this public package API member. [JA] IVirtualFrameSourceProvider の公開契約を定義します。
/// </summary>
public interface IVirtualFrameSourceProvider : IFrameSourceProvider
{
    /// <summary>
    /// EN: Lists virtual surfaces exposed by a sandbox instance.
    /// [EN] Documents this public package API member. [JA] ListSurfacesAsync 操作を実行します。
    /// </summary>
    /// <param name="handle">EN: The sandbox instance handle. JA: handle パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The virtual surface descriptors. JA: 結果を返します。</returns>
    ValueTask<IReadOnlyList<VirtualSurfaceDescriptor>> ListSurfacesAsync(
        SandboxInstanceHandle handle,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Binds a frame source to a surface boundary.
/// [EN] Documents this public package API member. [JA] IFrameSurfaceProvider の公開契約を定義します。
/// </summary>
public interface IFrameSurfaceProvider : IKernelProvider
{
    /// <summary>
    /// EN: Binds a frame surface.
    /// [EN] Documents this public package API member. [JA] BindAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The binding request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The surface binding result. JA: 結果を返します。</returns>
    ValueTask<FrameSurfaceBinding> BindAsync(
        FrameSurfaceBindingRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
