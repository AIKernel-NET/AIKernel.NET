using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Operators;

namespace AIKernel.Dtos.Operators;

/// <summary>
/// Carries an operator strategy description request.
/// JA: OperatorStrategyDescribeRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyDescribeRequest
{
    /// <summary>Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Describes an operator strategy.
/// JA: OperatorStrategyDescriptor の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyDescriptor
{
    /// <summary>Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string StrategyId { get; init; } = string.Empty;

    /// <summary>Gets whether description succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the strategy mode. JA: Mode を取得します。</summary>
    public OperatorMode Mode { get; init; } = OperatorMode.Unknown;

    /// <summary>Gets supported proposal kinds. JA: SupportedProposalKinds を取得します。</summary>
    public IReadOnlyList<ActionProposalKind> SupportedProposalKinds { get; init; } = [];

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets diagnostics emitted while describing the strategy. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an operator strategy request.
/// JA: OperatorStrategyRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyRequest
{
    /// <summary>Gets the request identifier. JA: RequestId を取得します。</summary>
    public string RequestId { get; init; } = string.Empty;

    /// <summary>Gets the operator mode. JA: Mode を取得します。</summary>
    public OperatorMode Mode { get; init; } = OperatorMode.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an operator strategy result.
/// JA: OperatorStrategyResult の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether evaluation succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the operator decision. JA: Decision を取得します。</summary>
    public OperatorDecisionKind Decision { get; init; } = OperatorDecisionKind.Unknown;

    /// <summary>Gets proposed actions. JA: Proposals を取得します。</summary>
    public IReadOnlyList<OperatorActionProposal> Proposals { get; init; } = [];

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets evaluation diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when evaluation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an operator action proposal.
/// JA: OperatorActionProposal の公開契約を定義します。
/// </summary>
public sealed record OperatorActionProposal
{
    /// <summary>Gets the proposal identifier. JA: ProposalId を取得します。</summary>
    public string ProposalId { get; init; } = string.Empty;

    /// <summary>Gets the proposal kind. JA: Kind を取得します。</summary>
    public ActionProposalKind Kind { get; init; } = ActionProposalKind.Unknown;

    /// <summary>Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>Gets risk from 0 to 1. JA: Risk を取得します。</summary>
    public double Risk { get; init; }

    /// <summary>Gets proposal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an operator strategy reset request.
/// JA: OperatorStrategyResetRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyResetRequest
{
    /// <summary>Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an operator strategy reset result.
/// JA: OperatorStrategyResetResult の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyResetResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether reset succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets reset diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when reset was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an operator strategy state request.
/// JA: OperatorStrategyStateRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyStateRequest
{
    /// <summary>Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an operator strategy state snapshot.
/// JA: OperatorStrategyStateSnapshot の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyStateSnapshot
{
    /// <summary>Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>Gets whether state capture succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>Gets the operator mode. JA: Mode を取得します。</summary>
    public OperatorMode Mode { get; init; } = OperatorMode.Unknown;

    /// <summary>Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets snapshot diagnostics. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>Gets snapshot metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an operator strategy profile update request.
/// JA: OperatorStrategyProfileUpdateRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyProfileUpdateRequest
{
    /// <summary>Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries an operator strategy profile update result.
/// JA: OperatorStrategyProfileUpdateResult の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyProfileUpdateResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether update succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets update diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when update was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
