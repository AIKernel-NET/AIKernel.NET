using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Providers;

/// <summary>
/// EN: Provides capability-based execution on top of the stable provider boundary.
/// EN: Documentation for public API. JA: IKernelProvider の公開契約を定義します。
/// </summary>
public interface IKernelProvider : IProvider
{
    /// <summary>
    /// EN: Gets provider capabilities for routing and admission.
    /// EN: Documentation for public API. JA: GetCapabilitiesAsync 操作を実行します。
    /// </summary>
    /// <param name="context">EN: The preparation context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The provider capabilities. JA: 結果を返します。</returns>
    ValueTask<IReadOnlyList<ProviderCapability>> GetCapabilitiesAsync(
        ProviderPreparationContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Probes capability availability without side effects.
    /// EN: Documentation for public API. JA: ProbeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The capability query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The capability availability. JA: 結果を返します。</returns>
    ValueTask<CapabilityAvailability> ProbeAsync(
        CapabilityQuery request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Executes a provider operation and returns a deterministic result envelope.
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    /// <typeparam name="T">EN: The result value type. JA: T 型パラメーターです。</typeparam>
    /// <param name="operationId">EN: The operation identifier. JA: operationId パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The provider result. JA: 結果を返します。</returns>
    ValueTask<ProviderResult<T>> ExecuteAsync<T>(
        string operationId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Routes providers by evaluating capability availability and routing policy.
/// EN: Documentation for public API. JA: ICapabilityProviderRouter の公開契約を定義します。
/// </summary>
public interface ICapabilityProviderRouter : IProviderRouter
{
    /// <summary>
    /// EN: Selects the best provider for a routing context.
    /// EN: Documentation for public API. JA: SelectProviderAsync 操作を実行します。
    /// </summary>
    /// <param name="routingContext">EN: The routing context. JA: routingContext パラメーターです。</param>
    /// <param name="policy">EN: The routing policy. JA: policy パラメーターです。</param>
    /// <param name="candidates">EN: The candidate providers. JA: candidates パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The selected provider result. JA: 結果を返します。</returns>
    ValueTask<ProviderResult<IKernelProvider>> SelectProviderAsync(
        RoutingContext routingContext,
        RoutingPolicy policy,
        IReadOnlyList<IKernelProvider> candidates,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Routes a capability probe across candidate providers.
    /// EN: Documentation for public API. JA: ProbeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The capability query. JA: request パラメーターです。</param>
    /// <param name="policy">EN: The routing policy. JA: policy パラメーターです。</param>
    /// <param name="candidates">EN: The candidate providers. JA: candidates パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The routed availability result. JA: 結果を返します。</returns>
    ValueTask<ProviderResult<CapabilityAvailability>> ProbeAsync(
        CapabilityQuery request,
        RoutingPolicy policy,
        IReadOnlyList<IKernelProvider> candidates,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Evaluates matching capabilities for a capability query.
    /// EN: Documentation for public API. JA: EvaluateCapabilityAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The capability query. JA: request パラメーターです。</param>
    /// <param name="candidates">EN: The candidate providers. JA: candidates パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The matching capabilities. JA: 結果を返します。</returns>
    ValueTask<ProviderResult<IReadOnlyList<ProviderCapability>>> EvaluateCapabilityAsync(
        CapabilityQuery request,
        IReadOnlyList<IKernelProvider> candidates,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Creates scoped provider instances for isolated runtime operations.
/// EN: Documentation for public API. JA: IScopedProviderFactory の公開契約を定義します。
/// </summary>
public interface IScopedProviderFactory
{
    /// <summary>
    /// EN: Creates a provider for the supplied scope.
    /// EN: Documentation for public API. JA: CreateProviderAsync 操作を実行します。
    /// </summary>
    /// <param name="scope">EN: The scope identifier. JA: scope パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The scoped provider. JA: 結果を返します。</returns>
    ValueTask<IKernelProvider> CreateProviderAsync(string scope, CancellationToken cancellationToken);
}
