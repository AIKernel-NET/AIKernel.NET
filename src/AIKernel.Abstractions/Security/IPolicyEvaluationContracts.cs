using AIKernel.Dtos.Contracts;
using AIKernel.Dtos.Operators;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Security;

/// <summary>
/// Extends the existing policy contract with deterministic decision fragments.
/// </summary>
public interface IPolicyExtended : IPolicy
{
    /// <summary>
    /// Evaluates a policy request.
    /// </summary>
    /// <param name="request">The policy evaluation request.</param>
    /// <returns>The policy decision fragment.</returns>
    PolicyDecisionFragment Evaluate(PolicyEvaluationRequest request);

    /// <summary>
    /// Evaluates an action proposal set.
    /// </summary>
    /// <param name="proposalSet">The action proposal set.</param>
    /// <returns>The policy decision fragment.</returns>
    PolicyDecisionFragment Evaluate(ActionProposalSet proposalSet);

    /// <summary>
    /// Evaluates an action arbitration request.
    /// </summary>
    /// <param name="request">The action arbitration request.</param>
    /// <returns>The policy decision fragment.</returns>
    PolicyDecisionFragment Evaluate(ActionArbitrationRequest request);
}

/// <summary>
/// Extends the existing policy decision point with generic policy evaluation requests.
/// </summary>
public interface IPdpExtended : IPdp
{
    /// <summary>
    /// Evaluates a PDP request.
    /// </summary>
    /// <param name="request">The policy evaluation request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The policy decision.</returns>
    ValueTask<PolicyDecision> EvaluateAsync(
        PolicyEvaluationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Evaluates a governance decision request.
    /// </summary>
    /// <param name="request">The governance decision request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The governance decision.</returns>
    ValueTask<GovernanceDecision> EvaluateGovernanceAsync(
        GovernanceDecisionRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Evaluates a provider capability against governance policy.
    /// </summary>
    /// <param name="capability">The provider capability.</param>
    /// <param name="request">The policy evaluation request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The governance decision.</returns>
    ValueTask<GovernanceDecision> EvaluateCapabilityAsync(
        ProviderCapability capability,
        PolicyEvaluationRequest request,
        CancellationToken cancellationToken);
}
