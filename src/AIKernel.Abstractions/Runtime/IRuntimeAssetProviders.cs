using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// Resolves runtime artifacts without exposing technology-specific names.
/// JA: IRuntimeAssetResolver の公開契約を定義します。
/// </summary>
public interface IRuntimeAssetResolver : IKernelProvider
{
    /// <summary>
    /// Resolves a runtime asset request.
    /// JA: ResolveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The runtime asset request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The asset resolution result. JA: 結果を返します。</returns>
    ValueTask<RuntimeAssetResolutionResult> ResolveAsync(
        RuntimeAssetRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Mounts resolved artifacts into a memory-backed runtime boundary.
/// JA: IMemoryAssetMountProvider の公開契約を定義します。
/// </summary>
public interface IMemoryAssetMountProvider : IKernelProvider
{
    /// <summary>
    /// Mounts an asset into memory.
    /// JA: MountAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The mount request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The mount result. JA: 結果を返します。</returns>
    ValueTask<MemoryAssetMountResult> MountAsync(
        MemoryAssetMountRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
