namespace AIKernel.Enums;

/// <summary>
/// EN: Classifies a virtual input packet.
/// EN: Documentation for public API. JA: VirtualInputKind の公開契約を定義します。
/// </summary>
public enum VirtualInputKind
{
    /// <summary>EN: The input kind is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Keyboard input. JA: Keyboard 値を表します。</summary>
    Keyboard = 1,

    /// <summary>EN: Pointer input. JA: Pointer 値を表します。</summary>
    Pointer = 2,

    /// <summary>EN: Gamepad input. JA: Gamepad 値を表します。</summary>
    Gamepad = 3,

    /// <summary>EN: Composite virtual action input. JA: Composite 値を表します。</summary>
    Composite = 4
}
