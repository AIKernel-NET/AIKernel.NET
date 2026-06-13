namespace AIKernel.Enums;

/// <summary>
/// Classifies an external runtime asset without binding to a concrete technology.
/// </summary>
public enum RuntimeAssetKind
{
    /// <summary>The asset kind is unknown.</summary>
    Unknown = 0,

    /// <summary>Runtime executable or module artifact.</summary>
    RuntimeArtifact = 1,

    /// <summary>Model artifact.</summary>
    ModelArtifact = 2,

    /// <summary>Hosted data artifact.</summary>
    HostedAsset = 3,

    /// <summary>Protected user- or license-gated asset.</summary>
    ProtectedAsset = 4,

    /// <summary>Profile or tuning artifact.</summary>
    ProfileArtifact = 5
}
