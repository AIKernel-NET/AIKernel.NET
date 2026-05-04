namespace AIKernel.Abstractions.Models;

/// <summary>
/// モデル能力評価の次元（ディメンション）を表現するインターフェースです。
/// 将来的な評価軸の追加に対応するための拡張性を提供します。
/// </summary>
public interface ICapacityAxis
{
    /// <summary>
    /// この次元の一意識別子を取得します。
    /// 例: "ReasoningDepth", "LinguisticFluidity", "Creativity", "EthicalAwareness"
    /// </summary>
    string AxisId { get; }

    /// <summary>
    /// この次元の表示名を取得します。
    /// </summary>
    string DisplayName { get; }

    /// <summary>
    /// この次元の説明を取得します。
    /// </summary>
    string Description { get; }

    /// <summary>
    /// この次元の最小値を取得します（通常は 0.0）。
    /// </summary>
    float MinimumValue { get; }

    /// <summary>
    /// この次元の最大値を取得します（通常は 1.0）。
    /// </summary>
    float MaximumValue { get; }

    /// <summary>
    /// 値がこの次元の有効な範囲内にあるかチェックします。
    /// </summary>
    /// <param name="value">チェックする値</param>
    /// <returns>値が有効な範囲内の場合は true</returns>
    bool IsValueValid(float value);
}
