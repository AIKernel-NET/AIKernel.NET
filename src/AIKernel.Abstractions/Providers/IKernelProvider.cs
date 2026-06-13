using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Providers;

/// <summary>
/// Extends the existing provider boundary with capability-based execution.
/// </summary>
public interface IProviderExtended : IProvider
{
    /// <summary>
    /// Gets provider capabilities for routing and admission.
    /// </summary>
    /// <param name="context">The preparation context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The provider capabilities.</returns>
    ValueTask<IReadOnlyList<ProviderCapability>> GetCapabilitiesAsync(
        ProviderPreparationContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Probes capability availability without side effects.
    /// </summary>
    /// <param name="request">The capability query.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The capability availability.</returns>
    ValueTask<CapabilityAvailability> ProbeAsync(
        CapabilityQuery request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Executes a provider operation and returns a deterministic result envelope.
    /// </summary>
    /// <typeparam name="T">The result value type.</typeparam>
    /// <param name="operationId">The operation identifier.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The provider result.</returns>
    ValueTask<ProviderResult<T>> ExecuteAsync<T>(
        string operationId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Extends the existing provider router with capability-based routing.
/// </summary>
public interface IProviderRouterExtended : IProviderRouter
{
    /// <summary>
    /// Selects the best provider for a routing context.
    /// </summary>
    /// <param name="routingContext">The routing context.</param>
    /// <param name="policy">The routing policy.</param>
    /// <param name="candidates">The candidate providers.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The selected provider result.</returns>
    ValueTask<ProviderResult<IProviderExtended>> SelectProviderAsync(
        RoutingContext routingContext,
        RoutingPolicy policy,
        IReadOnlyList<IProviderExtended> candidates,
        CancellationToken cancellationToken);

    /// <summary>
    /// Routes a capability probe across candidate providers.
    /// </summary>
    /// <param name="request">The capability query.</param>
    /// <param name="policy">The routing policy.</param>
    /// <param name="candidates">The candidate providers.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The routed availability result.</returns>
    ValueTask<ProviderResult<CapabilityAvailability>> ProbeAsync(
        CapabilityQuery request,
        RoutingPolicy policy,
        IReadOnlyList<IProviderExtended> candidates,
        CancellationToken cancellationToken);

    /// <summary>
    /// Evaluates matching capabilities for a capability query.
    /// </summary>
    /// <param name="request">The capability query.</param>
    /// <param name="candidates">The candidate providers.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The matching capabilities.</returns>
    ValueTask<ProviderResult<IReadOnlyList<ProviderCapability>>> EvaluateCapabilityAsync(
        CapabilityQuery request,
        IReadOnlyList<IProviderExtended> candidates,
        CancellationToken cancellationToken);
}

/// <summary>
/// Creates scoped provider instances for isolated runtime operations.
/// </summary>
public interface IScopedProviderFactory
{
    /// <summary>
    /// Creates a provider for the supplied scope.
    /// </summary>
    /// <param name="scope">The scope identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The scoped provider.</returns>
    ValueTask<IProviderExtended> CreateProviderAsync(string scope, CancellationToken cancellationToken);
}
