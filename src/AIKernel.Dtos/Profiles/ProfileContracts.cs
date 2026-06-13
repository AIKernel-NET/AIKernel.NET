using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Observability;
using AIKernel.Enums.Profiles;

namespace AIKernel.Dtos.Profiles;

/// <summary>
/// Carries a profile document.
/// JA: ProfileDocument の公開契約を定義します。
/// </summary>
public sealed record ProfileDocument
{
    /// <summary>Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string ProfileId { get; init; } = string.Empty;

    /// <summary>Gets the profile kind. JA: Kind を取得します。</summary>
    public ProfileKind Kind { get; init; } = ProfileKind.Unknown;

    /// <summary>Gets the profile format. JA: Format を取得します。</summary>
    public ProfileFormat Format { get; init; } = ProfileFormat.Unknown;

    /// <summary>Gets the profile version. JA: Version を取得します。</summary>
    public string? Version { get; init; }

    /// <summary>Gets profile content. JA: Content を取得します。</summary>
    public string? Content { get; init; }

    /// <summary>Gets profile metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Describes a profile.
/// JA: ProfileDescriptor の公開契約を定義します。
/// </summary>
public sealed record ProfileDescriptor
{
    /// <summary>Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string ProfileId { get; init; } = string.Empty;

    /// <summary>Gets the profile kind. JA: Kind を取得します。</summary>
    public ProfileKind Kind { get; init; } = ProfileKind.Unknown;

    /// <summary>Gets the profile version. JA: Version を取得します。</summary>
    public string? Version { get; init; }

    /// <summary>Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile load request.
/// JA: ProfileLoadRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileLoadRequest
{
    /// <summary>Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string ProfileId { get; init; } = string.Empty;

    /// <summary>Gets the profile kind. JA: Kind を取得します。</summary>
    public ProfileKind Kind { get; init; } = ProfileKind.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile load result.
/// JA: ProfileLoadResult の公開契約を定義します。
/// </summary>
public sealed record ProfileLoadResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether load succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the loaded profile. JA: Profile を取得します。</summary>
    public ProfileDocument? Profile { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets load diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when load was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile save request.
/// JA: ProfileSaveRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileSaveRequest
{
    /// <summary>Gets the profile to save. JA: Profile を取得します。</summary>
    public ProfileDocument Profile { get; init; } = new();

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile save result.
/// JA: ProfileSaveResult の公開契約を定義します。
/// </summary>
public sealed record ProfileSaveResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether save succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the saved profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets save diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when save was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile list request.
/// JA: ProfileListRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileListRequest
{
    /// <summary>Gets the profile kind filter. JA: Kind を取得します。</summary>
    public ProfileKind Kind { get; init; } = ProfileKind.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile list result.
/// JA: ProfileListResult の公開契約を定義します。
/// </summary>
public sealed record ProfileListResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether list succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets profile descriptors. JA: Profiles を取得します。</summary>
    public IReadOnlyList<ProfileDescriptor> Profiles { get; init; } = [];

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets list diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when list was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile version request.
/// JA: ProfileVersionRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileVersionRequest
{
    /// <summary>Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string ProfileId { get; init; } = string.Empty;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile version result.
/// JA: ProfileVersionResult の公開契約を定義します。
/// </summary>
public sealed record ProfileVersionResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether version lookup succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the profile version. JA: Version を取得します。</summary>
    public string? Version { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets version diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when version lookup was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile validation request.
/// JA: ProfileValidationRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileValidationRequest
{
    /// <summary>Gets the profile document. JA: Profile を取得します。</summary>
    public ProfileDocument Profile { get; init; } = new();

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile validation result.
/// JA: ProfileValidationResult の公開契約を定義します。
/// </summary>
public sealed record ProfileValidationResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether validation succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets validation diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when validation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile optimization plan request.
/// JA: ProfileOptimizationPlanRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationPlanRequest
{
    /// <summary>Gets the base profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>Gets the optimization goal. JA: Goal を取得します。</summary>
    public ProfileOptimizationGoal Goal { get; init; } = ProfileOptimizationGoal.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile optimization plan result.
/// JA: ProfileOptimizationPlanResult の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationPlanResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether planning succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets evidence references. JA: Evidence を取得します。</summary>
    public IReadOnlyList<ProfileOptimizationEvidenceRef> Evidence { get; init; } = [];

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets planning diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when planning was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile optimization request.
/// JA: ProfileOptimizationRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationRequest
{
    /// <summary>Gets the base profile. JA: BaseProfile を取得します。</summary>
    public ProfileDocument? BaseProfile { get; init; }

    /// <summary>Gets the optimization goal. JA: Goal を取得します。</summary>
    public ProfileOptimizationGoal Goal { get; init; } = ProfileOptimizationGoal.Unknown;

    /// <summary>Gets evidence references. JA: Evidence を取得します。</summary>
    public IReadOnlyList<ProfileOptimizationEvidenceRef> Evidence { get; init; } = [];

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile optimization result.
/// JA: ProfileOptimizationResult の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether optimization succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the optimization decision. JA: Decision を取得します。</summary>
    public ProfileOptimizationDecision Decision { get; init; } = ProfileOptimizationDecision.Unknown;

    /// <summary>Gets profile candidates. JA: Candidates を取得します。</summary>
    public IReadOnlyList<ProfileCandidate> Candidates { get; init; } = [];

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets optimization diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when optimization was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile candidate.
/// JA: ProfileCandidate の公開契約を定義します。
/// </summary>
public sealed record ProfileCandidate
{
    /// <summary>Gets the candidate identifier. JA: CandidateId を取得します。</summary>
    public string CandidateId { get; init; } = string.Empty;

    /// <summary>Gets the candidate profile. JA: Profile を取得します。</summary>
    public ProfileDocument? Profile { get; init; }

    /// <summary>Gets candidate score. JA: Score を取得します。</summary>
    public double Score { get; init; }

    /// <summary>Gets candidate metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile comparison request.
/// JA: ProfileComparisonRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileComparisonRequest
{
    /// <summary>Gets the left profile. JA: Left を取得します。</summary>
    public ProfileDocument? Left { get; init; }

    /// <summary>Gets the right profile. JA: Right を取得します。</summary>
    public ProfileDocument? Right { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile comparison result.
/// JA: ProfileComparisonResult の公開契約を定義します。
/// </summary>
public sealed record ProfileComparisonResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether comparison succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets comparison diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when comparison was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets comparison metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile optimization apply request.
/// JA: ProfileOptimizationApplyRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationApplyRequest
{
    /// <summary>Gets the selected candidate. JA: Candidate を取得します。</summary>
    public ProfileCandidate? Candidate { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a profile optimization apply result.
/// JA: ProfileOptimizationApplyResult の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationApplyResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether apply succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the applied profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets apply diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when apply was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// References profile optimization evidence.
/// JA: ProfileOptimizationEvidenceRef の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationEvidenceRef
{
    /// <summary>Gets the evidence identifier. JA: EvidenceId を取得します。</summary>
    public string EvidenceId { get; init; } = string.Empty;

    /// <summary>Gets the evidence kind. JA: Kind を取得します。</summary>
    public EvidenceKind Kind { get; init; } = EvidenceKind.Unknown;

    /// <summary>Gets reference metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
