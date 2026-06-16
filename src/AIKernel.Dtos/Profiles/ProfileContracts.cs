using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Observability;
using AIKernel.Enums.Profiles;

namespace AIKernel.Dtos.Profiles;

/// <summary>
/// EN: Carries a profile document.
/// EN: Documentation for public API. JA: ProfileDocument の公開契約を定義します。
/// </summary>
public sealed record ProfileDocument
{
    /// <summary>EN: Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string ProfileId { get; init; } = string.Empty;

    /// <summary>EN: Gets the profile kind. JA: Kind を取得します。</summary>
    public ProfileKind Kind { get; init; } = ProfileKind.Unknown;

    /// <summary>EN: Gets the profile format. JA: Format を取得します。</summary>
    public ProfileFormat Format { get; init; } = ProfileFormat.Unknown;

    /// <summary>EN: Gets the profile version. JA: Version を取得します。</summary>
    public string? Version { get; init; }

    /// <summary>EN: Gets profile content. JA: Content を取得します。</summary>
    public string? Content { get; init; }

    /// <summary>EN: Gets profile metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Describes a profile.
/// EN: Documentation for public API. JA: ProfileDescriptor の公開契約を定義します。
/// </summary>
public sealed record ProfileDescriptor
{
    /// <summary>EN: Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string ProfileId { get; init; } = string.Empty;

    /// <summary>EN: Gets the profile kind. JA: Kind を取得します。</summary>
    public ProfileKind Kind { get; init; } = ProfileKind.Unknown;

    /// <summary>EN: Gets the profile version. JA: Version を取得します。</summary>
    public string? Version { get; init; }

    /// <summary>EN: Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile load request.
/// EN: Documentation for public API. JA: ProfileLoadRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileLoadRequest
{
    /// <summary>EN: Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string ProfileId { get; init; } = string.Empty;

    /// <summary>EN: Gets the profile kind. JA: Kind を取得します。</summary>
    public ProfileKind Kind { get; init; } = ProfileKind.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile load result.
/// EN: Documentation for public API. JA: ProfileLoadResult の公開契約を定義します。
/// </summary>
public sealed record ProfileLoadResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether load succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the loaded profile. JA: Profile を取得します。</summary>
    public ProfileDocument? Profile { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets load diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when load was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile save request.
/// EN: Documentation for public API. JA: ProfileSaveRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileSaveRequest
{
    /// <summary>EN: Gets the profile to save. JA: Profile を取得します。</summary>
    public ProfileDocument Profile { get; init; } = new();

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile save result.
/// EN: Documentation for public API. JA: ProfileSaveResult の公開契約を定義します。
/// </summary>
public sealed record ProfileSaveResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether save succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the saved profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets save diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when save was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile list request.
/// EN: Documentation for public API. JA: ProfileListRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileListRequest
{
    /// <summary>EN: Gets the profile kind filter. JA: Kind を取得します。</summary>
    public ProfileKind Kind { get; init; } = ProfileKind.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile list result.
/// EN: Documentation for public API. JA: ProfileListResult の公開契約を定義します。
/// </summary>
public sealed record ProfileListResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether list succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets profile descriptors. JA: Profiles を取得します。</summary>
    public IReadOnlyList<ProfileDescriptor> Profiles { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets list diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when list was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile version request.
/// EN: Documentation for public API. JA: ProfileVersionRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileVersionRequest
{
    /// <summary>EN: Gets the profile identifier. JA: ProfileId を取得します。</summary>
    public string ProfileId { get; init; } = string.Empty;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile version result.
/// EN: Documentation for public API. JA: ProfileVersionResult の公開契約を定義します。
/// </summary>
public sealed record ProfileVersionResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether version lookup succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the profile version. JA: Version を取得します。</summary>
    public string? Version { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets version diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when version lookup was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile validation request.
/// EN: Documentation for public API. JA: ProfileValidationRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileValidationRequest
{
    /// <summary>EN: Gets the profile document. JA: Profile を取得します。</summary>
    public ProfileDocument Profile { get; init; } = new();

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile validation result.
/// EN: Documentation for public API. JA: ProfileValidationResult の公開契約を定義します。
/// </summary>
public sealed record ProfileValidationResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether validation succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets validation diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when validation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile optimization plan request.
/// EN: Documentation for public API. JA: ProfileOptimizationPlanRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationPlanRequest
{
    /// <summary>EN: Gets the base profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>EN: Gets the optimization goal. JA: Goal を取得します。</summary>
    public ProfileOptimizationGoal Goal { get; init; } = ProfileOptimizationGoal.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile optimization plan result.
/// EN: Documentation for public API. JA: ProfileOptimizationPlanResult の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationPlanResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether planning succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets evidence references. JA: Evidence を取得します。</summary>
    public IReadOnlyList<ProfileOptimizationEvidenceRef> Evidence { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets planning diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when planning was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile optimization request.
/// EN: Documentation for public API. JA: ProfileOptimizationRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationRequest
{
    /// <summary>EN: Gets the base profile. JA: BaseProfile を取得します。</summary>
    public ProfileDocument? BaseProfile { get; init; }

    /// <summary>EN: Gets the optimization goal. JA: Goal を取得します。</summary>
    public ProfileOptimizationGoal Goal { get; init; } = ProfileOptimizationGoal.Unknown;

    /// <summary>EN: Gets evidence references. JA: Evidence を取得します。</summary>
    public IReadOnlyList<ProfileOptimizationEvidenceRef> Evidence { get; init; } = [];

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile optimization result.
/// EN: Documentation for public API. JA: ProfileOptimizationResult の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether optimization succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the optimization decision. JA: Decision を取得します。</summary>
    public ProfileOptimizationDecision Decision { get; init; } = ProfileOptimizationDecision.Unknown;

    /// <summary>EN: Gets profile candidates. JA: Candidates を取得します。</summary>
    public IReadOnlyList<ProfileCandidate> Candidates { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets optimization diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when optimization was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile candidate.
/// EN: Documentation for public API. JA: ProfileCandidate の公開契約を定義します。
/// </summary>
public sealed record ProfileCandidate
{
    /// <summary>EN: Gets the candidate identifier. JA: CandidateId を取得します。</summary>
    public string CandidateId { get; init; } = string.Empty;

    /// <summary>EN: Gets the candidate profile. JA: Profile を取得します。</summary>
    public ProfileDocument? Profile { get; init; }

    /// <summary>EN: Gets candidate score. JA: Score を取得します。</summary>
    public double Score { get; init; }

    /// <summary>EN: Gets candidate metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile comparison request.
/// EN: Documentation for public API. JA: ProfileComparisonRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileComparisonRequest
{
    /// <summary>EN: Gets the left profile. JA: Left を取得します。</summary>
    public ProfileDocument? Left { get; init; }

    /// <summary>EN: Gets the right profile. JA: Right を取得します。</summary>
    public ProfileDocument? Right { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile comparison result.
/// EN: Documentation for public API. JA: ProfileComparisonResult の公開契約を定義します。
/// </summary>
public sealed record ProfileComparisonResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether comparison succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets comparison diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when comparison was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets comparison metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile optimization apply request.
/// EN: Documentation for public API. JA: ProfileOptimizationApplyRequest の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationApplyRequest
{
    /// <summary>EN: Gets the selected candidate. JA: Candidate を取得します。</summary>
    public ProfileCandidate? Candidate { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a profile optimization apply result.
/// EN: Documentation for public API. JA: ProfileOptimizationApplyResult の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationApplyResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether apply succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the applied profile identifier. JA: ProfileId を取得します。</summary>
    public string? ProfileId { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets apply diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when apply was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: References profile optimization evidence.
/// EN: Documentation for public API. JA: ProfileOptimizationEvidenceRef の公開契約を定義します。
/// </summary>
public sealed record ProfileOptimizationEvidenceRef
{
    /// <summary>EN: Gets the evidence identifier. JA: EvidenceId を取得します。</summary>
    public string EvidenceId { get; init; } = string.Empty;

    /// <summary>EN: Gets the evidence kind. JA: Kind を取得します。</summary>
    public EvidenceKind Kind { get; init; } = EvidenceKind.Unknown;

    /// <summary>EN: Gets reference metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
