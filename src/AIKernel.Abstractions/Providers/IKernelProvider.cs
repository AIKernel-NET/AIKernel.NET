using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Providers;

/// <summary>
/// Provides capability-based execution on top of the stable provider boundary.
/// JA: IKernelProvider の公開契約を定義します。
/// </summary>
public interface IKernelProvider : IProvider
{
    /// <summary>
    /// Gets provider capabilities for routing and admission.
    /// JA: GetCapabilitiesAsync 操作を実行します。
    /// </summary>
    /// <param name="context">The preparation context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The provider capabilities. JA: 結果を返します。</returns>
    ValueTask<IReadOnlyList<ProviderCapability>> GetCapabilitiesAsync(
        ProviderPreparationContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Probes capability availability without side effects.
    /// JA: ProbeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The capability query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The capability availability. JA: 結果を返します。</returns>
    ValueTask<CapabilityAvailability> ProbeAsync(
        CapabilityQuery request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Executes a provider operation and returns a deterministic result envelope.
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    /// <typeparam name="T">The result value type. JA: T 型パラメーターです。</typeparam>
    /// <param name="operationId">The operation identifier. JA: operationId パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The provider result. JA: 結果を返します。</returns>
    ValueTask<ProviderResult<T>> ExecuteAsync<T>(
        string operationId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Routes providers by evaluating capability availability and routing policy.
/// JA: ICapabilityProviderRouter の公開契約を定義します。
/// </summary>
public interface ICapabilityProviderRouter : IProviderRouter
{
    /// <summary>
    /// Selects the best provider for a routing context.
    /// JA: SelectProviderAsync 操作を実行します。
    /// </summary>
    /// <param name="routingContext">The routing context. JA: routingContext パラメーターです。</param>
    /// <param name="policy">The routing policy. JA: policy パラメーターです。</param>
    /// <param name="candidates">The candidate providers. JA: candidates パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The selected provider result. JA: 結果を返します。</returns>
    ValueTask<ProviderResult<IKernelProvider>> SelectProviderAsync(
        RoutingContext routingContext,
        RoutingPolicy policy,
        IReadOnlyList<IKernelProvider> candidates,
        CancellationToken cancellationToken);

    /// <summary>
    /// Routes a capability probe across candidate providers.
    /// JA: ProbeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The capability query. JA: request パラメーターです。</param>
    /// <param name="policy">The routing policy. JA: policy パラメーターです。</param>
    /// <param name="candidates">The candidate providers. JA: candidates パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The routed availability result. JA: 結果を返します。</returns>
    ValueTask<ProviderResult<CapabilityAvailability>> ProbeAsync(
        CapabilityQuery request,
        RoutingPolicy policy,
        IReadOnlyList<IKernelProvider> candidates,
        CancellationToken cancellationToken);

    /// <summary>
    /// Evaluates matching capabilities for a capability query.
    /// JA: EvaluateCapabilityAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The capability query. JA: request パラメーターです。</param>
    /// <param name="candidates">The candidate providers. JA: candidates パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The matching capabilities. JA: 結果を返します。</returns>
    ValueTask<ProviderResult<IReadOnlyList<ProviderCapability>>> EvaluateCapabilityAsync(
        CapabilityQuery request,
        IReadOnlyList<IKernelProvider> candidates,
        CancellationToken cancellationToken);
}

/// <summary>
/// Creates scoped provider instances for isolated runtime operations.
/// JA: IScopedProviderFactory の公開契約を定義します。
/// </summary>
public interface IScopedProviderFactory
{
    /// <summary>
    /// Creates a provider for the supplied scope.
    /// JA: CreateProviderAsync 操作を実行します。
    /// </summary>
    /// <param name="scope">The scope identifier. JA: scope パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The scoped provider. JA: 結果を返します。</returns>
    ValueTask<IKernelProvider> CreateProviderAsync(string scope, CancellationToken cancellationToken);
}
