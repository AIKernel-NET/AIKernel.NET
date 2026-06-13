using AIKernel.Enums;
using AIKernel.Dtos.Perception;

namespace AIKernel.Dtos.Operators;

/// <summary>
/// Carries phase routing state.
/// </summary>
public sealed record PhaseState
{
    /// <summary>Gets the phase identifier.</summary>
    public required string PhaseId { get; init; }

    /// <summary>Gets the phase confidence from 0 to 1.</summary>
    public double Confidence { get; init; }

    /// <summary>Gets optional phase metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a phase routing request.
/// </summary>
public sealed record PhaseRoutingRequest
{
    /// <summary>Gets the routing request identifier.</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the observation snapshot.</summary>
    public required ObservationSnapshot Observation { get; init; }

    /// <summary>Gets optional routing metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a phase routing result.
/// </summary>
public sealed record PhaseRoutingResult
{
    /// <summary>Gets the selected phase.</summary>
    public required PhaseState Phase { get; init; }

    /// <summary>Gets candidate phase states.</summary>
    public IReadOnlyList<PhaseState> Candidates { get; init; } = [];

    /// <summary>Gets optional routing metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an action proposal.
/// </summary>
public sealed record ActionProposal
{
    /// <summary>Gets the proposal identifier.</summary>
    public required string ProposalId { get; init; }

    /// <summary>Gets the proposed action identifier.</summary>
    public required string ActionId { get; init; }

    /// <summary>Gets the proposed action kind.</summary>
    public string? ActionKind { get; init; }

    /// <summary>Gets confidence from 0 to 1.</summary>
    public double Confidence { get; init; }

    /// <summary>Gets the proposal priority.</summary>
    public int Priority { get; init; }

    /// <summary>Gets risk from 0 to 1.</summary>
    public double Risk { get; init; }

    /// <summary>Gets whether governance approval is required.</summary>
    public bool RequiresGovernance { get; init; } = true;

    /// <summary>Gets optional proposal metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an action proposal request.
/// </summary>
public sealed record ActionProposalRequest
{
    /// <summary>Gets the request identifier.</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the observation snapshot.</summary>
    public required ObservationSnapshot Observation { get; init; }

    /// <summary>Gets the phase state.</summary>
    public required PhaseState Phase { get; init; }

    /// <summary>Gets the control profile.</summary>
    public required ControlProfile Profile { get; init; }

    /// <summary>Gets optional request metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries action proposals.
/// </summary>
public sealed record ActionProposalSet
{
    /// <summary>Gets the proposal set identifier.</summary>
    public required string ProposalSetId { get; init; }

    /// <summary>Gets the proposals.</summary>
    public IReadOnlyList<ActionProposal> Proposals { get; init; } = [];

    /// <summary>Gets optional proposal set metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an action arbitration request.
/// </summary>
public sealed record ActionArbitrationRequest
{
    /// <summary>Gets the arbitration request identifier.</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the proposal set.</summary>
    public required ActionProposalSet ProposalSet { get; init; }

    /// <summary>Gets optional arbitration metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries action arbitration result.
/// </summary>
public sealed record ActionArbitrationResult
{
    /// <summary>Gets the arbitration decision.</summary>
    public ActionArbitrationDecisionKind Decision { get; init; } = ActionArbitrationDecisionKind.None;

    /// <summary>Gets the selected proposal.</summary>
    public ActionProposal? SelectedProposal { get; init; }

    /// <summary>Gets the reason for the decision.</summary>
    public string? Reason { get; init; }

    /// <summary>Gets optional arbitration metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a generic control profile.
/// </summary>
public sealed record ControlProfile
{
    /// <summary>Gets the profile identifier.</summary>
    public required string ProfileId { get; init; }

    /// <summary>Gets the profile version.</summary>
    public required string Version { get; init; }

    /// <summary>Gets profile parameters.</summary>
    public IReadOnlyDictionary<string, string> Parameters { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a control profile optimization request.
/// </summary>
public sealed record ControlProfileOptimizationRequest
{
    /// <summary>Gets the optimization request identifier.</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the base control profile.</summary>
    public required ControlProfile BaseProfile { get; init; }

    /// <summary>Gets optional optimization metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a control profile load or save request.
/// </summary>
public sealed record ControlProfileRequest
{
    /// <summary>Gets the profile identifier.</summary>
    public required string ProfileId { get; init; }

    /// <summary>Gets the profile for save operations.</summary>
    public ControlProfile? Profile { get; init; }

    /// <summary>Gets optional profile request metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a control profile save result.
/// </summary>
public sealed record ControlProfileSaveResult
{
    /// <summary>Gets whether save succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the saved profile identifier.</summary>
    public string? ProfileId { get; init; }

    /// <summary>Gets optional save metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a control profile optimization result.
/// </summary>
public sealed record ControlProfileOptimizationResult
{
    /// <summary>Gets whether optimization succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the optimized profile.</summary>
    public ControlProfile? Profile { get; init; }

    /// <summary>Gets optional optimization metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
