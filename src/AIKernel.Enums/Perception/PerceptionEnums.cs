namespace AIKernel.Enums.Perception;

/// <summary>
/// EN: Describes HUD signal kinds.
/// [EN] Documents this public package API member. [JA] HudSignalKind の公開契約を定義します。
/// </summary>
public enum HudSignalKind
{
    /// <summary>EN: Unknown HUD signal. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Health-like signal. JA: Health 値を表します。</summary>
    Health = 1,

    /// <summary>EN: Resource-like signal. JA: Resource 値を表します。</summary>
    Resource = 2,

    /// <summary>EN: Timer-like signal. JA: Timer 値を表します。</summary>
    Timer = 3,

    /// <summary>EN: Status signal. JA: Status 値を表します。</summary>
    Status = 4,

    /// <summary>EN: Warning signal. JA: Warning 値を表します。</summary>
    Warning = 5
}

/// <summary>
/// EN: Describes signal confidence.
/// [EN] Documents this public package API member. [JA] SignalConfidenceKind の公開契約を定義します。
/// </summary>
public enum SignalConfidenceKind
{
    /// <summary>EN: Unknown confidence. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Low confidence. JA: Low 値を表します。</summary>
    Low = 1,

    /// <summary>EN: Medium confidence. JA: Medium 値を表します。</summary>
    Medium = 2,

    /// <summary>EN: High confidence. JA: High 値を表します。</summary>
    High = 3,

    /// <summary>EN: Confirmed confidence. JA: Confirmed 値を表します。</summary>
    Confirmed = 4
}

/// <summary>
/// EN: Describes overlay shapes.
/// [EN] Documents this public package API member. [JA] OverlayShapeKind の公開契約を定義します。
/// </summary>
public enum OverlayShapeKind
{
    /// <summary>EN: Unknown overlay shape. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Rectangle shape. JA: Rectangle 値を表します。</summary>
    Rectangle = 1,

    /// <summary>EN: Circle shape. JA: Circle 値を表します。</summary>
    Circle = 2,

    /// <summary>EN: Line shape. JA: Line 値を表します。</summary>
    Line = 3,

    /// <summary>EN: Polygon shape. JA: Polygon 値を表します。</summary>
    Polygon = 4,

    /// <summary>EN: Text shape. JA: Text 値を表します。</summary>
    Text = 5
}

/// <summary>
/// EN: Describes overlay layers.
/// [EN] Documents this public package API member. [JA] OverlayLayerKind の公開契約を定義します。
/// </summary>
public enum OverlayLayerKind
{
    /// <summary>EN: Unknown overlay layer. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Debug overlay layer. JA: Debug 値を表します。</summary>
    Debug = 1,

    /// <summary>EN: Evidence overlay layer. JA: Evidence 値を表します。</summary>
    Evidence = 2,

    /// <summary>EN: Perception overlay layer. JA: Perception 値を表します。</summary>
    Perception = 3,

    /// <summary>EN: Operator overlay layer. JA: Operator 値を表します。</summary>
    Operator = 4
}
