namespace AIKernel.Enums;

/// <summary>
/// Describes input modalities accepted by a provider capability.
/// JA: InputModalities の公開契約を定義します。
/// </summary>
[Flags]
public enum InputModalities
{
    /// <summary>No input modality is declared. JA: None 値を表します。</summary>
    None = 0,

    /// <summary>Text input. JA: Text 値を表します。</summary>
    Text = 1 << 0,

    /// <summary>Image input. JA: Image 値を表します。</summary>
    Image = 1 << 1,

    /// <summary>Audio input. JA: Audio 値を表します。</summary>
    Audio = 1 << 2,

    /// <summary>Video or frame input. JA: Frame 値を表します。</summary>
    Frame = 1 << 3,

    /// <summary>Control-plane input. JA: Control 値を表します。</summary>
    Control = 1 << 4,

    /// <summary>Telemetry input. JA: Telemetry 値を表します。</summary>
    Telemetry = 1 << 5,

    /// <summary>Virtual input state. JA: VirtualInput 値を表します。</summary>
    VirtualInput = 1 << 6
}
