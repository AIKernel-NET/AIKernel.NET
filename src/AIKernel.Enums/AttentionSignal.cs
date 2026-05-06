namespace AIKernel.Enums;

/// <summary>
/// Attention の Signal/Noise 比を定義するための要素を分類します。
/// 
/// 参照: 3.ATTENTION_POLLUTION_THEORY.jp.md
/// </summary>
public enum AttentionSignal
{
    /// <summary>
    /// Signal - 推論に必要な情報（attention の優先対象）
    /// </summary>
    PurposePriority = 1,

    /// <summary>
    /// Signal - 制約条件（attention の優先対象）
    /// </summary>
    ConstraintsPriority = 2,

    /// <summary>
    /// Signal - 抽象構造（attention の優先対象）
    /// </summary>
    StructurePriority = 3,

    /// <summary>
    /// Signal - 思考パターン（attention の優先対象）
    /// </summary>
    ReasoningPatternPriority = 4,

    /// <summary>
    /// Noise - 表面的な特徴（attention から隔離すべき）
    /// </summary>
    ExampleNoise = 101,

    /// <summary>
    /// Noise - 文体指示（attention から隔離すべき）
    /// </summary>
    StyleNoise = 102,

    /// <summary>
    /// Noise - RAG の断片（attention から隔離すべき）
    /// </summary>
    RagFragmentNoise = 103,

    /// <summary>
    /// Noise - 履歴の混入（attention から隔離すべき）
    /// </summary>
    HistoryNoise = 104,

    /// <summary>
    /// Noise - その他ノイズ（attention から隔離すべき）
    /// </summary>
    GeneralNoise = 105
}

