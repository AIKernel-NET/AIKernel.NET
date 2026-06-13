namespace AIKernel.Enums;

/// <summary>
/// Classifies an external runtime asset without binding to a concrete technology.
/// JA: RuntimeAssetKind の公開契約を定義します。
/// </summary>
public enum RuntimeAssetKind
{
    /// <summary>The asset kind is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Runtime executable or module artifact. JA: RuntimeArtifact 値を表します。</summary>
    RuntimeArtifact = 1,

    /// <summary>Model artifact. JA: ModelArtifact 値を表します。</summary>
    ModelArtifact = 2,

    /// <summary>Hosted data artifact. JA: HostedAsset 値を表します。</summary>
    HostedAsset = 3,

    /// <summary>Protected user- or license-gated asset. JA: ProtectedAsset 値を表します。</summary>
    ProtectedAsset = 4,

    /// <summary>Profile or tuning artifact. JA: ProfileArtifact 値を表します。</summary>
    ProfileArtifact = 5
}
