namespace AIKernel.Enums;

/// <summary>
/// Describes output modalities produced by a provider capability.
/// </summary>
[Flags]
public enum OutputModalities
{
    /// <summary>No output modality is declared.</summary>
    None = 0,

    /// <summary>Text output.</summary>
    Text = 1 << 0,

    /// <summary>Image output.</summary>
    Image = 1 << 1,

    /// <summary>Frame output.</summary>
    Frame = 1 << 2,

    /// <summary>Telemetry output.</summary>
    Telemetry = 1 << 3,

    /// <summary>Evidence output.</summary>
    Evidence = 1 << 4,

    /// <summary>Action proposal output.</summary>
    ActionProposal = 1 << 5,

    /// <summary>Virtual input output.</summary>
    VirtualInput = 1 << 6
}
