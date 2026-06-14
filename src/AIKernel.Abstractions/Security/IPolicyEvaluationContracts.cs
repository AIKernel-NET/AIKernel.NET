using AIKernel.Dtos.Contracts;
using AIKernel.Dtos.Operators;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Security;

/// <summary>
/// Evaluates governance-oriented policy requests and action proposal envelopes.
/// JA: IActionGovernancePolicy の公開契約を定義します。
/// </summary>
public interface IActionGovernancePolicy : IPolicy
{
    /// <summary>
    /// Evaluates a policy request.
    /// JA: Evaluate 操作を実行します。
    /// </summary>
    /// <param name="request">The policy evaluation request. JA: request パラメーターです。</param>
    /// <returns>The policy decision fragment. JA: 結果を返します。</returns>
    PolicyDecisionFragment Evaluate(PolicyEvaluationRequest request);

    /// <summary>
    /// Evaluates an action proposal set.
    /// JA: Evaluate 操作を実行します。
    /// </summary>
    /// <param name="proposalSet">The action proposal set. JA: proposalSet パラメーターです。</param>
    /// <returns>The policy decision fragment. JA: 結果を返します。</returns>
    PolicyDecisionFragment Evaluate(ActionProposalSet proposalSet);

    /// <summary>
    /// Evaluates an action arbitration request.
    /// JA: Evaluate 操作を実行します。
    /// </summary>
    /// <param name="request">The action arbitration request. JA: request パラメーターです。</param>
    /// <returns>The policy decision fragment. JA: 結果を返します。</returns>
    PolicyDecisionFragment Evaluate(ActionArbitrationRequest request);
}

/// <summary>
/// Provides governance decisions through the stable policy decision point boundary.
/// JA: IGovernanceDecisionProvider の公開契約を定義します。
/// </summary>
public interface IGovernanceDecisionProvider : IPdp
{
    /// <summary>
    /// Evaluates a PDP request.
    /// JA: EvaluateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The policy evaluation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The policy decision. JA: 結果を返します。</returns>
    ValueTask<PolicyDecision> EvaluateAsync(
        PolicyEvaluationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Evaluates a governance decision request.
    /// JA: EvaluateGovernanceAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The governance decision request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The governance decision. JA: 結果を返します。</returns>
    ValueTask<GovernanceDecision> EvaluateGovernanceAsync(
        GovernanceDecisionRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Evaluates a provider capability against governance policy.
    /// JA: EvaluateCapabilityAsync 操作を実行します。
    /// </summary>
    /// <param name="capability">The provider capability. JA: capability パラメーターです。</param>
    /// <param name="request">The policy evaluation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The governance decision. JA: 結果を返します。</returns>
    ValueTask<GovernanceDecision> EvaluateCapabilityAsync(
        ProviderCapability capability,
        PolicyEvaluationRequest request,
        CancellationToken cancellationToken);
}
