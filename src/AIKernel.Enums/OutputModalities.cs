namespace AIKernel.Enums;

/// <summary>
/// Describes output modalities produced by a provider capability.
/// JA: OutputModalities の公開契約を定義します。
/// </summary>
[Flags]
public enum OutputModalities
{
    /// <summary>No output modality is declared. JA: None 値を表します。</summary>
    None = 0,

    /// <summary>Text output. JA: Text 値を表します。</summary>
    Text = 1 << 0,

    /// <summary>Image output. JA: Image 値を表します。</summary>
    Image = 1 << 1,

    /// <summary>Frame output. JA: Frame 値を表します。</summary>
    Frame = 1 << 2,

    /// <summary>Telemetry output. JA: Telemetry 値を表します。</summary>
    Telemetry = 1 << 3,

    /// <summary>Evidence output. JA: Evidence 値を表します。</summary>
    Evidence = 1 << 4,

    /// <summary>Action proposal output. JA: ActionProposal 値を表します。</summary>
    ActionProposal = 1 << 5,

    /// <summary>Virtual input output. JA: VirtualInput 値を表します。</summary>
    VirtualInput = 1 << 6
}
