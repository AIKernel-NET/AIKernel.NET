using AIKernel.Dtos.Operators;
using AIKernel.Dtos.Perception;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Operators;

/// <summary>
/// EN: Routes observations to bounded phase states.
/// [EN] Documents this public package API member. [JA] IPhaseRouterProvider の公開契約を定義します。
/// </summary>
public interface IPhaseRouterProvider : IKernelProvider
{
    /// <summary>
    /// EN: Routes an observation to a phase.
    /// [EN] Documents this public package API member. [JA] RouteAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The phase routing request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The phase routing result. JA: 結果を返します。</returns>
    ValueTask<PhaseRoutingResult> RouteAsync(
        PhaseRoutingRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Proposes bounded actions from observations and phase state.
/// [EN] Documents this public package API member. [JA] IActionProposalProvider の公開契約を定義します。
/// </summary>
public interface IActionProposalProvider : IKernelProvider
{
    /// <summary>
    /// EN: Proposes actions for an observation.
    /// [EN] Documents this public package API member. [JA] ProposeAsync 操作を実行します。
    /// </summary>
    /// <param name="observation">EN: The observation snapshot. JA: observation パラメーターです。</param>
    /// <param name="phase">EN: The phase state. JA: phase パラメーターです。</param>
    /// <param name="profile">EN: The control profile. JA: profile パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The action proposals. JA: 結果を返します。</returns>
    ValueTask<IReadOnlyList<ActionProposal>> ProposeAsync(
        ObservationSnapshot observation,
        PhaseState phase,
        ControlProfile profile,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Arbitrates action proposals before governance or input execution.
/// [EN] Documents this public package API member. [JA] IActionArbiterProvider の公開契約を定義します。
/// </summary>
public interface IActionArbiterProvider : IKernelProvider
{
    /// <summary>
    /// EN: Arbitrates action proposals.
    /// [EN] Documents this public package API member. [JA] ArbitrateAsync 操作を実行します。
    /// </summary>
    /// <param name="proposals">EN: The action proposals. JA: proposals パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The arbitration result. JA: 結果を返します。</returns>
    ValueTask<ActionArbitrationResult> ArbitrateAsync(
        IReadOnlyList<ActionProposal> proposals,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Loads reusable control profiles.
/// [EN] Documents this public package API member. [JA] IControlProfileProvider の公開契約を定義します。
/// </summary>
public interface IControlProfileProvider : IKernelProvider
{
    /// <summary>
    /// EN: Loads a control profile.
    /// [EN] Documents this public package API member. [JA] LoadProfileAsync 操作を実行します。
    /// </summary>
    /// <param name="profileId">EN: The profile identifier. JA: profileId パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The control profile. JA: 結果を返します。</returns>
    ValueTask<ControlProfile> LoadProfileAsync(
        string profileId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Saves a control profile.
    /// [EN] Documents this public package API member. [JA] SaveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The control profile request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The save result. JA: 結果を返します。</returns>
    ValueTask<ControlProfileSaveResult> SaveAsync(
        ControlProfileRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Produces reusable control-profile tuning artifacts.
/// [EN] Documents this public package API member. [JA] IControlProfileOptimizerProvider の公開契約を定義します。
/// </summary>
public interface IControlProfileOptimizerProvider : IKernelProvider
{
    /// <summary>
    /// EN: Optimizes a control profile from evidence and telemetry metadata.
    /// [EN] Documents this public package API member. [JA] OptimizeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The optimization request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The optimized control profile. JA: 結果を返します。</returns>
    ValueTask<ControlProfile> OptimizeAsync(
        ControlProfileOptimizationRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Optimizes a control profile.
    /// [EN] Documents this public package API member. [JA] OptimizeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The optimization request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The optimization result. JA: 結果を返します。</returns>
    ValueTask<ControlProfileOptimizationResult> OptimizeAsync(
        ControlProfileOptimizationRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Provides request-envelope based proposal and arbitration operations.
/// [EN] Documents this public package API member. [JA] IActionOperatorProvider の公開契約を定義します。
/// </summary>
public interface IActionOperatorProvider :
    IActionProposalProvider,
    IActionArbiterProvider
{
    /// <summary>
    /// EN: Proposes actions.
    /// [EN] Documents this public package API member. [JA] ProposeActionsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The action proposal request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The action proposal set. JA: 結果を返します。</returns>
    ValueTask<ActionProposalSet> ProposeActionsAsync(
        ActionProposalRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Arbitrates action proposals.
    /// [EN] Documents this public package API member. [JA] ArbitrateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The action arbitration request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The arbitration result. JA: 結果を返します。</returns>
    ValueTask<ActionArbitrationResult> ArbitrateAsync(
        ActionArbitrationRequest request,
        CancellationToken cancellationToken);
}
