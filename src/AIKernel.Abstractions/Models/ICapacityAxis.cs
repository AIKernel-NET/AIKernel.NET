namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// モデル能力評価の次元（ディメンション）を表現するインターフェースです。
/// 将来的な評価軸の追加に対応するための拡張性を提供します。
/// JA: ICapacityAxis の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.ICapacityAxis']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.ICapacityAxis']" />
public interface ICapacityAxis
{
    /// <summary>
    /// この次元の一意識別子を取得します。
    /// 例: "ReasoningDepth", "LinguisticFluidity", "Creativity", "EthicalAwareness"
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string AxisId { get; }

    /// <summary>
    /// この次元の表示名を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string DisplayName { get; }

    /// <summary>
    /// この次元の説明を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string Description { get; }

    /// <summary>
    /// この次元の最小値を取得します（通常は 0.0）。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    float MinimumValue { get; }

    /// <summary>
    /// この次元の最大値を取得します（通常は 1.0）。
    /// JA: IsValueValid 操作を実行します。
    /// </summary>
    float MaximumValue { get; }

    /// <summary>
    /// 値がこの次元の有効な範囲内にあるかチェックします。
    /// JA: IsValueValid 操作を実行します。
    /// </summary>
    /// <param name="value">チェックする値 JA: value パラメーターです。</param>
    /// <returns>値が有効な範囲内の場合は true JA: 結果を返します。</returns>
    bool IsValueValid(float value);
}

