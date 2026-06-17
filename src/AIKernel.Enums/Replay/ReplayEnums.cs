namespace AIKernel.Enums.Replay;

/// <summary>
/// EN: Describes replay event kinds.
/// [EN] Documents this public package API member. [JA] ReplayEventKind の公開契約を定義します。
/// </summary>
public enum ReplayEventKind
{
    /// <summary>EN: Unknown replay event kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Runtime event. JA: Runtime 値を表します。</summary>
    Runtime = 1,

    /// <summary>EN: Input event. JA: Input 値を表します。</summary>
    Input = 2,

    /// <summary>EN: Observation event. JA: Observation 値を表します。</summary>
    Observation = 3,

    /// <summary>EN: Decision event. JA: Decision 値を表します。</summary>
    Decision = 4,

    /// <summary>EN: Diagnostic event. JA: Diagnostic 値を表します。</summary>
    Diagnostic = 5,

    /// <summary>EN: Evidence event. JA: Evidence 値を表します。</summary>
    Evidence = 6
}

/// <summary>
/// EN: Describes replay sealing state.
/// [EN] Documents this public package API member. [JA] ReplaySealState の公開契約を定義します。
/// </summary>
public enum ReplaySealState
{
    /// <summary>EN: Unknown seal state. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: The timeline is open. JA: Open 値を表します。</summary>
    Open = 1,

    /// <summary>EN: The timeline is sealing. JA: Sealing 値を表します。</summary>
    Sealing = 2,

    /// <summary>EN: The timeline is sealed. JA: Sealed 値を表します。</summary>
    Sealed = 3,

    /// <summary>EN: Sealing failed. JA: Failed 値を表します。</summary>
    Failed = 4
}

/// <summary>
/// EN: Describes replay frame kinds.
/// [EN] Documents this public package API member. [JA] ReplayFrameKind の公開契約を定義します。
/// </summary>
public enum ReplayFrameKind
{
    /// <summary>EN: Unknown frame kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Video or screen frame. JA: Frame 値を表します。</summary>
    Frame = 1,

    /// <summary>EN: State snapshot frame. JA: State 値を表します。</summary>
    State = 2,

    /// <summary>EN: Checkpoint frame. JA: Checkpoint 値を表します。</summary>
    Checkpoint = 3
}
