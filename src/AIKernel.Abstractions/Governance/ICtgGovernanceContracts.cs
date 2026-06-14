using AIKernel.Dtos.Governance;

namespace AIKernel.Abstractions.Governance;

/// <summary>
/// EN: Evaluates council votes and decisions from canonical governance inputs. JA: 正典統治入力から評議会投票と決定を評価します。
/// </summary>
public interface ICouncilEvaluator
{
    /// <summary>
    /// EN: Evaluates a council decision for the supplied request. JA: 指定された要求の評議会決定を評価します。
    /// </summary>
    /// <param name="request">EN: The evaluation request. JA: 評価要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The evaluation result. JA: 評価結果を返します。</returns>
    ValueTask<CouncilEvaluationResult> EvaluateAsync(
        CouncilEvaluationRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Evaluates a single-step deterministic decision gate. JA: 単一ステップの決定論的決定ゲートを評価します。
/// </summary>
public interface IDecisionGate
{
    /// <summary>
    /// EN: Evaluates a single-step gate decision for the supplied request. JA: 指定された要求の単一ステップゲート決定を評価します。
    /// </summary>
    /// <param name="request">EN: The gate request. JA: ゲート要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The gate result. JA: ゲート結果を返します。</returns>
    ValueTask<DecisionGateResult> EvaluateAsync(
        DecisionGateRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Evaluates deterministic governance across a trajectory. JA: 軌道全体の決定論的統治を評価します。
/// </summary>
public interface ITrajectoryGate
{
    /// <summary>
    /// EN: Evaluates a trajectory gate decision for the supplied request. JA: 指定された要求の軌道ゲート決定を評価します。
    /// </summary>
    /// <param name="request">EN: The trajectory gate request. JA: 軌道ゲート要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The trajectory gate result. JA: 軌道ゲート結果を返します。</returns>
    ValueTask<TrajectoryGateResult> EvaluateAsync(
        TrajectoryGateRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Coordinates ROM-backed governance evaluation through council and gate contracts. JA: 評議会およびゲート契約を通じて ROM backed 統治評価を調整します。
/// </summary>
public interface IRomGovernanceEngine
{
    /// <summary>
    /// EN: Evaluates one governance step for the supplied request. JA: 指定された要求の単一統治ステップを評価します。
    /// </summary>
    /// <param name="request">EN: The ROM governance request. JA: ROM 統治要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The ROM governance result. JA: ROM 統治結果を返します。</returns>
    ValueTask<RomGovernanceEvaluationResult> EvaluateStepAsync(
        RomGovernanceEvaluationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Evaluates a trajectory for the supplied request. JA: 指定された要求の軌道を評価します。
    /// </summary>
    /// <param name="request">EN: The trajectory gate request. JA: 軌道ゲート要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The trajectory gate result. JA: 軌道ゲート結果を返します。</returns>
    ValueTask<TrajectoryGateResult> EvaluateTrajectoryAsync(
        TrajectoryGateRequest request,
        CancellationToken cancellationToken);
}
