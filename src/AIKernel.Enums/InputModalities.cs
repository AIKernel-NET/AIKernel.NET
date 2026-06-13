namespace AIKernel.Enums;

/// <summary>
/// Describes input modalities accepted by a provider capability.
/// </summary>
[Flags]
public enum InputModalities
{
    /// <summary>No input modality is declared.</summary>
    None = 0,

    /// <summary>Text input.</summary>
    Text = 1 << 0,

    /// <summary>Image input.</summary>
    Image = 1 << 1,

    /// <summary>Audio input.</summary>
    Audio = 1 << 2,

    /// <summary>Video or frame input.</summary>
    Frame = 1 << 3,

    /// <summary>Control-plane input.</summary>
    Control = 1 << 4,

    /// <summary>Telemetry input.</summary>
    Telemetry = 1 << 5,

    /// <summary>Virtual input state.</summary>
    VirtualInput = 1 << 6
}
