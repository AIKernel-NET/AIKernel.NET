namespace AIKernel.Enums.Cognition;

/// <summary>
/// EN: Identifies a canonical sensory input family. JA: 正典的な感覚入力ファミリを識別します。
/// </summary>
public enum AisthesisSignalKind
{
    /// <summary>EN: Gets the unknown signal family. JA: 未知の信号ファミリを取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the visual signal family. JA: 視覚信号ファミリを取得します。</summary>
    Visual = 1,

    /// <summary>EN: Gets the audio signal family. JA: 聴覚信号ファミリを取得します。</summary>
    Audio = 2,

    /// <summary>EN: Gets the motor-intent signal family. JA: 運動意図信号ファミリを取得します。</summary>
    Motor = 3,

    /// <summary>EN: Gets the directional signal family. JA: 方位信号ファミリを取得します。</summary>
    Direction = 4,

    /// <summary>EN: Gets the life-state signal family. JA: 生命状態信号ファミリを取得します。</summary>
    Life = 5,

    /// <summary>EN: Gets the spatial signal family. JA: 空間信号ファミリを取得します。</summary>
    Spatial = 6,

    /// <summary>EN: Gets an external sensor signal family. JA: 外部センサー信号ファミリを取得します。</summary>
    External = 7
}

/// <summary>
/// EN: Identifies a semantic representation granularity. JA: 意味表象の粒度を識別します。
/// </summary>
public enum RepresentationGranularity
{
    /// <summary>EN: Gets the unknown representation granularity. JA: 未知の表象粒度を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the global representation granularity. JA: 大域表象粒度を取得します。</summary>
    Global = 1,

    /// <summary>EN: Gets the regional representation granularity. JA: 領域表象粒度を取得します。</summary>
    Regional = 2,

    /// <summary>EN: Gets the patch representation granularity. JA: パッチ表象粒度を取得します。</summary>
    Patch = 3,

    /// <summary>EN: Gets the temporal representation granularity. JA: 時系列表象粒度を取得します。</summary>
    Temporal = 4
}

/// <summary>
/// EN: Identifies a canonical priority lane. JA: 正典的な優先レーンを識別します。
/// </summary>
public enum TelosPriorityKind
{
    /// <summary>EN: Gets the unknown priority lane. JA: 未知の優先レーンを取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the telos lane. JA: TELOS レーンを取得します。</summary>
    Telos = 1,

    /// <summary>EN: Gets the objective lane. JA: OBJECTIVE レーンを取得します。</summary>
    Objective = 2,

    /// <summary>EN: Gets the priority lane. JA: PRIORITY レーンを取得します。</summary>
    Priority = 3,

    /// <summary>EN: Gets the recovery lane. JA: 復帰レーンを取得します。</summary>
    Recovery = 4
}

/// <summary>
/// EN: Identifies the dominant triadic contribution for an intent vector. JA: 意図ベクトルの支配的な三者寄与を識別します。
/// </summary>
public enum TriadicVectorKind
{
    /// <summary>EN: Gets the unknown vector kind. JA: 未知のベクトル種別を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the logos vector kind. JA: Logos ベクトル種別を取得します。</summary>
    Logos = 1,

    /// <summary>EN: Gets the pathos vector kind. JA: Pathos ベクトル種別を取得します。</summary>
    Pathos = 2,

    /// <summary>EN: Gets the ethos vector kind. JA: Ethos ベクトル種別を取得します。</summary>
    Ethos = 3,

    /// <summary>EN: Gets the composed decision vector kind. JA: 合成決定ベクトル種別を取得します。</summary>
    Decision = 4
}

/// <summary>
/// EN: Identifies a timing state used by Kairos. JA: Kairos が使用するタイミング状態を識別します。
/// </summary>
public enum KairosStateKind
{
    /// <summary>EN: Gets the unknown timing state. JA: 未知のタイミング状態を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the idle timing state. JA: 待機タイミング状態を取得します。</summary>
    Idle = 1,

    /// <summary>EN: Gets the ready timing state. JA: 準備済みタイミング状態を取得します。</summary>
    Ready = 2,

    /// <summary>EN: Gets the triggered timing state. JA: 発火済みタイミング状態を取得します。</summary>
    Triggered = 3,

    /// <summary>EN: Gets the suppressed timing state. JA: 抑制済みタイミング状態を取得します。</summary>
    Suppressed = 4,

    /// <summary>EN: Gets the recovering timing state. JA: 復帰中タイミング状態を取得します。</summary>
    Recovering = 5,

    /// <summary>EN: Gets the surveying timing state. JA: 再観測中タイミング状態を取得します。</summary>
    Surveying = 6
}

/// <summary>
/// EN: Identifies an abstract action family for Kinesis. JA: Kinesis の抽象行動ファミリを識別します。
/// </summary>
public enum KinesisActionKind
{
    /// <summary>EN: Gets the unknown action family. JA: 未知の行動ファミリを取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the no-op action family. JA: 無操作行動ファミリを取得します。</summary>
    None = 1,

    /// <summary>EN: Gets the move action family. JA: 移動行動ファミリを取得します。</summary>
    Move = 2,

    /// <summary>EN: Gets the turn action family. JA: 旋回行動ファミリを取得します。</summary>
    Turn = 3,

    /// <summary>EN: Gets the interact action family. JA: 相互作用行動ファミリを取得します。</summary>
    Interact = 4,

    /// <summary>EN: Gets the emit action family. JA: 出力行動ファミリを取得します。</summary>
    Emit = 5,

    /// <summary>EN: Gets the hold action family. JA: 保持行動ファミリを取得します。</summary>
    Hold = 6,

    /// <summary>EN: Gets the halt action family. JA: 停止行動ファミリを取得します。</summary>
    Halt = 7
}

/// <summary>
/// EN: Identifies a Chronos trace entry family. JA: Chronos トレースエントリのファミリを識別します。
/// </summary>
public enum ChronosTraceKind
{
    /// <summary>EN: Gets the unknown trace family. JA: 未知のトレースファミリを取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets an observation trace family. JA: 観測トレースファミリを取得します。</summary>
    Observation = 1,

    /// <summary>EN: Gets a representation trace family. JA: 表象トレースファミリを取得します。</summary>
    Representation = 2,

    /// <summary>EN: Gets a cognition trace family. JA: 認知トレースファミリを取得します。</summary>
    Cognition = 3,

    /// <summary>EN: Gets a proposal trace family. JA: 提案トレースファミリを取得します。</summary>
    Proposal = 4,

    /// <summary>EN: Gets a governance trace family. JA: 統治トレースファミリを取得します。</summary>
    Governance = 5,

    /// <summary>EN: Gets a timing trace family. JA: タイミングトレースファミリを取得します。</summary>
    Timing = 6,

    /// <summary>EN: Gets an action trace family. JA: 行動トレースファミリを取得します。</summary>
    Action = 7,

    /// <summary>EN: Gets an effect trace family. JA: 作用トレースファミリを取得します。</summary>
    Effect = 8
}
