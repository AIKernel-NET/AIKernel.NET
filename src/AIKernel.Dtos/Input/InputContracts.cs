using AIKernel.Enums;

namespace AIKernel.Dtos.Input;

/// <summary>
/// Carries keyboard input state.
/// JA: KeyboardInputPacket の公開契約を定義します。
/// </summary>
public sealed record KeyboardInputPacket
{
    /// <summary>Gets pressed key identifiers. JA: PressedKeys を取得します。</summary>
    public IReadOnlyList<string> PressedKeys { get; init; } = [];

    /// <summary>Gets optional keyboard metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries pointer input state.
/// JA: PointerInputPacket の公開契約を定義します。
/// </summary>
public sealed record PointerInputPacket
{
    /// <summary>Gets pointer X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>Gets pointer Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>Gets pressed pointer buttons. JA: Buttons を取得します。</summary>
    public IReadOnlyList<string> Buttons { get; init; } = [];

    /// <summary>Gets optional pointer metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries gamepad input state.
/// JA: GamepadInputPacket の公開契約を定義します。
/// </summary>
public sealed record GamepadInputPacket
{
    /// <summary>Gets pressed gamepad buttons. JA: Buttons を取得します。</summary>
    public IReadOnlyList<string> Buttons { get; init; } = [];

    /// <summary>Gets normalized axis values. JA: Axes を取得します。</summary>
    public IReadOnlyDictionary<string, double> Axes { get; init; } = new Dictionary<string, double>();

    /// <summary>Gets optional gamepad metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a governed virtual input packet.
/// JA: VirtualInputPacket の公開契約を定義します。
/// </summary>
public sealed record VirtualInputPacket
{
    /// <summary>Gets the input packet identifier. JA: InputId を取得します。</summary>
    public required string InputId { get; init; }

    /// <summary>Gets the input kind. JA: Kind を取得します。</summary>
    public VirtualInputKind Kind { get; init; } = VirtualInputKind.Unknown;

    /// <summary>Gets optional keyboard input. JA: Keyboard を取得します。</summary>
    public KeyboardInputPacket? Keyboard { get; init; }

    /// <summary>Gets optional pointer input. JA: Pointer を取得します。</summary>
    public PointerInputPacket? Pointer { get; init; }

    /// <summary>Gets optional gamepad input. JA: Gamepad を取得します。</summary>
    public GamepadInputPacket? Gamepad { get; init; }

    /// <summary>Gets optional virtual input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a virtual input result.
/// JA: VirtualInputResult の公開契約を定義します。
/// </summary>
public sealed record VirtualInputResult
{
    /// <summary>Gets whether input dispatch succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable failure code. JA: FailureCode を取得します。</summary>
    public string? FailureCode { get; init; }

    /// <summary>Gets a human-readable failure message. JA: FailureMessage を取得します。</summary>
    public string? FailureMessage { get; init; }

    /// <summary>Gets optional input result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a send-keys request.
/// JA: SendKeysRequest の公開契約を定義します。
/// </summary>
public sealed record SendKeysRequest
{
    /// <summary>Gets keys to send. JA: Keys を取得します。</summary>
    public IReadOnlyList<string> Keys { get; init; } = [];

    /// <summary>Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a text input request.
/// JA: TypeTextRequest の公開契約を定義します。
/// </summary>
public sealed record TypeTextRequest
{
    /// <summary>Gets text to type. JA: Text を取得します。</summary>
    public required string Text { get; init; }

    /// <summary>Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a pointer move request.
/// JA: PointerMoveRequest の公開契約を定義します。
/// </summary>
public sealed record PointerMoveRequest
{
    /// <summary>Gets target X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>Gets target Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a pointer click request.
/// JA: PointerClickRequest の公開契約を定義します。
/// </summary>
public sealed record PointerClickRequest
{
    /// <summary>Gets target X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>Gets target Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>Gets the button identifier. JA: Button を取得します。</summary>
    public string? Button { get; init; }

    /// <summary>Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a pointer drag request.
/// JA: PointerDragRequest の公開契約を定義します。
/// </summary>
public sealed record PointerDragRequest
{
    /// <summary>Gets start X coordinate. JA: StartX を取得します。</summary>
    public double StartX { get; init; }

    /// <summary>Gets start Y coordinate. JA: StartY を取得します。</summary>
    public double StartY { get; init; }

    /// <summary>Gets end X coordinate. JA: EndX を取得します。</summary>
    public double EndX { get; init; }

    /// <summary>Gets end Y coordinate. JA: EndY を取得します。</summary>
    public double EndY { get; init; }

    /// <summary>Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a virtual input state request.
/// JA: InputStateRequest の公開契約を定義します。
/// </summary>
public sealed record InputStateRequest
{
    /// <summary>Gets the virtual input packet. JA: Packet を取得します。</summary>
    public required VirtualInputPacket Packet { get; init; }

    /// <summary>Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
