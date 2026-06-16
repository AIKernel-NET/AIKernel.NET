using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Runtime;

namespace AIKernel.Abstractions.Runtime;

/// <summary>
/// EN: Resolves runtime artifacts without exposing technology-specific names.
/// [EN] Documents this public package API member. [JA] IRuntimeAssetResolver の公開契約を定義します。
/// </summary>
public interface IRuntimeAssetResolver : IKernelProvider
{
    /// <summary>
    /// EN: Resolves a runtime asset request.
    /// [EN] Documents this public package API member. [JA] ResolveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The runtime asset request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The asset resolution result. JA: 結果を返します。</returns>
    ValueTask<RuntimeAssetResolutionResult> ResolveAsync(
        RuntimeAssetRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Mounts resolved artifacts into a memory-backed runtime boundary.
/// [EN] Documents this public package API member. [JA] IMemoryAssetMountProvider の公開契約を定義します。
/// </summary>
public interface IMemoryAssetMountProvider : IKernelProvider
{
    /// <summary>
    /// EN: Mounts an asset into memory.
    /// [EN] Documents this public package API member. [JA] MountAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The mount request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The mount result. JA: 結果を返します。</returns>
    ValueTask<MemoryAssetMountResult> MountAsync(
        MemoryAssetMountRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
