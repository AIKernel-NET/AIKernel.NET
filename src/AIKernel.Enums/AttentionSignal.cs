namespace AIKernel.Enums;

/// <summary>
/// Attention の Signal/Noise 比を定義するための要素を分類します。
/// 
/// EN: 参照: 3.ATTENTION_POLLUTION_THEORY.jp.md
/// [EN] Documents this public package API member. [JA] AttentionSignal の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.AttentionSignal']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.AttentionSignal']" />
public enum AttentionSignal
{
    /// <summary>
    /// EN: Signal - 推論に必要な情報（attention の優先対象）
    /// [EN] Documents this public package API member. [JA] PurposePriority 値を表します。
    /// </summary>
    PurposePriority = 1,

    /// <summary>
    /// EN: Signal - 制約条件（attention の優先対象）
    /// [EN] Documents this public package API member. [JA] ConstraintsPriority 値を表します。
    /// </summary>
    ConstraintsPriority = 2,

    /// <summary>
    /// EN: Signal - 抽象構造（attention の優先対象）
    /// [EN] Documents this public package API member. [JA] StructurePriority 値を表します。
    /// </summary>
    StructurePriority = 3,

    /// <summary>
    /// EN: Signal - 思考パターン（attention の優先対象）
    /// [EN] Documents this public package API member. [JA] ReasoningPatternPriority 値を表します。
    /// </summary>
    ReasoningPatternPriority = 4,

    /// <summary>
    /// EN: Noise - 表面的な特徴（attention から隔離すべき）
    /// [EN] Documents this public package API member. [JA] ExampleNoise 値を表します。
    /// </summary>
    ExampleNoise = 101,

    /// <summary>
    /// EN: Noise - 文体指示（attention から隔離すべき）
    /// [EN] Documents this public package API member. [JA] StyleNoise 値を表します。
    /// </summary>
    StyleNoise = 102,

    /// <summary>
    /// EN: Noise - RAG の断片（attention から隔離すべき）
    /// [EN] Documents this public package API member. [JA] RagFragmentNoise 値を表します。
    /// </summary>
    RagFragmentNoise = 103,

    /// <summary>
    /// EN: Noise - 履歴の混入（attention から隔離すべき）
    /// [EN] Documents this public package API member. [JA] HistoryNoise 値を表します。
    /// </summary>
    HistoryNoise = 104,

    /// <summary>
    /// EN: Noise - その他ノイズ（attention から隔離すべき）
    /// [EN] Documents this public package API member. [JA] GeneralNoise 値を表します。
    /// </summary>
    GeneralNoise = 105
}

