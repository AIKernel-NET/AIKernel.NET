namespace AIKernel.Enums;

/// <summary>
/// Classifies a virtual input packet.
/// JA: VirtualInputKind の公開契約を定義します。
/// </summary>
public enum VirtualInputKind
{
    /// <summary>The input kind is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Keyboard input. JA: Keyboard 値を表します。</summary>
    Keyboard = 1,

    /// <summary>Pointer input. JA: Pointer 値を表します。</summary>
    Pointer = 2,

    /// <summary>Gamepad input. JA: Gamepad 値を表します。</summary>
    Gamepad = 3,

    /// <summary>Composite virtual action input. JA: Composite 値を表します。</summary>
    Composite = 4
}
