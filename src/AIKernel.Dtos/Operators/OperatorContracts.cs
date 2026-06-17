using AIKernel.Enums;
using AIKernel.Dtos.Perception;

namespace AIKernel.Dtos.Operators;

/// <summary>
/// EN: Carries phase routing state.
/// [EN] Documents this public package API member. [JA] PhaseState の公開契約を定義します。
/// </summary>
public sealed record PhaseState
{
    /// <summary>EN: Gets the phase identifier. JA: PhaseId を取得します。</summary>
    public required string PhaseId { get; init; }

    /// <summary>EN: Gets the phase confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets optional phase metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a phase routing request.
/// [EN] Documents this public package API member. [JA] PhaseRoutingRequest の公開契約を定義します。
/// </summary>
public sealed record PhaseRoutingRequest
{
    /// <summary>EN: Gets the routing request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>EN: Gets the observation snapshot. JA: Observation を取得します。</summary>
    public required ObservationSnapshot Observation { get; init; }

    /// <summary>EN: Gets optional routing metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a phase routing result.
/// [EN] Documents this public package API member. [JA] PhaseRoutingResult の公開契約を定義します。
/// </summary>
public sealed record PhaseRoutingResult
{
    /// <summary>EN: Gets the selected phase. JA: Phase を取得します。</summary>
    public required PhaseState Phase { get; init; }

    /// <summary>EN: Gets candidate phase states. JA: Candidates を取得します。</summary>
    public IReadOnlyList<PhaseState> Candidates { get; init; } = [];

    /// <summary>EN: Gets optional routing metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries an action proposal.
/// [EN] Documents this public package API member. [JA] ActionProposal の公開契約を定義します。
/// </summary>
public sealed record ActionProposal
{
    /// <summary>EN: Gets the proposal identifier. JA: ProposalId を取得します。</summary>
    public required string ProposalId { get; init; }

    /// <summary>EN: Gets the proposed action identifier. JA: ActionId を取得します。</summary>
    public required string ActionId { get; init; }

    /// <summary>EN: Gets the proposed action kind. JA: ActionKind を取得します。</summary>
    public string? ActionKind { get; init; }

    /// <summary>EN: Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets the proposal priority. JA: Priority を取得します。</summary>
    public int Priority { get; init; }

    /// <summary>EN: Gets risk from 0 to 1. JA: Risk を取得します。</summary>
    public double Risk { get; init; }

    /// <summary>EN: Gets whether governance approval is required. JA: RequiresGovernance を取得します。</summary>
    public bool RequiresGovernance { get; init; } = true;

    /// <summary>EN: Gets optional proposal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries an action proposal request.
/// [EN] Documents this public package API member. [JA] ActionProposalRequest の公開契約を定義します。
/// </summary>
public sealed record ActionProposalRequest
{
    /// <summary>EN: Gets the request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>EN: Gets the observation snapshot. JA: Observation を取得します。</summary>
    public required ObservationSnapshot Observation { get; init; }

    /// <summary>EN: Gets the phase state. JA: Phase を取得します。</summary>
    public required PhaseState Phase { get; init; }

    /// <summary>EN: Gets the control profile. JA: Profile を取得します。</summary>
    public required ControlProfile Profile { get; init; }

    /// <summary>EN: Gets optional request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries action proposals.
/// [EN] Documents this public package API member. [JA] ActionProposalSet の公開契約を定義します。
/// </summary>
public sealed record ActionProposalSet
{
    /// <summary>EN: Gets the proposal set identifier. JA: ProposalSetId を取得します。</summary>
    public required string ProposalSetId { get; init; }

    /// <summary>EN: Gets the proposals. JA: Proposals を取得します。</summary>
    public IReadOnlyList<ActionProposal> Proposals { get; init; } = [];

    /// <summary>EN: Gets optional proposal set metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries an action arbitration request.
/// [EN] Documents this public package API member. [JA] ActionArbitrationRequest の公開契約を定義します。
/// </summary>
public sealed record ActionArbitrationRequest
{
    /// <summary>EN: Gets the arbitration request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>EN: Gets the proposal set. JA: ProposalSet を取得します。</summary>
    public required ActionProposalSet ProposalSet { get; init; }

    /// <summary>EN: Gets optional arbitration metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries action arbitration result.
/// [EN] Documents this public package API member. [JA] ActionArbitrationResult の公開契約を定義します。
/// </summary>
public sealed record ActionArbitrationResult
{
    /// <summary>EN: Gets the arbitration decision. JA: Decision を取得します。</summary>
    public ActionArbitrationDecisionKind Decision { get; init; } = ActionArbitrationDecisionKind.None;

    /// <summary>EN: Gets the selected proposal. JA: SelectedProposal を取得します。</summary>
    public ActionProposal? SelectedProposal { get; init; }

    /// <summary>EN: Gets the reason for the decision. JA: Reason を取得します。</summary>
    public string? Reason { get; init; }

    /// <summary>EN: Gets optional arbitration metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a generic control profile.
/// [EN] Documents this public package API member. [JA] ControlProfile の公開契約を定義します。
/// </summary>
public sealed record ControlProfile
{
    /// <summary>EN: Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public required string ProfileId { get; init; }

    /// <summary>EN: Gets the profile version. JA: Version を取得します。</summary>
    public required string Version { get; init; }

    /// <summary>EN: Gets profile parameters. JA: Parameters を取得します。</summary>
    public IReadOnlyDictionary<string, string> Parameters { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a control profile optimization request.
/// [EN] Documents this public package API member. [JA] ControlProfileOptimizationRequest の公開契約を定義します。
/// </summary>
public sealed record ControlProfileOptimizationRequest
{
    /// <summary>EN: Gets the optimization request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>EN: Gets the base control profile. JA: BaseProfile を取得します。</summary>
    public required ControlProfile BaseProfile { get; init; }

    /// <summary>EN: Gets optional optimization metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a control profile load or save request.
/// [EN] Documents this public package API member. [JA] ControlProfileRequest の公開契約を定義します。
/// </summary>
public sealed record ControlProfileRequest
{
    /// <summary>EN: Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public required string ProfileId { get; init; }

    /// <summary>EN: Gets the profile for save operations. JA: Profile を取得します。</summary>
    public ControlProfile? Profile { get; init; }

    /// <summary>EN: Gets optional profile request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a control profile save result.
/// [EN] Documents this public package API member. [JA] ControlProfileSaveResult の公開契約を定義します。
/// </summary>
public sealed record ControlProfileSaveResult
{
    /// <summary>EN: Gets whether save succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the saved profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>EN: Gets optional save metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a control profile optimization result.
/// [EN] Documents this public package API member. [JA] ControlProfileOptimizationResult の公開契約を定義します。
/// </summary>
public sealed record ControlProfileOptimizationResult
{
    /// <summary>EN: Gets whether optimization succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the optimized profile. JA: Profile を取得します。</summary>
    public ControlProfile? Profile { get; init; }

    /// <summary>EN: Gets optional optimization metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
