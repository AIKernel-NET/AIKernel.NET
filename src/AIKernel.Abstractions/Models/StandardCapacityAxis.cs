namespace AIKernel.Abstractions.Models;

/// <summary>
/// モデル能力の標準的な評価軸を定義します。
/// </summary>
public static class StandardCapacityAxis
{
    /// <summary>
    /// 階層構造の保持、JSON/XML等の厳密な出力能力。
    /// </summary>
    public static readonly StandardCapacityAxisImpl StructuralIntegrity = new(
        "StructuralIntegrity",
        "構造的完全性",
        "階層構造の保持、JSON/XML等の厳密な出力能力");

    /// <summary>
    /// 自然な文章生成、文体模倣、情緒的表現力。
    /// </summary>
    public static readonly StandardCapacityAxisImpl LinguisticFluidity = new(
        "LinguisticFluidity",
        "言語流暢性",
        "自然な文章生成、文体模倣、情緒的表現力");

    /// <summary>
    /// 多段階の論理推論、複雑な問題解決能力。
    /// </summary>
    public static readonly StandardCapacityAxisImpl ReasoningDepth = new(
        "ReasoningDepth",
        "推論の深さ",
        "多段階の論理推論、複雑な問題解決能力");

    /// <summary>
    /// 指示への忠実性、システムプロンプトの遵守力。
    /// </summary>
    public static readonly StandardCapacityAxisImpl Fidelity = new(
        "Fidelity",
        "指示忠実性",
        "指示への忠実性、システムプロンプトの遵守力");

    /// <summary>
    /// 応答速度の速さ（1.0が最速）。
    /// </summary>
    public static readonly StandardCapacityAxisImpl LatencyPerformance = new(
        "LatencyPerformance",
        "レイテンシ性能",
        "応答速度の速さ（1.0が最速）");

    /// <summary>
    /// 標準的な評価軸の実装クラス。
    /// </summary>
    public sealed class StandardCapacityAxisImpl : ICapacityAxis
    {
        public string AxisId { get; }
        public string DisplayName { get; }
        public string Description { get; }
        public float MinimumValue => 0.0f;
        public float MaximumValue => 1.0f;

        internal StandardCapacityAxisImpl(string axisId, string displayName, string description)
        {
            AxisId = axisId;
            DisplayName = displayName;
            Description = description;
        }

        public bool IsValueValid(float value)
        {
            return value >= MinimumValue && value <= MaximumValue;
        }

        public override string ToString() => DisplayName;
    }

    /// <summary>
    /// すべての標準的な評価軸を取得します。
    /// </summary>
    /// <returns>標準評価軸の列挙</returns>
    public static IEnumerable<ICapacityAxis> GetAllStandardAxes()
    {
        yield return StructuralIntegrity;
        yield return LinguisticFluidity;
        yield return ReasoningDepth;
        yield return Fidelity;
        yield return LatencyPerformance;
    }
}
