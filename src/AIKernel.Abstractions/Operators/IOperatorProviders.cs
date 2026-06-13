using AIKernel.Dtos.Operators;
using AIKernel.Dtos.Perception;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Operators;

/// <summary>
/// Routes observations to bounded phase states.
/// </summary>
public interface IPhaseRouterProvider : IProviderExtended
{
    /// <summary>
    /// Routes an observation to a phase.
    /// </summary>
    /// <param name="request">The phase routing request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The phase routing result.</returns>
    ValueTask<PhaseRoutingResult> RouteAsync(
        PhaseRoutingRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Proposes bounded actions from observations and phase state.
/// </summary>
public interface IActionProposalProvider : IProviderExtended
{
    /// <summary>
    /// Proposes actions for an observation.
    /// </summary>
    /// <param name="observation">The observation snapshot.</param>
    /// <param name="phase">The phase state.</param>
    /// <param name="profile">The control profile.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The action proposals.</returns>
    ValueTask<IReadOnlyList<ActionProposal>> ProposeAsync(
        ObservationSnapshot observation,
        PhaseState phase,
        ControlProfile profile,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Arbitrates action proposals before governance or input execution.
/// </summary>
public interface IActionArbiterProvider : IProviderExtended
{
    /// <summary>
    /// Arbitrates action proposals.
    /// </summary>
    /// <param name="proposals">The action proposals.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The arbitration result.</returns>
    ValueTask<ActionArbitrationResult> ArbitrateAsync(
        IReadOnlyList<ActionProposal> proposals,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Loads reusable control profiles.
/// </summary>
public interface IControlProfileProvider : IProviderExtended
{
    /// <summary>
    /// Loads a control profile.
    /// </summary>
    /// <param name="profileId">The profile identifier.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The control profile.</returns>
    ValueTask<ControlProfile> LoadProfileAsync(
        string profileId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Saves a control profile.
    /// </summary>
    /// <param name="request">The control profile request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The save result.</returns>
    ValueTask<ControlProfileSaveResult> SaveAsync(
        ControlProfileRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// Produces reusable control-profile tuning artifacts.
/// </summary>
public interface IControlProfileOptimizerProvider : IProviderExtended
{
    /// <summary>
    /// Optimizes a control profile from evidence and telemetry metadata.
    /// </summary>
    /// <param name="request">The optimization request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The optimized control profile.</returns>
    ValueTask<ControlProfile> OptimizeAsync(
        ControlProfileOptimizationRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Optimizes a control profile.
    /// </summary>
    /// <param name="request">The optimization request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The optimization result.</returns>
    ValueTask<ControlProfileOptimizationResult> OptimizeAsync(
        ControlProfileOptimizationRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// Extends operator providers with request-envelope based proposal and arbitration operations.
/// </summary>
public interface IOperatorProviderExtended :
    IActionProposalProvider,
    IActionArbiterProvider
{
    /// <summary>
    /// Proposes actions.
    /// </summary>
    /// <param name="request">The action proposal request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The action proposal set.</returns>
    ValueTask<ActionProposalSet> ProposeActionsAsync(
        ActionProposalRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Arbitrates action proposals.
    /// </summary>
    /// <param name="request">The action arbitration request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The arbitration result.</returns>
    ValueTask<ActionArbitrationResult> ArbitrateAsync(
        ActionArbitrationRequest request,
        CancellationToken cancellationToken);
}
