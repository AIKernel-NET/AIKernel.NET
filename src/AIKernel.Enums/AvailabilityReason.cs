namespace AIKernel.Enums;

/// <summary>
/// EN: Explains why a provider capability is or is not available.
/// EN: Documentation for public API. JA: AvailabilityReason の公開契約を定義します。
/// </summary>
public enum AvailabilityReason
{
    /// <summary>EN: No reason was supplied. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: The capability is available. JA: Available 値を表します。</summary>
    Available = 1,

    /// <summary>EN: The provider is disabled by policy. JA: PolicyDisabled 値を表します。</summary>
    PolicyDisabled = 2,

    /// <summary>EN: Required consent has not been granted. JA: ConsentRequired 値を表します。</summary>
    ConsentRequired = 3,

    /// <summary>EN: A required runtime artifact is unavailable. JA: RuntimeArtifactUnavailable 値を表します。</summary>
    RuntimeArtifactUnavailable = 4,

    /// <summary>EN: A required model artifact is unavailable. JA: ModelArtifactUnavailable 値を表します。</summary>
    ModelArtifactUnavailable = 5,

    /// <summary>EN: A required protected asset is unavailable. JA: ProtectedAssetUnavailable 値を表します。</summary>
    ProtectedAssetUnavailable = 6,

    /// <summary>EN: A frame surface cannot be acquired. JA: FrameSurfaceUnavailable 値を表します。</summary>
    FrameSurfaceUnavailable = 7,

    /// <summary>EN: A frame source cannot be acquired. JA: FrameSourceUnavailable 値を表します。</summary>
    FrameSourceUnavailable = 8,

    /// <summary>EN: The provider health state is insufficient for routing. JA: HealthBelowThreshold 値を表します。</summary>
    HealthBelowThreshold = 9,

    /// <summary>EN: The estimated cost exceeds policy. JA: CostAboveThreshold 値を表します。</summary>
    CostAboveThreshold = 10,

    /// <summary>EN: The estimated latency exceeds policy. JA: LatencyAboveThreshold 値を表します。</summary>
    LatencyAboveThreshold = 11
}
