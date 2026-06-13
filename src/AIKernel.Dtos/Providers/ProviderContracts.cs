using AIKernel.Dtos.Contracts;
using AIKernel.Enums;

namespace AIKernel.Dtos.Providers;

/// <summary>
/// Describes a logical provider capability for package-boundary routing.
/// </summary>
public sealed record ProviderCapability
{
    /// <summary>Gets the logical capability identifier.</summary>
    public required string LogicalCapabilityId { get; init; }

    /// <summary>Gets the provider-specific capability identifier.</summary>
    public required string ProviderCapabilityId { get; init; }

    /// <summary>Gets the capability flags.</summary>
    public ProviderCapabilityFlags Flags { get; init; } = ProviderCapabilityFlags.None;

    /// <summary>Gets the provider kind that owns the capability.</summary>
    public ProviderKind Kind { get; init; } = ProviderKind.Unknown;

    /// <summary>Gets the contract interface identifier.</summary>
    public string? InterfaceId { get; init; }

    /// <summary>Gets input modalities accepted by this capability.</summary>
    public InputModalities InputModalities { get; init; } = InputModalities.None;

    /// <summary>Gets output modalities produced by this capability.</summary>
    public OutputModalities OutputModalities { get; init; } = OutputModalities.None;

    /// <summary>Gets the risk level for this capability.</summary>
    public ProviderRiskLevel RiskLevel { get; init; } = ProviderRiskLevel.Unknown;

    /// <summary>Gets capability availability details.</summary>
    public CapabilityAvailability Availability { get; init; } = new();

    /// <summary>Gets whether replay metadata is supported.</summary>
    public bool SupportsReplay { get; init; }

    /// <summary>Gets whether inline safety policy checks are supported.</summary>
    public bool SupportsInlineSafetyPolicy { get; init; }

    /// <summary>Gets whether this capability can perform privileged action.</summary>
    public bool PrivilegedAction { get; init; }

    /// <summary>Gets optional capability metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes provider capability availability.
/// </summary>
public sealed record CapabilityAvailability
{
    /// <summary>Gets whether the capability is available.</summary>
    public bool IsAvailable { get; init; }

    /// <summary>Gets the availability reason.</summary>
    public ProviderAvailabilityReason Reason { get; init; } = ProviderAvailabilityReason.None;

    /// <summary>Gets an optional quality level from 0 to 1.</summary>
    public double? QualityLevel { get; init; }

    /// <summary>Gets optional availability metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a capability query for provider probing and routing.
/// </summary>
public sealed record CapabilityQuery
{
    /// <summary>Gets the requested logical capability identifier.</summary>
    public required string LogicalCapabilityId { get; init; }

    /// <summary>Gets required input modalities.</summary>
    public InputModalities RequiredInputs { get; init; } = InputModalities.None;

    /// <summary>Gets required output modalities.</summary>
    public OutputModalities RequiredOutputs { get; init; } = OutputModalities.None;

    /// <summary>Gets the maximum permitted risk level.</summary>
    public ProviderRiskLevel MaximumRiskLevel { get; init; } = ProviderRiskLevel.Privileged;

    /// <summary>Gets whether privileged action is allowed by the caller.</summary>
    public bool AllowPrivilegedAction { get; init; }

    /// <summary>Gets optional query metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries preparation consent for hosted runtime, model, and protected assets.
/// </summary>
public sealed record PreparationConsent
{
    /// <summary>Gets whether terms were accepted.</summary>
    public bool AcceptedTerms { get; init; }

    /// <summary>Gets whether network download is allowed.</summary>
    public bool AllowNetworkDownload { get; init; }

    /// <summary>Gets whether model acquisition is allowed.</summary>
    public bool AllowModelAcquisition { get; init; }

    /// <summary>Gets whether runtime artifact loading is allowed.</summary>
    public bool AllowRuntimeArtifactLoad { get; init; }

    /// <summary>Gets whether protected asset loading is allowed.</summary>
    public bool AllowProtectedAssetLoad { get; init; }

    /// <summary>Gets a consent trace identifier.</summary>
    public string? ConsentTraceId { get; init; }

    /// <summary>Gets the consent grant timestamp supplied by the caller.</summary>
    public DateTimeOffset? GrantedAt { get; init; }

    /// <summary>Gets optional consent metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();

    /// <summary>Gets an empty consent value.</summary>
    public static PreparationConsent None { get; } = new();
}

/// <summary>
/// Carries preparation policy thresholds.
/// </summary>
public sealed record PreparationPolicy
{
    /// <summary>Gets whether fail-closed consent is required.</summary>
    public bool RequireExplicitConsent { get; init; } = true;

    /// <summary>Gets whether network access is allowed by policy.</summary>
    public bool AllowNetworkAccess { get; init; }

    /// <summary>Gets the maximum allowed estimated cost.</summary>
    public decimal? MaximumEstimatedCost { get; init; }

    /// <summary>Gets the maximum allowed latency in milliseconds.</summary>
    public double? MaximumLatencyMilliseconds { get; init; }

    /// <summary>Gets optional policy metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();

    /// <summary>Gets the default preparation policy.</summary>
    public static PreparationPolicy Default { get; } = new();
}

/// <summary>
/// Carries provider preparation context.
/// </summary>
public sealed record ProviderPreparationContext
{
    /// <summary>Gets the preparation identifier.</summary>
    public required string PreparationId { get; init; }

    /// <summary>Gets the requested logical capability identifier.</summary>
    public string? LogicalCapabilityId { get; init; }

    /// <summary>Gets the preparation policy.</summary>
    public PreparationPolicy Policy { get; init; } = PreparationPolicy.Default;

    /// <summary>Gets the preparation consent.</summary>
    public PreparationConsent Consent { get; init; } = PreparationConsent.None;

    /// <summary>Gets optional preparation metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries provider execution context.
/// </summary>
public sealed record ProviderExecutionContext
{
    /// <summary>Gets the execution identifier.</summary>
    public required string ExecutionId { get; init; }

    /// <summary>Gets the runtime control mode.</summary>
    public RuntimeControlMode ControlMode { get; init; } = RuntimeControlMode.Normal;

    /// <summary>Gets the governance decision associated with this execution.</summary>
    public GovernanceDecision? GovernanceDecision { get; init; }

    /// <summary>Gets the replay trace identifier.</summary>
    public string? ReplayTraceId { get; init; }

    /// <summary>Gets optional execution metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries provider diagnostics.
/// </summary>
public sealed record ProviderDiagnostic
{
    /// <summary>Gets the diagnostic code.</summary>
    public required string Code { get; init; }

    /// <summary>Gets the diagnostic message.</summary>
    public string? Message { get; init; }

    /// <summary>Gets whether the diagnostic describes a retryable failure.</summary>
    public bool IsRetryable { get; init; }

    /// <summary>Gets optional diagnostic metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries provider result data without throwing contract-package exceptions.
/// </summary>
public sealed record ProviderResult<T>
{
    /// <summary>Gets whether the provider operation succeeded.</summary>
    public bool Success { get; init; }

    /// <summary>Gets the result value when successful.</summary>
    public T? Value { get; init; }

    /// <summary>Gets a stable failure code.</summary>
    public string? FailureCode { get; init; }

    /// <summary>Gets a human-readable failure message.</summary>
    public string? FailureMessage { get; init; }

    /// <summary>Gets provider diagnostics.</summary>
    public IReadOnlyList<ProviderDiagnostic> Diagnostics { get; init; } = [];
}

/// <summary>
/// Carries routing metadata for provider selection.
/// </summary>
public sealed record RoutingContext
{
    /// <summary>Gets the requested logical capability identifier.</summary>
    public required string LogicalCapabilityId { get; init; }

    /// <summary>Gets a health score from 0 to 1.</summary>
    public double HealthScore { get; init; }

    /// <summary>Gets estimated execution cost.</summary>
    public decimal EstimatedCost { get; init; }

    /// <summary>Gets estimated latency.</summary>
    public TimeSpan EstimatedLatency { get; init; }

    /// <summary>Gets optional routing metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries provider routing policy constraints.
/// </summary>
public sealed record RoutingPolicy
{
    /// <summary>Gets the routing policy identifier.</summary>
    public required string PolicyId { get; init; }

    /// <summary>Gets the minimum health score from 0 to 1.</summary>
    public double MinimumHealthScore { get; init; }

    /// <summary>Gets the maximum allowed estimated cost.</summary>
    public decimal? MaximumEstimatedCost { get; init; }

    /// <summary>Gets the maximum allowed estimated latency.</summary>
    public TimeSpan? MaximumEstimatedLatency { get; init; }

    /// <summary>Gets optional routing policy metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
