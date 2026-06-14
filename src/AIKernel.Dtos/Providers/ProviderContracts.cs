using AIKernel.Dtos.Contracts;
using AIKernel.Enums;

namespace AIKernel.Dtos.Providers;

/// <summary>
/// Describes a logical provider capability for package-boundary routing.
/// JA: ProviderCapability の公開契約を定義します。
/// </summary>
public sealed record ProviderCapability
{
    /// <summary>Gets the logical capability identifier. JA: LogicalCapabilityId を取得します。</summary>
    public required string LogicalCapabilityId { get; init; }

    /// <summary>Gets the provider-specific capability identifier. JA: ProviderCapabilityId を取得します。</summary>
    public required string ProviderCapabilityId { get; init; }

    /// <summary>Gets the capability flags. JA: Flags を取得します。</summary>
    public ProviderCapabilityFlags Flags { get; init; } = ProviderCapabilityFlags.None;

    /// <summary>Gets the provider kind that owns the capability. JA: Kind を取得します。</summary>
    public ProviderKind Kind { get; init; } = ProviderKind.Unknown;

    /// <summary>Gets the contract interface identifier. JA: InterfaceId を取得します。</summary>
    public string? InterfaceId { get; init; }

    /// <summary>Gets input modalities accepted by this capability. JA: InputModalities を取得します。</summary>
    public InputModalities InputModalities { get; init; } = InputModalities.None;

    /// <summary>Gets output modalities produced by this capability. JA: OutputModalities を取得します。</summary>
    public OutputModalities OutputModalities { get; init; } = OutputModalities.None;

    /// <summary>Gets the risk level for this capability. JA: RiskLevel を取得します。</summary>
    public ProviderRiskLevel RiskLevel { get; init; } = ProviderRiskLevel.Unknown;

    /// <summary>Gets capability availability details. JA: Availability を取得します。</summary>
    public CapabilityAvailability Availability { get; init; } = new();

    /// <summary>Gets whether replay metadata is supported. JA: SupportsReplay を取得します。</summary>
    public bool SupportsReplay { get; init; }

    /// <summary>Gets whether inline safety policy checks are supported. JA: SupportsInlineSafetyPolicy を取得します。</summary>
    public bool SupportsInlineSafetyPolicy { get; init; }

    /// <summary>Gets whether this capability can perform privileged action. JA: PrivilegedAction を取得します。</summary>
    public bool PrivilegedAction { get; init; }

    /// <summary>Gets optional capability metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes provider capability availability.
/// JA: CapabilityAvailability の公開契約を定義します。
/// </summary>
public sealed record CapabilityAvailability
{
    /// <summary>Gets whether the capability is available. JA: IsAvailable を取得します。</summary>
    public bool IsAvailable { get; init; }

    /// <summary>Gets the availability reason. JA: Reason を取得します。</summary>
    public ProviderAvailabilityReason Reason { get; init; } = ProviderAvailabilityReason.None;

    /// <summary>Gets an optional quality level from 0 to 1. JA: QualityLevel を取得します。</summary>
    public double? QualityLevel { get; init; }

    /// <summary>Gets optional availability metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a capability query for provider probing and routing.
/// JA: CapabilityQuery の公開契約を定義します。
/// </summary>
public sealed record CapabilityQuery
{
    /// <summary>Gets the requested logical capability identifier. JA: LogicalCapabilityId を取得します。</summary>
    public required string LogicalCapabilityId { get; init; }

    /// <summary>Gets required input modalities. JA: RequiredInputs を取得します。</summary>
    public InputModalities RequiredInputs { get; init; } = InputModalities.None;

    /// <summary>Gets required output modalities. JA: RequiredOutputs を取得します。</summary>
    public OutputModalities RequiredOutputs { get; init; } = OutputModalities.None;

    /// <summary>Gets the maximum permitted risk level. JA: MaximumRiskLevel を取得します。</summary>
    public ProviderRiskLevel MaximumRiskLevel { get; init; } = ProviderRiskLevel.Privileged;

    /// <summary>Gets whether privileged action is allowed by the caller. JA: AllowPrivilegedAction を取得します。</summary>
    public bool AllowPrivilegedAction { get; init; }

    /// <summary>Gets optional query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries preparation consent for hosted runtime, model, and protected assets.
/// JA: PreparationConsent の公開契約を定義します。
/// </summary>
public sealed record PreparationConsent
{
    /// <summary>Gets whether terms were accepted. JA: AcceptedTerms を取得します。</summary>
    public bool AcceptedTerms { get; init; }

    /// <summary>Gets whether network download is allowed. JA: AllowNetworkDownload を取得します。</summary>
    public bool AllowNetworkDownload { get; init; }

    /// <summary>Gets whether model acquisition is allowed. JA: AllowModelAcquisition を取得します。</summary>
    public bool AllowModelAcquisition { get; init; }

    /// <summary>Gets whether runtime artifact loading is allowed. JA: AllowRuntimeArtifactLoad を取得します。</summary>
    public bool AllowRuntimeArtifactLoad { get; init; }

    /// <summary>Gets whether protected asset loading is allowed. JA: AllowProtectedAssetLoad を取得します。</summary>
    public bool AllowProtectedAssetLoad { get; init; }

    /// <summary>Gets a consent trace identifier. JA: ConsentTraceId を取得します。</summary>
    public string? ConsentTraceId { get; init; }

    /// <summary>Gets the consent grant timestamp supplied by the caller. JA: GrantedAt を取得します。</summary>
    public DateTimeOffset? GrantedAt { get; init; }

    /// <summary>Gets optional consent metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();

    /// <summary>Gets an empty consent value. JA: None を取得します。</summary>
    public static PreparationConsent None { get; } = new();
}

/// <summary>
/// Carries preparation policy thresholds.
/// JA: PreparationPolicy の公開契約を定義します。
/// </summary>
public sealed record PreparationPolicy
{
    /// <summary>Gets whether fail-closed consent is required. JA: RequireExplicitConsent を取得します。</summary>
    public bool RequireExplicitConsent { get; init; } = true;

    /// <summary>Gets whether network access is allowed by policy. JA: AllowNetworkAccess を取得します。</summary>
    public bool AllowNetworkAccess { get; init; }

    /// <summary>Gets the maximum allowed estimated cost. JA: MaximumEstimatedCost を取得します。</summary>
    public decimal? MaximumEstimatedCost { get; init; }

    /// <summary>Gets the maximum allowed latency in milliseconds. JA: MaximumLatencyMilliseconds を取得します。</summary>
    public double? MaximumLatencyMilliseconds { get; init; }

    /// <summary>Gets optional policy metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();

    /// <summary>Gets the default preparation policy. JA: Default を取得します。</summary>
    public static PreparationPolicy Default { get; } = new();
}

/// <summary>
/// Carries provider preparation context.
/// JA: ProviderPreparationContext の公開契約を定義します。
/// </summary>
public sealed record ProviderPreparationContext
{
    /// <summary>Gets the preparation identifier. JA: PreparationId を取得します。</summary>
    public required string PreparationId { get; init; }

    /// <summary>Gets the requested logical capability identifier. JA: LogicalCapabilityId を取得します。</summary>
    public string? LogicalCapabilityId { get; init; }

    /// <summary>Gets the preparation policy. JA: Policy を取得します。</summary>
    public PreparationPolicy Policy { get; init; } = PreparationPolicy.Default;

    /// <summary>Gets the preparation consent. JA: Consent を取得します。</summary>
    public PreparationConsent Consent { get; init; } = PreparationConsent.None;

    /// <summary>Gets optional preparation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries provider execution context.
/// JA: ProviderExecutionContext の公開契約を定義します。
/// </summary>
public sealed record ProviderExecutionContext
{
    /// <summary>Gets the execution identifier. JA: ExecutionId を取得します。</summary>
    public required string ExecutionId { get; init; }

    /// <summary>Gets the runtime control mode. JA: ControlMode を取得します。</summary>
    public RuntimeControlMode ControlMode { get; init; } = RuntimeControlMode.Normal;

    /// <summary>Gets the governance decision associated with this execution. JA: GovernanceDecision を取得します。</summary>
    public GovernanceDecision? GovernanceDecision { get; init; }

    /// <summary>Gets the replay trace identifier. JA: ReplayTraceId を取得します。</summary>
    public string? ReplayTraceId { get; init; }

    /// <summary>Gets optional execution metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries provider diagnostics.
/// JA: ProviderDiagnostic の公開契約を定義します。
/// </summary>
public sealed record ProviderDiagnostic
{
    /// <summary>Gets the diagnostic code. JA: Code を取得します。</summary>
    public required string Code { get; init; }

    /// <summary>Gets the diagnostic message. JA: Message を取得します。</summary>
    public string? Message { get; init; }

    /// <summary>Gets whether the diagnostic describes a retryable failure. JA: IsRetryable を取得します。</summary>
    public bool IsRetryable { get; init; }

    /// <summary>Gets optional diagnostic metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries provider result data without throwing contract-package exceptions.
/// JA: ProviderResult の公開契約を定義します。
/// </summary>
public sealed record ProviderResult<T>
{
    /// <summary>Gets whether the provider operation succeeded. JA: Success を取得します。</summary>
    public bool Success { get; init; }

    /// <summary>Gets the result value when successful. JA: Value を取得します。</summary>
    public T? Value { get; init; }

    /// <summary>Gets a stable failure code. JA: FailureCode を取得します。</summary>
    public string? FailureCode { get; init; }

    /// <summary>Gets a human-readable failure message. JA: FailureMessage を取得します。</summary>
    public string? FailureMessage { get; init; }

    /// <summary>Gets provider diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<ProviderDiagnostic> Diagnostics { get; init; } = [];
}

/// <summary>
/// Carries routing metadata for provider selection.
/// JA: RoutingContext の公開契約を定義します。
/// </summary>
public sealed record RoutingContext
{
    /// <summary>Gets the requested logical capability identifier. JA: LogicalCapabilityId を取得します。</summary>
    public required string LogicalCapabilityId { get; init; }

    /// <summary>Gets a health score from 0 to 1. JA: HealthScore を取得します。</summary>
    public double HealthScore { get; init; }

    /// <summary>Gets estimated execution cost. JA: EstimatedCost を取得します。</summary>
    public decimal EstimatedCost { get; init; }

    /// <summary>Gets estimated latency. JA: EstimatedLatency を取得します。</summary>
    public TimeSpan EstimatedLatency { get; init; }

    /// <summary>Gets optional routing metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries provider routing policy constraints.
/// JA: RoutingPolicy の公開契約を定義します。
/// </summary>
public sealed record RoutingPolicy
{
    /// <summary>Gets the routing policy identifier. JA: PolicyId を取得します。</summary>
    public required string PolicyId { get; init; }

    /// <summary>Gets the minimum health score from 0 to 1. JA: MinimumHealthScore を取得します。</summary>
    public double MinimumHealthScore { get; init; }

    /// <summary>Gets the maximum allowed estimated cost. JA: MaximumEstimatedCost を取得します。</summary>
    public decimal? MaximumEstimatedCost { get; init; }

    /// <summary>Gets the maximum allowed estimated latency. JA: MaximumEstimatedLatency を取得します。</summary>
    public TimeSpan? MaximumEstimatedLatency { get; init; }

    /// <summary>Gets optional routing policy metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
