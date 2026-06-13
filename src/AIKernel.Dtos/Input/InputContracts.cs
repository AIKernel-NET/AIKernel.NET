using AIKernel.Enums;

namespace AIKernel.Dtos.Input;

/// <summary>
/// Carries keyboard input state.
/// </summary>
public sealed record KeyboardInputPacket
{
    /// <summary>Gets pressed key identifiers.</summary>
    public IReadOnlyList<string> PressedKeys { get; init; } = [];

    /// <summary>Gets optional keyboard metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries pointer input state.
/// </summary>
public sealed record PointerInputPacket
{
    /// <summary>Gets pointer X coordinate.</summary>
    public double X { get; init; }

    /// <summary>Gets pointer Y coordinate.</summary>
    public double Y { get; init; }

    /// <summary>Gets pressed pointer buttons.</summary>
    public IReadOnlyList<string> Buttons { get; init; } = [];

    /// <summary>Gets optional pointer metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries gamepad input state.
/// </summary>
public sealed record GamepadInputPacket
{
    /// <summary>Gets pressed gamepad buttons.</summary>
    public IReadOnlyList<string> Buttons { get; init; } = [];

    /// <summary>Gets normalized axis values.</summary>
    public IReadOnlyDictionary<string, double> Axes { get; init; } = new Dictionary<string, double>();

    /// <summary>Gets optional gamepad metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a governed virtual input packet.
/// </summary>
public sealed record VirtualInputPacket
{
    /// <summary>Gets the input packet identifier.</summary>
    public required string InputId { get; init; }

    /// <summary>Gets the input kind.</summary>
    public VirtualInputKind Kind { get; init; } = VirtualInputKind.Unknown;

    /// <summary>Gets optional keyboard input.</summary>
    public KeyboardInputPacket? Keyboard { get; init; }

    /// <summary>Gets optional pointer input.</summary>
    public PointerInputPacket? Pointer { get; init; }

    /// <summary>Gets optional gamepad input.</summary>
    public GamepadInputPacket? Gamepad { get; init; }

    /// <summary>Gets optional virtual input metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a virtual input result.
/// </summary>
public sealed record VirtualInputResult
{
    /// <summary>Gets whether input dispatch succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable failure code.</summary>
    public string? FailureCode { get; init; }

    /// <summary>Gets a human-readable failure message.</summary>
    public string? FailureMessage { get; init; }

    /// <summary>Gets optional input result metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a send-keys request.
/// </summary>
public sealed record SendKeysRequest
{
    /// <summary>Gets keys to send.</summary>
    public IReadOnlyList<string> Keys { get; init; } = [];

    /// <summary>Gets optional input metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a text input request.
/// </summary>
public sealed record TypeTextRequest
{
    /// <summary>Gets text to type.</summary>
    public required string Text { get; init; }

    /// <summary>Gets optional input metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a pointer move request.
/// </summary>
public sealed record PointerMoveRequest
{
    /// <summary>Gets target X coordinate.</summary>
    public double X { get; init; }

    /// <summary>Gets target Y coordinate.</summary>
    public double Y { get; init; }

    /// <summary>Gets optional input metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a pointer click request.
/// </summary>
public sealed record PointerClickRequest
{
    /// <summary>Gets target X coordinate.</summary>
    public double X { get; init; }

    /// <summary>Gets target Y coordinate.</summary>
    public double Y { get; init; }

    /// <summary>Gets the button identifier.</summary>
    public string? Button { get; init; }

    /// <summary>Gets optional input metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a pointer drag request.
/// </summary>
public sealed record PointerDragRequest
{
    /// <summary>Gets start X coordinate.</summary>
    public double StartX { get; init; }

    /// <summary>Gets start Y coordinate.</summary>
    public double StartY { get; init; }

    /// <summary>Gets end X coordinate.</summary>
    public double EndX { get; init; }

    /// <summary>Gets end Y coordinate.</summary>
    public double EndY { get; init; }

    /// <summary>Gets optional input metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a virtual input state request.
/// </summary>
public sealed record InputStateRequest
{
    /// <summary>Gets the virtual input packet.</summary>
    public required VirtualInputPacket Packet { get; init; }

    /// <summary>Gets optional input metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
