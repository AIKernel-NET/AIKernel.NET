using AIKernel.Dtos.Contracts;
using AIKernel.Dtos.Operators;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Security;

/// <summary>
/// EN: Evaluates governance-oriented policy requests and action proposal envelopes.
/// [EN] Documents this public package API member. [JA] IActionGovernancePolicy の公開契約を定義します。
/// </summary>
public interface IActionGovernancePolicy : IPolicy
{
    /// <summary>
    /// EN: Evaluates a policy request.
    /// [EN] Documents this public package API member. [JA] Evaluate 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The policy evaluation request. JA: request パラメーターです。</param>
    /// <returns>EN: The policy decision fragment. JA: 結果を返します。</returns>
    PolicyDecisionFragment Evaluate(PolicyEvaluationRequest request);

    /// <summary>
    /// EN: Evaluates an action proposal set.
    /// [EN] Documents this public package API member. [JA] Evaluate 操作を実行します。
    /// </summary>
    /// <param name="proposalSet">EN: The action proposal set. JA: proposalSet パラメーターです。</param>
    /// <returns>EN: The policy decision fragment. JA: 結果を返します。</returns>
    PolicyDecisionFragment Evaluate(ActionProposalSet proposalSet);

    /// <summary>
    /// EN: Evaluates an action arbitration request.
    /// [EN] Documents this public package API member. [JA] Evaluate 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The action arbitration request. JA: request パラメーターです。</param>
    /// <returns>EN: The policy decision fragment. JA: 結果を返します。</returns>
    PolicyDecisionFragment Evaluate(ActionArbitrationRequest request);
}

/// <summary>
/// EN: Provides governance decisions through the stable policy decision point boundary.
/// [EN] Documents this public package API member. [JA] IGovernanceDecisionProvider の公開契約を定義します。
/// </summary>
public interface IGovernanceDecisionProvider : IPdp
{
    /// <summary>
    /// EN: Evaluates a PDP request.
    /// [EN] Documents this public package API member. [JA] EvaluateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The policy evaluation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The policy decision. JA: 結果を返します。</returns>
    ValueTask<PolicyDecision> EvaluateAsync(
        PolicyEvaluationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Evaluates a governance decision request.
    /// [EN] Documents this public package API member. [JA] EvaluateGovernanceAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The governance decision request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The governance decision. JA: 結果を返します。</returns>
    ValueTask<GovernanceDecision> EvaluateGovernanceAsync(
        GovernanceDecisionRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Evaluates a provider capability against governance policy.
    /// [EN] Documents this public package API member. [JA] EvaluateCapabilityAsync 操作を実行します。
    /// </summary>
    /// <param name="capability">EN: The provider capability. JA: capability パラメーターです。</param>
    /// <param name="request">EN: The policy evaluation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The governance decision. JA: 結果を返します。</returns>
    ValueTask<GovernanceDecision> EvaluateCapabilityAsync(
        ProviderCapability capability,
        PolicyEvaluationRequest request,
        CancellationToken cancellationToken);
}
