using AIKernel.Dtos.Contracts;
using AIKernel.Enums;

namespace AIKernel.Dtos.Providers;

/// <summary>
/// EN: Describes a logical provider capability for package-boundary routing.
/// EN: Documentation for public API. JA: ProviderCapability の公開契約を定義します。
/// </summary>
public sealed record ProviderCapability
{
    /// <summary>EN: Gets the logical capability identifier. JA: LogicalCapabilityId を取得します。</summary>
    public required string LogicalCapabilityId { get; init; }

    /// <summary>EN: Gets the provider-specific capability identifier. JA: ProviderCapabilityId を取得します。</summary>
    public required string ProviderCapabilityId { get; init; }

    /// <summary>EN: Gets the capability flags. JA: Flags を取得します。</summary>
    public ProviderCapabilityFlags Flags { get; init; } = ProviderCapabilityFlags.None;

    /// <summary>EN: Gets the provider kind that owns the capability. JA: Kind を取得します。</summary>
    public ProviderKind Kind { get; init; } = ProviderKind.Unknown;

    /// <summary>EN: Gets the contract interface identifier. JA: InterfaceId を取得します。</summary>
    public string? InterfaceId { get; init; }

    /// <summary>EN: Gets input modalities accepted by this capability. JA: InputModalities を取得します。</summary>
    public InputModalities InputModalities { get; init; } = InputModalities.None;

    /// <summary>EN: Gets output modalities produced by this capability. JA: OutputModalities を取得します。</summary>
    public OutputModalities OutputModalities { get; init; } = OutputModalities.None;

    /// <summary>EN: Gets the risk level for this capability. JA: RiskLevel を取得します。</summary>
    public ProviderRiskLevel RiskLevel { get; init; } = ProviderRiskLevel.Unknown;

    /// <summary>EN: Gets capability availability details. JA: Availability を取得します。</summary>
    public CapabilityAvailability Availability { get; init; } = new();

    /// <summary>EN: Gets whether replay metadata is supported. JA: SupportsReplay を取得します。</summary>
    public bool SupportsReplay { get; init; }

    /// <summary>EN: Gets whether inline safety policy checks are supported. JA: SupportsInlineSafetyPolicy を取得します。</summary>
    public bool SupportsInlineSafetyPolicy { get; init; }

    /// <summary>EN: Gets whether this capability can perform privileged action. JA: PrivilegedAction を取得します。</summary>
    public bool PrivilegedAction { get; init; }

    /// <summary>EN: Gets optional capability metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Describes provider capability availability.
/// EN: Documentation for public API. JA: CapabilityAvailability の公開契約を定義します。
/// </summary>
public sealed record CapabilityAvailability
{
    /// <summary>EN: Gets whether the capability is available. JA: IsAvailable を取得します。</summary>
    public bool IsAvailable { get; init; }

    /// <summary>EN: Gets the availability reason. JA: Reason を取得します。</summary>
    public ProviderAvailabilityReason Reason { get; init; } = ProviderAvailabilityReason.None;

    /// <summary>EN: Gets an optional quality level from 0 to 1. JA: QualityLevel を取得します。</summary>
    public double? QualityLevel { get; init; }

    /// <summary>EN: Gets optional availability metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a capability query for provider probing and routing.
/// EN: Documentation for public API. JA: CapabilityQuery の公開契約を定義します。
/// </summary>
public sealed record CapabilityQuery
{
    /// <summary>EN: Gets the requested logical capability identifier. JA: LogicalCapabilityId を取得します。</summary>
    public required string LogicalCapabilityId { get; init; }

    /// <summary>EN: Gets required input modalities. JA: RequiredInputs を取得します。</summary>
    public InputModalities RequiredInputs { get; init; } = InputModalities.None;

    /// <summary>EN: Gets required output modalities. JA: RequiredOutputs を取得します。</summary>
    public OutputModalities RequiredOutputs { get; init; } = OutputModalities.None;

    /// <summary>EN: Gets the maximum permitted risk level. JA: MaximumRiskLevel を取得します。</summary>
    public ProviderRiskLevel MaximumRiskLevel { get; init; } = ProviderRiskLevel.Privileged;

    /// <summary>EN: Gets whether privileged action is allowed by the caller. JA: AllowPrivilegedAction を取得します。</summary>
    public bool AllowPrivilegedAction { get; init; }

    /// <summary>EN: Gets optional query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries preparation consent for hosted runtime, model, and protected assets.
/// EN: Documentation for public API. JA: PreparationConsent の公開契約を定義します。
/// </summary>
public sealed record PreparationConsent
{
    /// <summary>EN: Gets whether terms were accepted. JA: AcceptedTerms を取得します。</summary>
    public bool AcceptedTerms { get; init; }

    /// <summary>EN: Gets whether network download is allowed. JA: AllowNetworkDownload を取得します。</summary>
    public bool AllowNetworkDownload { get; init; }

    /// <summary>EN: Gets whether model acquisition is allowed. JA: AllowModelAcquisition を取得します。</summary>
    public bool AllowModelAcquisition { get; init; }

    /// <summary>EN: Gets whether runtime artifact loading is allowed. JA: AllowRuntimeArtifactLoad を取得します。</summary>
    public bool AllowRuntimeArtifactLoad { get; init; }

    /// <summary>EN: Gets whether protected asset loading is allowed. JA: AllowProtectedAssetLoad を取得します。</summary>
    public bool AllowProtectedAssetLoad { get; init; }

    /// <summary>EN: Gets a consent trace identifier. JA: ConsentTraceId を取得します。</summary>
    public string? ConsentTraceId { get; init; }

    /// <summary>EN: Gets the consent grant timestamp supplied by the caller. JA: GrantedAt を取得します。</summary>
    public DateTimeOffset? GrantedAt { get; init; }

    /// <summary>EN: Gets optional consent metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();

    /// <summary>EN: Gets an empty consent value. JA: None を取得します。</summary>
    public static PreparationConsent None { get; } = new();
}

/// <summary>
/// EN: Carries preparation policy thresholds.
/// EN: Documentation for public API. JA: PreparationPolicy の公開契約を定義します。
/// </summary>
public sealed record PreparationPolicy
{
    /// <summary>EN: Gets whether fail-closed consent is required. JA: RequireExplicitConsent を取得します。</summary>
    public bool RequireExplicitConsent { get; init; } = true;

    /// <summary>EN: Gets whether network access is allowed by policy. JA: AllowNetworkAccess を取得します。</summary>
    public bool AllowNetworkAccess { get; init; }

    /// <summary>EN: Gets the maximum allowed estimated cost. JA: MaximumEstimatedCost を取得します。</summary>
    public decimal? MaximumEstimatedCost { get; init; }

    /// <summary>EN: Gets the maximum allowed latency in milliseconds. JA: MaximumLatencyMilliseconds を取得します。</summary>
    public double? MaximumLatencyMilliseconds { get; init; }

    /// <summary>EN: Gets optional policy metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();

    /// <summary>EN: Gets the default preparation policy. JA: Default を取得します。</summary>
    public static PreparationPolicy Default { get; } = new();
}

/// <summary>
/// EN: Carries provider preparation context.
/// EN: Documentation for public API. JA: ProviderPreparationContext の公開契約を定義します。
/// </summary>
public sealed record ProviderPreparationContext
{
    /// <summary>EN: Gets the preparation identifier. JA: PreparationId を取得します。</summary>
    public required string PreparationId { get; init; }

    /// <summary>EN: Gets the requested logical capability identifier. JA: LogicalCapabilityId を取得します。</summary>
    public string? LogicalCapabilityId { get; init; }

    /// <summary>EN: Gets the preparation policy. JA: Policy を取得します。</summary>
    public PreparationPolicy Policy { get; init; } = PreparationPolicy.Default;

    /// <summary>EN: Gets the preparation consent. JA: Consent を取得します。</summary>
    public PreparationConsent Consent { get; init; } = PreparationConsent.None;

    /// <summary>EN: Gets optional preparation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries provider execution context.
/// EN: Documentation for public API. JA: ProviderExecutionContext の公開契約を定義します。
/// </summary>
public sealed record ProviderExecutionContext
{
    /// <summary>EN: Gets the execution identifier. JA: ExecutionId を取得します。</summary>
    public required string ExecutionId { get; init; }

    /// <summary>EN: Gets the runtime control mode. JA: ControlMode を取得します。</summary>
    public RuntimeControlMode ControlMode { get; init; } = RuntimeControlMode.Normal;

    /// <summary>EN: Gets the governance decision associated with this execution. JA: GovernanceDecision を取得します。</summary>
    public GovernanceDecision? GovernanceDecision { get; init; }

    /// <summary>EN: Gets the replay trace identifier. JA: ReplayTraceId を取得します。</summary>
    public string? ReplayTraceId { get; init; }

    /// <summary>EN: Gets optional execution metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries provider diagnostics.
/// EN: Documentation for public API. JA: ProviderDiagnostic の公開契約を定義します。
/// </summary>
public sealed record ProviderDiagnostic
{
    /// <summary>EN: Gets the diagnostic code. JA: Code を取得します。</summary>
    public required string Code { get; init; }

    /// <summary>EN: Gets the diagnostic message. JA: Message を取得します。</summary>
    public string? Message { get; init; }

    /// <summary>EN: Gets whether the diagnostic describes a retryable failure. JA: IsRetryable を取得します。</summary>
    public bool IsRetryable { get; init; }

    /// <summary>EN: Gets optional diagnostic metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries provider result data without throwing contract-package exceptions.
/// EN: Documentation for public API. JA: ProviderResult の公開契約を定義します。
/// </summary>
public sealed record ProviderResult<T>
{
    /// <summary>EN: Gets whether the provider operation succeeded. JA: Success を取得します。</summary>
    public bool Success { get; init; }

    /// <summary>EN: Gets the result value when successful. JA: Value を取得します。</summary>
    public T? Value { get; init; }

    /// <summary>EN: Gets a stable failure code. JA: FailureCode を取得します。</summary>
    public string? FailureCode { get; init; }

    /// <summary>EN: Gets a human-readable failure message. JA: FailureMessage を取得します。</summary>
    public string? FailureMessage { get; init; }

    /// <summary>EN: Gets provider diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<ProviderDiagnostic> Diagnostics { get; init; } = [];
}

/// <summary>
/// EN: Carries routing metadata for provider selection.
/// EN: Documentation for public API. JA: RoutingContext の公開契約を定義します。
/// </summary>
public sealed record RoutingContext
{
    /// <summary>EN: Gets the requested logical capability identifier. JA: LogicalCapabilityId を取得します。</summary>
    public required string LogicalCapabilityId { get; init; }

    /// <summary>EN: Gets a health score from 0 to 1. JA: HealthScore を取得します。</summary>
    public double HealthScore { get; init; }

    /// <summary>EN: Gets estimated execution cost. JA: EstimatedCost を取得します。</summary>
    public decimal EstimatedCost { get; init; }

    /// <summary>EN: Gets estimated latency. JA: EstimatedLatency を取得します。</summary>
    public TimeSpan EstimatedLatency { get; init; }

    /// <summary>EN: Gets optional routing metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries provider routing policy constraints.
/// EN: Documentation for public API. JA: RoutingPolicy の公開契約を定義します。
/// </summary>
public sealed record RoutingPolicy
{
    /// <summary>EN: Gets the routing policy identifier. JA: PolicyId を取得します。</summary>
    public required string PolicyId { get; init; }

    /// <summary>EN: Gets the minimum health score from 0 to 1. JA: MinimumHealthScore を取得します。</summary>
    public double MinimumHealthScore { get; init; }

    /// <summary>EN: Gets the maximum allowed estimated cost. JA: MaximumEstimatedCost を取得します。</summary>
    public decimal? MaximumEstimatedCost { get; init; }

    /// <summary>EN: Gets the maximum allowed estimated latency. JA: MaximumEstimatedLatency を取得します。</summary>
    public TimeSpan? MaximumEstimatedLatency { get; init; }

    /// <summary>EN: Gets optional routing policy metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
