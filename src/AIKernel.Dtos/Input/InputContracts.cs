using AIKernel.Enums;

namespace AIKernel.Dtos.Input;

/// <summary>
/// EN: Carries keyboard input state.
/// [EN] Documents this public package API member. [JA] KeyboardInputPacket の公開契約を定義します。
/// </summary>
public sealed record KeyboardInputPacket
{
    /// <summary>EN: Gets pressed key identifiers. JA: PressedKeys を取得します。</summary>
    public IReadOnlyList<string> PressedKeys { get; init; } = [];

    /// <summary>EN: Gets optional keyboard metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries pointer input state.
/// [EN] Documents this public package API member. [JA] PointerInputPacket の公開契約を定義します。
/// </summary>
public sealed record PointerInputPacket
{
    /// <summary>EN: Gets pointer X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>EN: Gets pointer Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>EN: Gets pressed pointer buttons. JA: Buttons を取得します。</summary>
    public IReadOnlyList<string> Buttons { get; init; } = [];

    /// <summary>EN: Gets optional pointer metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries gamepad input state.
/// [EN] Documents this public package API member. [JA] GamepadInputPacket の公開契約を定義します。
/// </summary>
public sealed record GamepadInputPacket
{
    /// <summary>EN: Gets pressed gamepad buttons. JA: Buttons を取得します。</summary>
    public IReadOnlyList<string> Buttons { get; init; } = [];

    /// <summary>EN: Gets normalized axis values. JA: Axes を取得します。</summary>
    public IReadOnlyDictionary<string, double> Axes { get; init; } = new Dictionary<string, double>();

    /// <summary>EN: Gets optional gamepad metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a governed virtual input packet.
/// [EN] Documents this public package API member. [JA] VirtualInputPacket の公開契約を定義します。
/// </summary>
public sealed record VirtualInputPacket
{
    /// <summary>EN: Gets the input packet identifier. JA: InputId を取得します。</summary>
    public required string InputId { get; init; }

    /// <summary>EN: Gets the input kind. JA: Kind を取得します。</summary>
    public VirtualInputKind Kind { get; init; } = VirtualInputKind.Unknown;

    /// <summary>EN: Gets optional keyboard input. JA: Keyboard を取得します。</summary>
    public KeyboardInputPacket? Keyboard { get; init; }

    /// <summary>EN: Gets optional pointer input. JA: Pointer を取得します。</summary>
    public PointerInputPacket? Pointer { get; init; }

    /// <summary>EN: Gets optional gamepad input. JA: Gamepad を取得します。</summary>
    public GamepadInputPacket? Gamepad { get; init; }

    /// <summary>EN: Gets optional virtual input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a virtual input result.
/// [EN] Documents this public package API member. [JA] VirtualInputResult の公開契約を定義します。
/// </summary>
public sealed record VirtualInputResult
{
    /// <summary>EN: Gets whether input dispatch succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable failure code. JA: FailureCode を取得します。</summary>
    public string? FailureCode { get; init; }

    /// <summary>EN: Gets a human-readable failure message. JA: FailureMessage を取得します。</summary>
    public string? FailureMessage { get; init; }

    /// <summary>EN: Gets optional input result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a send-keys request.
/// [EN] Documents this public package API member. [JA] SendKeysRequest の公開契約を定義します。
/// </summary>
public sealed record SendKeysRequest
{
    /// <summary>EN: Gets keys to send. JA: Keys を取得します。</summary>
    public IReadOnlyList<string> Keys { get; init; } = [];

    /// <summary>EN: Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a text input request.
/// [EN] Documents this public package API member. [JA] TypeTextRequest の公開契約を定義します。
/// </summary>
public sealed record TypeTextRequest
{
    /// <summary>EN: Gets text to type. JA: Text を取得します。</summary>
    public required string Text { get; init; }

    /// <summary>EN: Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a pointer move request.
/// [EN] Documents this public package API member. [JA] PointerMoveRequest の公開契約を定義します。
/// </summary>
public sealed record PointerMoveRequest
{
    /// <summary>EN: Gets target X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>EN: Gets target Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>EN: Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a pointer click request.
/// [EN] Documents this public package API member. [JA] PointerClickRequest の公開契約を定義します。
/// </summary>
public sealed record PointerClickRequest
{
    /// <summary>EN: Gets target X coordinate. JA: X を取得します。</summary>
    public double X { get; init; }

    /// <summary>EN: Gets target Y coordinate. JA: Y を取得します。</summary>
    public double Y { get; init; }

    /// <summary>EN: Gets the button identifier. JA: Button を取得します。</summary>
    public string? Button { get; init; }

    /// <summary>EN: Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a pointer drag request.
/// [EN] Documents this public package API member. [JA] PointerDragRequest の公開契約を定義します。
/// </summary>
public sealed record PointerDragRequest
{
    /// <summary>EN: Gets start X coordinate. JA: StartX を取得します。</summary>
    public double StartX { get; init; }

    /// <summary>EN: Gets start Y coordinate. JA: StartY を取得します。</summary>
    public double StartY { get; init; }

    /// <summary>EN: Gets end X coordinate. JA: EndX を取得します。</summary>
    public double EndX { get; init; }

    /// <summary>EN: Gets end Y coordinate. JA: EndY を取得します。</summary>
    public double EndY { get; init; }

    /// <summary>EN: Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a virtual input state request.
/// [EN] Documents this public package API member. [JA] InputStateRequest の公開契約を定義します。
/// </summary>
public sealed record InputStateRequest
{
    /// <summary>EN: Gets the virtual input packet. JA: Packet を取得します。</summary>
    public required VirtualInputPacket Packet { get; init; }

    /// <summary>EN: Gets optional input metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
