namespace AIKernel.Enums.Perception;

/// <summary>
/// Describes HUD signal kinds.
/// JA: HudSignalKind の公開契約を定義します。
/// </summary>
public enum HudSignalKind
{
    /// <summary>Unknown HUD signal. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Health-like signal. JA: Health 値を表します。</summary>
    Health = 1,

    /// <summary>Resource-like signal. JA: Resource 値を表します。</summary>
    Resource = 2,

    /// <summary>Timer-like signal. JA: Timer 値を表します。</summary>
    Timer = 3,

    /// <summary>Status signal. JA: Status 値を表します。</summary>
    Status = 4,

    /// <summary>Warning signal. JA: Warning 値を表します。</summary>
    Warning = 5
}

/// <summary>
/// Describes signal confidence.
/// JA: SignalConfidenceKind の公開契約を定義します。
/// </summary>
public enum SignalConfidenceKind
{
    /// <summary>Unknown confidence. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Low confidence. JA: Low 値を表します。</summary>
    Low = 1,

    /// <summary>Medium confidence. JA: Medium 値を表します。</summary>
    Medium = 2,

    /// <summary>High confidence. JA: High 値を表します。</summary>
    High = 3,

    /// <summary>Confirmed confidence. JA: Confirmed 値を表します。</summary>
    Confirmed = 4
}

/// <summary>
/// Describes overlay shapes.
/// JA: OverlayShapeKind の公開契約を定義します。
/// </summary>
public enum OverlayShapeKind
{
    /// <summary>Unknown overlay shape. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Rectangle shape. JA: Rectangle 値を表します。</summary>
    Rectangle = 1,

    /// <summary>Circle shape. JA: Circle 値を表します。</summary>
    Circle = 2,

    /// <summary>Line shape. JA: Line 値を表します。</summary>
    Line = 3,

    /// <summary>Polygon shape. JA: Polygon 値を表します。</summary>
    Polygon = 4,

    /// <summary>Text shape. JA: Text 値を表します。</summary>
    Text = 5
}

/// <summary>
/// Describes overlay layers.
/// JA: OverlayLayerKind の公開契約を定義します。
/// </summary>
public enum OverlayLayerKind
{
    /// <summary>Unknown overlay layer. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Debug overlay layer. JA: Debug 値を表します。</summary>
    Debug = 1,

    /// <summary>Evidence overlay layer. JA: Evidence 値を表します。</summary>
    Evidence = 2,

    /// <summary>Perception overlay layer. JA: Perception 値を表します。</summary>
    Perception = 3,

    /// <summary>Operator overlay layer. JA: Operator 値を表します。</summary>
    Operator = 4
}
