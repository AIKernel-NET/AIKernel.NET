namespace AIKernel.Enums.Replay;

/// <summary>
/// Describes replay event kinds.
/// JA: ReplayEventKind の公開契約を定義します。
/// </summary>
public enum ReplayEventKind
{
    /// <summary>Unknown replay event kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Runtime event. JA: Runtime 値を表します。</summary>
    Runtime = 1,

    /// <summary>Input event. JA: Input 値を表します。</summary>
    Input = 2,

    /// <summary>Observation event. JA: Observation 値を表します。</summary>
    Observation = 3,

    /// <summary>Decision event. JA: Decision 値を表します。</summary>
    Decision = 4,

    /// <summary>Diagnostic event. JA: Diagnostic 値を表します。</summary>
    Diagnostic = 5,

    /// <summary>Evidence event. JA: Evidence 値を表します。</summary>
    Evidence = 6
}

/// <summary>
/// Describes replay sealing state.
/// JA: ReplaySealState の公開契約を定義します。
/// </summary>
public enum ReplaySealState
{
    /// <summary>Unknown seal state. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>The timeline is open. JA: Open 値を表します。</summary>
    Open = 1,

    /// <summary>The timeline is sealing. JA: Sealing 値を表します。</summary>
    Sealing = 2,

    /// <summary>The timeline is sealed. JA: Sealed 値を表します。</summary>
    Sealed = 3,

    /// <summary>Sealing failed. JA: Failed 値を表します。</summary>
    Failed = 4
}

/// <summary>
/// Describes replay frame kinds.
/// JA: ReplayFrameKind の公開契約を定義します。
/// </summary>
public enum ReplayFrameKind
{
    /// <summary>Unknown frame kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Video or screen frame. JA: Frame 値を表します。</summary>
    Frame = 1,

    /// <summary>State snapshot frame. JA: State 値を表します。</summary>
    State = 2,

    /// <summary>Checkpoint frame. JA: Checkpoint 値を表します。</summary>
    Checkpoint = 3
}
