namespace AIKernel.Enums;

/// <summary>
/// Explains provider capability availability for capability routing.
/// JA: ProviderAvailabilityReason の公開契約を定義します。
/// </summary>
public enum ProviderAvailabilityReason
{
    /// <summary>No availability reason is declared. JA: None 値を表します。</summary>
    None = 0,

    /// <summary>The capability is available. JA: Available 値を表します。</summary>
    Available = 1,

    /// <summary>Preparation is required before use. JA: PreparationRequired 値を表します。</summary>
    PreparationRequired = 2,

    /// <summary>Explicit consent is required before use. JA: ConsentRequired 値を表します。</summary>
    ConsentRequired = 3,

    /// <summary>Required permission is denied. JA: PermissionDenied 値を表します。</summary>
    PermissionDenied = 4,

    /// <summary>The provider is disabled by policy. JA: PolicyDisabled 値を表します。</summary>
    PolicyDisabled = 5,

    /// <summary>A required host capability is missing. JA: HostCapabilityMissing 値を表します。</summary>
    HostCapabilityMissing = 6,

    /// <summary>A required host package is missing. JA: HostPackageRequirementMissing 値を表します。</summary>
    HostPackageRequirementMissing = 7,

    /// <summary>A required provider access token is missing. JA: ProviderAccessTokenMissing 値を表します。</summary>
    ProviderAccessTokenMissing = 8,

    /// <summary>A required runtime artifact is unavailable. JA: RuntimeArtifactUnavailable 値を表します。</summary>
    RuntimeArtifactUnavailable = 9,

    /// <summary>A required model artifact is unavailable. JA: ModelArtifactUnavailable 値を表します。</summary>
    ModelArtifactUnavailable = 10,

    /// <summary>A protected asset is unavailable. JA: ProtectedAssetUnavailable 値を表します。</summary>
    ProtectedAssetUnavailable = 11,

    /// <summary>A frame surface is unavailable. JA: FrameSurfaceUnavailable 値を表します。</summary>
    FrameSurfaceUnavailable = 12,

    /// <summary>A frame source is unavailable. JA: FrameSourceUnavailable 値を表します。</summary>
    FrameSourceUnavailable = 13,

    /// <summary>The provider health score is below threshold. JA: HealthBelowThreshold 値を表します。</summary>
    HealthBelowThreshold = 14,

    /// <summary>The estimated cost exceeds policy. JA: CostAboveThreshold 値を表します。</summary>
    CostAboveThreshold = 15,

    /// <summary>The estimated latency exceeds policy. JA: LatencyAboveThreshold 値を表します。</summary>
    LatencyAboveThreshold = 16
}
