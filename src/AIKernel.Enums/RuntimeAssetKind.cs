namespace AIKernel.Enums;

/// <summary>
/// EN: Classifies an external runtime asset without binding to a concrete technology.
/// EN: Documentation for public API. JA: RuntimeAssetKind の公開契約を定義します。
/// </summary>
public enum RuntimeAssetKind
{
    /// <summary>EN: The asset kind is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Runtime executable or module artifact. JA: RuntimeArtifact 値を表します。</summary>
    RuntimeArtifact = 1,

    /// <summary>EN: Model artifact. JA: ModelArtifact 値を表します。</summary>
    ModelArtifact = 2,

    /// <summary>EN: Hosted data artifact. JA: HostedAsset 値を表します。</summary>
    HostedAsset = 3,

    /// <summary>EN: Protected user- or license-gated asset. JA: ProtectedAsset 値を表します。</summary>
    ProtectedAsset = 4,

    /// <summary>EN: Profile or tuning artifact. JA: ProfileArtifact 値を表します。</summary>
    ProfileArtifact = 5
}
