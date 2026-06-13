using AIKernel.Enums;
using AIKernel.Dtos.Perception;

namespace AIKernel.Dtos.Operators;

/// <summary>
/// Carries phase routing state.
/// JA: PhaseState の公開契約を定義します。
/// </summary>
public sealed record PhaseState
{
    /// <summary>Gets the phase identifier. JA: PhaseId を取得します。</summary>
    public required string PhaseId { get; init; }

    /// <summary>Gets the phase confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>Gets optional phase metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a phase routing request.
/// JA: PhaseRoutingRequest の公開契約を定義します。
/// </summary>
public sealed record PhaseRoutingRequest
{
    /// <summary>Gets the routing request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the observation snapshot. JA: Observation を取得します。</summary>
    public required ObservationSnapshot Observation { get; init; }

    /// <summary>Gets optional routing metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a phase routing result.
/// JA: PhaseRoutingResult の公開契約を定義します。
/// </summary>
public sealed record PhaseRoutingResult
{
    /// <summary>Gets the selected phase. JA: Phase を取得します。</summary>
    public required PhaseState Phase { get; init; }

    /// <summary>Gets candidate phase states. JA: Candidates を取得します。</summary>
    public IReadOnlyList<PhaseState> Candidates { get; init; } = [];

    /// <summary>Gets optional routing metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an action proposal.
/// JA: ActionProposal の公開契約を定義します。
/// </summary>
public sealed record ActionProposal
{
    /// <summary>Gets the proposal identifier. JA: ProposalId を取得します。</summary>
    public required string ProposalId { get; init; }

    /// <summary>Gets the proposed action identifier. JA: ActionId を取得します。</summary>
    public required string ActionId { get; init; }

    /// <summary>Gets the proposed action kind. JA: ActionKind を取得します。</summary>
    public string? ActionKind { get; init; }

    /// <summary>Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>Gets the proposal priority. JA: Priority を取得します。</summary>
    public int Priority { get; init; }

    /// <summary>Gets risk from 0 to 1. JA: Risk を取得します。</summary>
    public double Risk { get; init; }

    /// <summary>Gets whether governance approval is required. JA: RequiresGovernance を取得します。</summary>
    public bool RequiresGovernance { get; init; } = true;

    /// <summary>Gets optional proposal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an action proposal request.
/// JA: ActionProposalRequest の公開契約を定義します。
/// </summary>
public sealed record ActionProposalRequest
{
    /// <summary>Gets the request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the observation snapshot. JA: Observation を取得します。</summary>
    public required ObservationSnapshot Observation { get; init; }

    /// <summary>Gets the phase state. JA: Phase を取得します。</summary>
    public required PhaseState Phase { get; init; }

    /// <summary>Gets the control profile. JA: Profile を取得します。</summary>
    public required ControlProfile Profile { get; init; }

    /// <summary>Gets optional request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries action proposals.
/// JA: ActionProposalSet の公開契約を定義します。
/// </summary>
public sealed record ActionProposalSet
{
    /// <summary>Gets the proposal set identifier. JA: ProposalSetId を取得します。</summary>
    public required string ProposalSetId { get; init; }

    /// <summary>Gets the proposals. JA: Proposals を取得します。</summary>
    public IReadOnlyList<ActionProposal> Proposals { get; init; } = [];

    /// <summary>Gets optional proposal set metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an action arbitration request.
/// JA: ActionArbitrationRequest の公開契約を定義します。
/// </summary>
public sealed record ActionArbitrationRequest
{
    /// <summary>Gets the arbitration request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the proposal set. JA: ProposalSet を取得します。</summary>
    public required ActionProposalSet ProposalSet { get; init; }

    /// <summary>Gets optional arbitration metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries action arbitration result.
/// JA: ActionArbitrationResult の公開契約を定義します。
/// </summary>
public sealed record ActionArbitrationResult
{
    /// <summary>Gets the arbitration decision. JA: Decision を取得します。</summary>
    public ActionArbitrationDecisionKind Decision { get; init; } = ActionArbitrationDecisionKind.None;

    /// <summary>Gets the selected proposal. JA: SelectedProposal を取得します。</summary>
    public ActionProposal? SelectedProposal { get; init; }

    /// <summary>Gets the reason for the decision. JA: Reason を取得します。</summary>
    public string? Reason { get; init; }

    /// <summary>Gets optional arbitration metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a generic control profile.
/// JA: ControlProfile の公開契約を定義します。
/// </summary>
public sealed record ControlProfile
{
    /// <summary>Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public required string ProfileId { get; init; }

    /// <summary>Gets the profile version. JA: Version を取得します。</summary>
    public required string Version { get; init; }

    /// <summary>Gets profile parameters. JA: Parameters を取得します。</summary>
    public IReadOnlyDictionary<string, string> Parameters { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a control profile optimization request.
/// JA: ControlProfileOptimizationRequest の公開契約を定義します。
/// </summary>
public sealed record ControlProfileOptimizationRequest
{
    /// <summary>Gets the optimization request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the base control profile. JA: BaseProfile を取得します。</summary>
    public required ControlProfile BaseProfile { get; init; }

    /// <summary>Gets optional optimization metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a control profile load or save request.
/// JA: ControlProfileRequest の公開契約を定義します。
/// </summary>
public sealed record ControlProfileRequest
{
    /// <summary>Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public required string ProfileId { get; init; }

    /// <summary>Gets the profile for save operations. JA: Profile を取得します。</summary>
    public ControlProfile? Profile { get; init; }

    /// <summary>Gets optional profile request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a control profile save result.
/// JA: ControlProfileSaveResult の公開契約を定義します。
/// </summary>
public sealed record ControlProfileSaveResult
{
    /// <summary>Gets whether save succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the saved profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>Gets optional save metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a control profile optimization result.
/// JA: ControlProfileOptimizationResult の公開契約を定義します。
/// </summary>
public sealed record ControlProfileOptimizationResult
{
    /// <summary>Gets whether optimization succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the optimized profile. JA: Profile を取得します。</summary>
    public ControlProfile? Profile { get; init; }

    /// <summary>Gets optional optimization metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
