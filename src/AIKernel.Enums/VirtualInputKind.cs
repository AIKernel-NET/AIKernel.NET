namespace AIKernel.Enums;

/// <summary>
/// Classifies a virtual input packet.
/// </summary>
public enum VirtualInputKind
{
    /// <summary>The input kind is unknown.</summary>
    Unknown = 0,

    /// <summary>Keyboard input.</summary>
    Keyboard = 1,

    /// <summary>Pointer input.</summary>
    Pointer = 2,

    /// <summary>Gamepad input.</summary>
    Gamepad = 3,

    /// <summary>Composite virtual action input.</summary>
    Composite = 4
}
