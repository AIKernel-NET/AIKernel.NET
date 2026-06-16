using AIKernel.Enums;

namespace AIKernel.Dtos.Contracts;

/// <summary>
/// EN: Describes a versioned contract surface and its schema reference.
/// EN: Documentation for public API. JA: ContractMetadata の公開契約を定義します。
/// </summary>
public sealed record ContractMetadata
{
    /// <summary>EN: Gets the contract identifier. JA: ContractId を取得します。</summary>
    public required string ContractId { get; init; }

    /// <summary>EN: Gets the contract version. JA: Version を取得します。</summary>
    public required string Version { get; init; }

    /// <summary>EN: Gets the schema URI for the contract payload. JA: SchemaUri を取得します。</summary>
    public required string SchemaUri { get; init; }

    /// <summary>EN: Gets whether this contract surface is deprecated. JA: Deprecated を取得します。</summary>
    public bool Deprecated { get; init; }

    /// <summary>EN: Gets optional contract metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a contract validation request.
/// EN: Documentation for public API. JA: ContractValidationRequest の公開契約を定義します。
/// </summary>
public sealed record ContractValidationRequest
{
    /// <summary>EN: Gets the request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>EN: Gets the contract metadata to validate against. JA: Contract を取得します。</summary>
    public required ContractMetadata Contract { get; init; }

    /// <summary>EN: Gets a deterministic payload hash or schema-local payload identifier. JA: PayloadReference を取得します。</summary>
    public required string PayloadReference { get; init; }

    /// <summary>EN: Gets optional validation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a generic policy evaluation request.
/// EN: Documentation for public API. JA: PolicyEvaluationRequest の公開契約を定義します。
/// </summary>
public sealed record PolicyEvaluationRequest
{
    /// <summary>EN: Gets the policy evaluation request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>EN: Gets the subject reference. JA: SubjectReference を取得します。</summary>
    public string? SubjectReference { get; init; }

    /// <summary>EN: Gets the resource reference. JA: ResourceReference を取得します。</summary>
    public string? ResourceReference { get; init; }

    /// <summary>EN: Gets the action reference. JA: ActionReference を取得します。</summary>
    public string? ActionReference { get; init; }

    /// <summary>EN: Gets optional policy evaluation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries the result of contract validation.
/// EN: Documentation for public API. JA: ContractValidationResult の公開契約を定義します。
/// </summary>
public sealed record ContractValidationResult
{
    /// <summary>EN: Gets whether the contract payload is valid. JA: IsValid を取得します。</summary>
    public bool IsValid { get; init; }

    /// <summary>EN: Gets a stable validation code. JA: Code を取得します。</summary>
    public string? Code { get; init; }

    /// <summary>EN: Gets a human-readable validation message. JA: Message を取得します。</summary>
    public string? Message { get; init; }

    /// <summary>EN: Gets optional diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyDictionary<string, string> Diagnostics { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Describes a contract difference for migration and compatibility review.
/// EN: Documentation for public API. JA: ContractDiff の公開契約を定義します。
/// </summary>
public sealed record ContractDiff
{
    /// <summary>EN: Gets the old contract metadata. JA: OldContract を取得します。</summary>
    public required ContractMetadata OldContract { get; init; }

    /// <summary>EN: Gets the new contract metadata. JA: NewContract を取得します。</summary>
    public required ContractMetadata NewContract { get; init; }

    /// <summary>EN: Gets whether the diff contains a breaking change. JA: HasBreakingChanges を取得します。</summary>
    public bool HasBreakingChanges { get; init; }

    /// <summary>EN: Gets a summary of changed contract members. JA: ChangedMembers を取得します。</summary>
    public IReadOnlyList<string> ChangedMembers { get; init; } = [];

    /// <summary>EN: Gets optional diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyDictionary<string, string> Diagnostics { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a contract migration result.
/// EN: Documentation for public API. JA: MigrationResult の公開契約を定義します。
/// </summary>
public sealed record MigrationResult
{
    /// <summary>EN: Gets whether the migration succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the applied migration identifier. JA: MigrationId を取得します。</summary>
    public string? MigrationId { get; init; }

    /// <summary>EN: Gets the resulting contract metadata. JA: ResultContract を取得します。</summary>
    public ContractMetadata? ResultContract { get; init; }

    /// <summary>EN: Gets a stable failure code when migration fails. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable failure message when migration fails. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets optional diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyDictionary<string, string> Diagnostics { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a policy decision with an optional reason message.
/// EN: Documentation for public API. JA: PolicyDecision の公開契約を定義します。
/// </summary>
public sealed record PolicyDecision
{
    /// <summary>EN: Gets the policy decision kind. JA: Kind を取得します。</summary>
    public PolicyDecisionKind Kind { get; init; } = PolicyDecisionKind.None;

    /// <summary>EN: Gets a reason message suitable for audit logs. JA: Reason を取得します。</summary>
    public string? Reason { get; init; }

    /// <summary>EN: Gets optional decision metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a partial policy decision contributed by one policy.
/// EN: Documentation for public API. JA: PolicyDecisionFragment の公開契約を定義します。
/// </summary>
public sealed record PolicyDecisionFragment
{
    /// <summary>EN: Gets the contributing policy identifier. JA: PolicyId を取得します。</summary>
    public required string PolicyId { get; init; }

    /// <summary>EN: Gets the decision fragment. JA: Decision を取得します。</summary>
    public required PolicyDecision Decision { get; init; }

    /// <summary>EN: Gets optional fragment metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a governance decision applied before side-effecting provider execution.
/// EN: Documentation for public API. JA: GovernanceDecision の公開契約を定義します。
/// </summary>
public sealed record GovernanceDecision
{
    /// <summary>EN: Gets the governance decision identifier. JA: DecisionId を取得します。</summary>
    public required string DecisionId { get; init; }

    /// <summary>EN: Gets the policy decision. JA: Decision を取得します。</summary>
    public required PolicyDecision Decision { get; init; }

    /// <summary>EN: Gets whether privileged action is approved. JA: PrivilegedActionApproved を取得します。</summary>
    public bool PrivilegedActionApproved { get; init; }

    /// <summary>EN: Gets optional governance decision metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a governance decision request.
/// EN: Documentation for public API. JA: GovernanceDecisionRequest の公開契約を定義します。
/// </summary>
public sealed record GovernanceDecisionRequest
{
    /// <summary>EN: Gets the governance request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>EN: Gets the policy evaluation request. JA: PolicyRequest を取得します。</summary>
    public required PolicyEvaluationRequest PolicyRequest { get; init; }

    /// <summary>EN: Gets optional governance request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
