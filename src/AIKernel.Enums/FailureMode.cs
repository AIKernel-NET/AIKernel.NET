namespace AIKernel.Enums;

/// <summary>
/// Attention 汚染により発生する failure mode を定義します。
/// 
/// EN: 参照: 3.ATTENTION_POLLUTION_THEORY.jp.md, 4.LLM_SURFACE_MODE_FAILURE.jp.md
/// EN: Documentation for public API. JA: FailureMode の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.FailureMode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.FailureMode']" />
public enum FailureMode
{
    /// <summary>
    /// EN: 表面模写モード - LLM が文体だけ真似て推論をしない状態
    /// EN: Documentation for public API. JA: SurfaceMode 値を表します。
    /// </summary>
    SurfaceMode = 1,

    /// <summary>
    /// EN: 推論停止 - structure が attention に乗らず、推論能力が喪失された状態
    /// EN: Documentation for public API. JA: ReasoningStopped 値を表します。
    /// </summary>
    ReasoningStopped = 2,

    /// <summary>
    /// EN: ハルシネーション増加 - context と rag_material が混ざり、事実性が崩壊した状態
    /// EN: Documentation for public API. JA: HallucinationIncrease 値を表します。
    /// </summary>
    HallucinationIncrease = 3,

    /// <summary>
    /// EN: Deterministic Replay 破壊 - history と question が混ざり、再現性が失われた状態
    /// EN: Documentation for public API. JA: DeterministicReplayBroken 値を表します。
    /// </summary>
    DeterministicReplayBroken = 4,

    /// <summary>
    /// EN: 目的の喪失 - purpose が attention に乗らず、タスク遂行能力が低下した状態
    /// EN: Documentation for public API. JA: PurposeLost 値を表します。
    /// </summary>
    PurposeLost = 5,

    /// <summary>
    /// EN: 自己修正能力喪失 - Self-Correction 能力を失った状態（表面模写モード時）
    /// EN: Documentation for public API. JA: SelfCorrectionLost 値を表します。
    /// </summary>
    SelfCorrectionLost = 6
}

