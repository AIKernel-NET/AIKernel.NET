namespace AIKernel.Abstractions.Models;

/// <summary>
/// モデルの多次元的な能力を定義する不変データ構造です。
/// すべてのプロパティは 0.0 ~ 1.0 の範囲で正規化されます。
/// </summary>
public record ModelCapacityVector
{
    /// <summary>
    /// 階層構造の保持、JSON/XML等の厳密な出力能力。
    /// 値域: 0.0 ~ 1.0
    /// </summary>
    public float StructuralIntegrity { get; init; }

    /// <summary>
    /// 自然な文章生成、文体模倣、情緒的表現力。
    /// 値域: 0.0 ~ 1.0
    /// </summary>
    public float LinguisticFluidity { get; init; }

    /// <summary>
    /// 多段階の論理推論、複雑な問題解決能力。
    /// 値域: 0.0 ~ 1.0
    /// </summary>
    public float ReasoningDepth { get; init; }

    /// <summary>
    /// 指示への忠実性、システムプロンプトの遵守力。
    /// 値域: 0.0 ~ 1.0
    /// </summary>
    public float Fidelity { get; init; }

    /// <summary>
    /// 応答速度の速さ（1.0が最速）。
    /// 値域: 0.0 ~ 1.0
    /// </summary>
    public float LatencyPerformance { get; init; }

    /// <summary>
    /// <see cref="ModelCapacityVector"/> の新しいインスタンスを初期化します。
    /// 値は自動的に 0.0 ~ 1.0 の範囲でクランプされます。
    /// </summary>
    public ModelCapacityVector(
        float structuralIntegrity = 0f,
        float linguisticFluidity = 0f,
        float reasoningDepth = 0f,
        float fidelity = 0f,
        float latencyPerformance = 0f)
    {
        StructuralIntegrity = Clamp(structuralIntegrity);
        LinguisticFluidity = Clamp(linguisticFluidity);
        ReasoningDepth = Clamp(reasoningDepth);
        Fidelity = Clamp(fidelity);
        LatencyPerformance = Clamp(latencyPerformance);
    }

    /// <summary>
    /// 値を 0.0 ~ 1.0 の範囲にクランプします。
    /// </summary>
    private static float Clamp(float value)
    {
        return Math.Max(0f, Math.Min(1f, value));
    }

    /// <summary>
    /// このベクトルと別のベクトルの間のコサイン類似度を計算します。
    /// 値域: 0.0 ~ 1.0（1.0 が最も類似）
    /// </summary>
    public float CosineSimilarity(ModelCapacityVector other)
    {
        ArgumentNullException.ThrowIfNull(other);

        var dotProduct = 
            StructuralIntegrity * other.StructuralIntegrity +
            LinguisticFluidity * other.LinguisticFluidity +
            ReasoningDepth * other.ReasoningDepth +
            Fidelity * other.Fidelity +
            LatencyPerformance * other.LatencyPerformance;

        var magnitudeA = MagnitudeSquared();
        var magnitudeB = other.MagnitudeSquared();

        if (magnitudeA == 0 || magnitudeB == 0)
            return 0f;

        return dotProduct / (float)Math.Sqrt(magnitudeA * magnitudeB);
    }

    /// <summary>
    /// このベクトルと別のベクトルの間のユークリッド距離を計算します。
    /// </summary>
    public float EuclideanDistance(ModelCapacityVector other)
    {
        ArgumentNullException.ThrowIfNull(other);

        var dx = StructuralIntegrity - other.StructuralIntegrity;
        var dy = LinguisticFluidity - other.LinguisticFluidity;
        var dz = ReasoningDepth - other.ReasoningDepth;
        var dw = Fidelity - other.Fidelity;
        var dv = LatencyPerformance - other.LatencyPerformance;

        return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw + dv * dv);
    }

    /// <summary>
    /// このベクトルが要求ベクトルを満たしているかチェックします。
    /// すべてのディメンションが要求以上の値を持つ場合に true を返します。
    /// </summary>
    public bool Satisfies(ModelCapacityVector requirement)
    {
        ArgumentNullException.ThrowIfNull(requirement);

        return StructuralIntegrity >= requirement.StructuralIntegrity &&
               LinguisticFluidity >= requirement.LinguisticFluidity &&
               ReasoningDepth >= requirement.ReasoningDepth &&
               Fidelity >= requirement.Fidelity &&
               LatencyPerformance >= requirement.LatencyPerformance;
    }

    /// <summary>
    /// ベクトルの大きさの二乗を計算します。
    /// </summary>
    private float MagnitudeSquared()
    {
        return StructuralIntegrity * StructuralIntegrity +
               LinguisticFluidity * LinguisticFluidity +
               ReasoningDepth * ReasoningDepth +
               Fidelity * Fidelity +
               LatencyPerformance * LatencyPerformance;
    }
}
