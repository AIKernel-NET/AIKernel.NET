namespace AIKernel.Abstractions.Models;

/// <summary>
/// モデル能力ベクトル間の距離や類似度を計算するための戦略インターフェースです。
/// 異なるアルゴリズム（コサイン類似度、ユークリッド距離等）を実装側で柔軟に選択できます。
/// </summary>
public interface IVectorMatcher
{
    /// <summary>
    /// 2つのベクトル間の類似度を計算します。
    /// </summary>
    /// <param name="required">要求ベクトル</param>
    /// <param name="candidate">候補ベクトル</param>
    /// <returns>類似度スコア（0.0 ~ 1.0、1.0が最も類似）</returns>
    float CalculateSimilarity(ModelCapacityVector required, ModelCapacityVector candidate);

    /// <summary>
    /// 2つのベクトル間の距離を計算します。
    /// </summary>
    /// <param name="required">要求ベクトル</param>
    /// <param name="candidate">候補ベクトル</param>
    /// <returns>距離スコア（0.0以上、0.0が最も近い）</returns>
    float CalculateDistance(ModelCapacityVector required, ModelCapacityVector candidate);

    /// <summary>
    /// 候補ベクトルが要求ベクトルを満たしているかチェックします。
    /// </summary>
    /// <param name="required">要求ベクトル</param>
    /// <param name="candidate">候補ベクトル</param>
    /// <returns>すべてのディメンションで候補が要求以上の場合は true</returns>
    bool IsSatisfied(ModelCapacityVector required, ModelCapacityVector candidate);
}
