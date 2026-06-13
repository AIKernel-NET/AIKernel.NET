using AIKernel.Enums;

namespace AIKernel.Dtos.Contracts;

/// <summary>
/// Describes a versioned contract surface and its schema reference.
/// </summary>
public sealed record ContractMetadata
{
    /// <summary>Gets the contract identifier.</summary>
    public required string ContractId { get; init; }

    /// <summary>Gets the contract version.</summary>
    public required string Version { get; init; }

    /// <summary>Gets the schema URI for the contract payload.</summary>
    public required string SchemaUri { get; init; }

    /// <summary>Gets whether this contract surface is deprecated.</summary>
    public bool Deprecated { get; init; }

    /// <summary>Gets optional contract metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a contract validation request.
/// </summary>
public sealed record ContractValidationRequest
{
    /// <summary>Gets the request identifier.</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the contract metadata to validate against.</summary>
    public required ContractMetadata Contract { get; init; }

    /// <summary>Gets a deterministic payload hash or schema-local payload identifier.</summary>
    public required string PayloadReference { get; init; }

    /// <summary>Gets optional validation metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a generic policy evaluation request.
/// </summary>
public sealed record PolicyEvaluationRequest
{
    /// <summary>Gets the policy evaluation request identifier.</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the subject reference.</summary>
    public string? SubjectReference { get; init; }

    /// <summary>Gets the resource reference.</summary>
    public string? ResourceReference { get; init; }

    /// <summary>Gets the action reference.</summary>
    public string? ActionReference { get; init; }

    /// <summary>Gets optional policy evaluation metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries the result of contract validation.
/// </summary>
public sealed record ContractValidationResult
{
    /// <summary>Gets whether the contract payload is valid.</summary>
    public bool IsValid { get; init; }

    /// <summary>Gets a stable validation code.</summary>
    public string? Code { get; init; }

    /// <summary>Gets a human-readable validation message.</summary>
    public string? Message { get; init; }

    /// <summary>Gets optional diagnostics.</summary>
    public IReadOnlyDictionary<string, string> Diagnostics { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a contract difference for migration and compatibility review.
/// </summary>
public sealed record ContractDiff
{
    /// <summary>Gets the old contract metadata.</summary>
    public required ContractMetadata OldContract { get; init; }

    /// <summary>Gets the new contract metadata.</summary>
    public required ContractMetadata NewContract { get; init; }

    /// <summary>Gets whether the diff contains a breaking change.</summary>
    public bool HasBreakingChanges { get; init; }

    /// <summary>Gets a summary of changed contract members.</summary>
    public IReadOnlyList<string> ChangedMembers { get; init; } = [];

    /// <summary>Gets optional diagnostics.</summary>
    public IReadOnlyDictionary<string, string> Diagnostics { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a contract migration result.
/// </summary>
public sealed record MigrationResult
{
    /// <summary>Gets whether the migration succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the applied migration identifier.</summary>
    public string? MigrationId { get; init; }

    /// <summary>Gets the resulting contract metadata.</summary>
    public ContractMetadata? ResultContract { get; init; }

    /// <summary>Gets a stable failure code when migration fails.</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable failure message when migration fails.</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets optional diagnostics.</summary>
    public IReadOnlyDictionary<string, string> Diagnostics { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a policy decision with an optional reason message.
/// </summary>
public sealed record PolicyDecision
{
    /// <summary>Gets the policy decision kind.</summary>
    public PolicyDecisionKind Kind { get; init; } = PolicyDecisionKind.None;

    /// <summary>Gets a reason message suitable for audit logs.</summary>
    public string? Reason { get; init; }

    /// <summary>Gets optional decision metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a partial policy decision contributed by one policy.
/// </summary>
public sealed record PolicyDecisionFragment
{
    /// <summary>Gets the contributing policy identifier.</summary>
    public required string PolicyId { get; init; }

    /// <summary>Gets the decision fragment.</summary>
    public required PolicyDecision Decision { get; init; }

    /// <summary>Gets optional fragment metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a governance decision applied before side-effecting provider execution.
/// </summary>
public sealed record GovernanceDecision
{
    /// <summary>Gets the governance decision identifier.</summary>
    public required string DecisionId { get; init; }

    /// <summary>Gets the policy decision.</summary>
    public required PolicyDecision Decision { get; init; }

    /// <summary>Gets whether privileged action is approved.</summary>
    public bool PrivilegedActionApproved { get; init; }

    /// <summary>Gets optional governance decision metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a governance decision request.
/// </summary>
public sealed record GovernanceDecisionRequest
{
    /// <summary>Gets the governance request identifier.</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the policy evaluation request.</summary>
    public required PolicyEvaluationRequest PolicyRequest { get; init; }

    /// <summary>Gets optional governance request metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
