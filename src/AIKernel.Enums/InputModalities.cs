namespace AIKernel.Enums;

/// <summary>
/// EN: Describes input modalities accepted by a provider capability.
/// [EN] Documents this public package API member. [JA] InputModalities の公開契約を定義します。
/// </summary>
[Flags]
public enum InputModalities
{
    /// <summary>EN: No input modality is declared. JA: None 値を表します。</summary>
    None = 0,

    /// <summary>EN: Text input. JA: Text 値を表します。</summary>
    Text = 1 << 0,

    /// <summary>EN: Image input. JA: Image 値を表します。</summary>
    Image = 1 << 1,

    /// <summary>EN: Audio input. JA: Audio 値を表します。</summary>
    Audio = 1 << 2,

    /// <summary>EN: Video or frame input. JA: Frame 値を表します。</summary>
    Frame = 1 << 3,

    /// <summary>EN: Control-plane input. JA: Control 値を表します。</summary>
    Control = 1 << 4,

    /// <summary>EN: Telemetry input. JA: Telemetry 値を表します。</summary>
    Telemetry = 1 << 5,

    /// <summary>EN: Virtual input state. JA: VirtualInput 値を表します。</summary>
    VirtualInput = 1 << 6
}
