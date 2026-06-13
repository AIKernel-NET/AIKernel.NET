using AIKernel.Dtos.Operators;
using AIKernel.Dtos.Perception;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Operators;

/// <summary>
/// Routes observations to bounded phase states.
/// JA: IPhaseRouterProvider の公開契約を定義します。
/// </summary>
public interface IPhaseRouterProvider : IKernelProvider
{
    /// <summary>
    /// Routes an observation to a phase.
    /// JA: RouteAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The phase routing request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The phase routing result. JA: 結果を返します。</returns>
    ValueTask<PhaseRoutingResult> RouteAsync(
        PhaseRoutingRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Proposes bounded actions from observations and phase state.
/// JA: IActionProposalProvider の公開契約を定義します。
/// </summary>
public interface IActionProposalProvider : IKernelProvider
{
    /// <summary>
    /// Proposes actions for an observation.
    /// JA: ProposeAsync 操作を実行します。
    /// </summary>
    /// <param name="observation">The observation snapshot. JA: observation パラメーターです。</param>
    /// <param name="phase">The phase state. JA: phase パラメーターです。</param>
    /// <param name="profile">The control profile. JA: profile パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The action proposals. JA: 結果を返します。</returns>
    ValueTask<IReadOnlyList<ActionProposal>> ProposeAsync(
        ObservationSnapshot observation,
        PhaseState phase,
        ControlProfile profile,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Arbitrates action proposals before governance or input execution.
/// JA: IActionArbiterProvider の公開契約を定義します。
/// </summary>
public interface IActionArbiterProvider : IKernelProvider
{
    /// <summary>
    /// Arbitrates action proposals.
    /// JA: ArbitrateAsync 操作を実行します。
    /// </summary>
    /// <param name="proposals">The action proposals. JA: proposals パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The arbitration result. JA: 結果を返します。</returns>
    ValueTask<ActionArbitrationResult> ArbitrateAsync(
        IReadOnlyList<ActionProposal> proposals,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Loads reusable control profiles.
/// JA: IControlProfileProvider の公開契約を定義します。
/// </summary>
public interface IControlProfileProvider : IKernelProvider
{
    /// <summary>
    /// Loads a control profile.
    /// JA: LoadProfileAsync 操作を実行します。
    /// </summary>
    /// <param name="profileId">The profile identifier. JA: profileId パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The control profile. JA: 結果を返します。</returns>
    ValueTask<ControlProfile> LoadProfileAsync(
        string profileId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Saves a control profile.
    /// JA: SaveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The control profile request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The save result. JA: 結果を返します。</returns>
    ValueTask<ControlProfileSaveResult> SaveAsync(
        ControlProfileRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// Produces reusable control-profile tuning artifacts.
/// JA: IControlProfileOptimizerProvider の公開契約を定義します。
/// </summary>
public interface IControlProfileOptimizerProvider : IKernelProvider
{
    /// <summary>
    /// Optimizes a control profile from evidence and telemetry metadata.
    /// JA: OptimizeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The optimization request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The optimized control profile. JA: 結果を返します。</returns>
    ValueTask<ControlProfile> OptimizeAsync(
        ControlProfileOptimizationRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Optimizes a control profile.
    /// JA: OptimizeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The optimization request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The optimization result. JA: 結果を返します。</returns>
    ValueTask<ControlProfileOptimizationResult> OptimizeAsync(
        ControlProfileOptimizationRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// Provides request-envelope based proposal and arbitration operations.
/// JA: IActionOperatorProvider の公開契約を定義します。
/// </summary>
public interface IActionOperatorProvider :
    IActionProposalProvider,
    IActionArbiterProvider
{
    /// <summary>
    /// Proposes actions.
    /// JA: ProposeActionsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The action proposal request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The action proposal set. JA: 結果を返します。</returns>
    ValueTask<ActionProposalSet> ProposeActionsAsync(
        ActionProposalRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Arbitrates action proposals.
    /// JA: ArbitrateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The action arbitration request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The arbitration result. JA: 結果を返します。</returns>
    ValueTask<ActionArbitrationResult> ArbitrateAsync(
        ActionArbitrationRequest request,
        CancellationToken cancellationToken);
}
