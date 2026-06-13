namespace AIKernel.Enums;

/// <summary>
/// Explains provider capability availability for capability routing.
/// </summary>
public enum ProviderAvailabilityReason
{
    /// <summary>No availability reason is declared.</summary>
    None = 0,

    /// <summary>The capability is available.</summary>
    Available = 1,

    /// <summary>Preparation is required before use.</summary>
    PreparationRequired = 2,

    /// <summary>Explicit consent is required before use.</summary>
    ConsentRequired = 3,

    /// <summary>Required permission is denied.</summary>
    PermissionDenied = 4,

    /// <summary>The provider is disabled by policy.</summary>
    PolicyDisabled = 5,

    /// <summary>A required host capability is missing.</summary>
    HostCapabilityMissing = 6,

    /// <summary>A required host package is missing.</summary>
    HostPackageRequirementMissing = 7,

    /// <summary>A required provider access token is missing.</summary>
    ProviderAccessTokenMissing = 8,

    /// <summary>A required runtime artifact is unavailable.</summary>
    RuntimeArtifactUnavailable = 9,

    /// <summary>A required model artifact is unavailable.</summary>
    ModelArtifactUnavailable = 10,

    /// <summary>A protected asset is unavailable.</summary>
    ProtectedAssetUnavailable = 11,

    /// <summary>A frame surface is unavailable.</summary>
    FrameSurfaceUnavailable = 12,

    /// <summary>A frame source is unavailable.</summary>
    FrameSourceUnavailable = 13,

    /// <summary>The provider health score is below threshold.</summary>
    HealthBelowThreshold = 14,

    /// <summary>The estimated cost exceeds policy.</summary>
    CostAboveThreshold = 15,

    /// <summary>The estimated latency exceeds policy.</summary>
    LatencyAboveThreshold = 16
}
