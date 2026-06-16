using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Operators;

namespace AIKernel.Dtos.Operators;

/// <summary>
/// EN: Carries an operator strategy description request.
/// EN: Documentation for public API. JA: OperatorStrategyDescribeRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyDescribeRequest
{
    /// <summary>EN: Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Describes an operator strategy.
/// EN: Documentation for public API. JA: OperatorStrategyDescriptor の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyDescriptor
{
    /// <summary>EN: Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string StrategyId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether description succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the strategy mode. JA: Mode を取得します。</summary>
    public OperatorMode Mode { get; init; } = OperatorMode.Unknown;

    /// <summary>EN: Gets supported proposal kinds. JA: SupportedProposalKinds を取得します。</summary>
    public IReadOnlyList<ActionProposalKind> SupportedProposalKinds { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostics emitted while describing the strategy. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an operator strategy request.
/// EN: Documentation for public API. JA: OperatorStrategyRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyRequest
{
    /// <summary>EN: Gets the request identifier. JA: RequestId を取得します。</summary>
    public string RequestId { get; init; } = string.Empty;

    /// <summary>EN: Gets the operator mode. JA: Mode を取得します。</summary>
    public OperatorMode Mode { get; init; } = OperatorMode.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an operator strategy result.
/// EN: Documentation for public API. JA: OperatorStrategyResult の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether evaluation succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the operator decision. JA: Decision を取得します。</summary>
    public OperatorDecisionKind Decision { get; init; } = OperatorDecisionKind.Unknown;

    /// <summary>EN: Gets proposed actions. JA: Proposals を取得します。</summary>
    public IReadOnlyList<OperatorActionProposal> Proposals { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets evaluation diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when evaluation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an operator action proposal.
/// EN: Documentation for public API. JA: OperatorActionProposal の公開契約を定義します。
/// </summary>
public sealed record OperatorActionProposal
{
    /// <summary>EN: Gets the proposal identifier. JA: ProposalId を取得します。</summary>
    public string ProposalId { get; init; } = string.Empty;

    /// <summary>EN: Gets the proposal kind. JA: Kind を取得します。</summary>
    public ActionProposalKind Kind { get; init; } = ActionProposalKind.Unknown;

    /// <summary>EN: Gets confidence from 0 to 1. JA: Confidence を取得します。</summary>
    public double Confidence { get; init; }

    /// <summary>EN: Gets risk from 0 to 1. JA: Risk を取得します。</summary>
    public double Risk { get; init; }

    /// <summary>EN: Gets proposal metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an operator strategy reset request.
/// EN: Documentation for public API. JA: OperatorStrategyResetRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyResetRequest
{
    /// <summary>EN: Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an operator strategy reset result.
/// EN: Documentation for public API. JA: OperatorStrategyResetResult の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyResetResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether reset succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets reset diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when reset was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an operator strategy state request.
/// EN: Documentation for public API. JA: OperatorStrategyStateRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyStateRequest
{
    /// <summary>EN: Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an operator strategy state snapshot.
/// EN: Documentation for public API. JA: OperatorStrategyStateSnapshot の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyStateSnapshot
{
    /// <summary>EN: Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether state capture succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>EN: Gets the operator mode. JA: Mode を取得します。</summary>
    public OperatorMode Mode { get; init; } = OperatorMode.Unknown;

    /// <summary>EN: Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets snapshot diagnostics. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets snapshot metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an operator strategy profile update request.
/// EN: Documentation for public API. JA: OperatorStrategyProfileUpdateRequest の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyProfileUpdateRequest
{
    /// <summary>EN: Gets the strategy identifier. JA: StrategyId を取得します。</summary>
    public string? StrategyId { get; init; }

    /// <summary>EN: Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries an operator strategy profile update result.
/// EN: Documentation for public API. JA: OperatorStrategyProfileUpdateResult の公開契約を定義します。
/// </summary>
public sealed record OperatorStrategyProfileUpdateResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether update succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets update diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when update was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
