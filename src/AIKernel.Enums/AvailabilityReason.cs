namespace AIKernel.Enums;

/// <summary>
/// Explains why a provider capability is or is not available.
/// </summary>
public enum AvailabilityReason
{
    /// <summary>No reason was supplied.</summary>
    Unknown = 0,

    /// <summary>The capability is available.</summary>
    Available = 1,

    /// <summary>The provider is disabled by policy.</summary>
    PolicyDisabled = 2,

    /// <summary>Required consent has not been granted.</summary>
    ConsentRequired = 3,

    /// <summary>A required runtime artifact is unavailable.</summary>
    RuntimeArtifactUnavailable = 4,

    /// <summary>A required model artifact is unavailable.</summary>
    ModelArtifactUnavailable = 5,

    /// <summary>A required protected asset is unavailable.</summary>
    ProtectedAssetUnavailable = 6,

    /// <summary>A frame surface cannot be acquired.</summary>
    FrameSurfaceUnavailable = 7,

    /// <summary>A frame source cannot be acquired.</summary>
    FrameSourceUnavailable = 8,

    /// <summary>The provider health state is insufficient for routing.</summary>
    HealthBelowThreshold = 9,

    /// <summary>The estimated cost exceeds policy.</summary>
    CostAboveThreshold = 10,

    /// <summary>The estimated latency exceeds policy.</summary>
    LatencyAboveThreshold = 11
}
