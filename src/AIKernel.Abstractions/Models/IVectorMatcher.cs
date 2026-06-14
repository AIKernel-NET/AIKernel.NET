namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// モデル能力ベクトル間の距離や類似度を計算するための戦略インターフェースです。
/// 異なるアルゴリズム（コサイン類似度、ユークリッド距離等）を実装側で柔軟に選択できます。
/// JA: IVectorMatcher の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IVectorMatcher']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IVectorMatcher']" />
public interface IVectorMatcher
{
    /// <summary>
    /// 2つのベクトル間の類似度を計算します。
    /// JA: CalculateSimilarity 操作を実行します。
    /// </summary>
    /// <param name="required">要求ベクトル JA: required パラメーターです。</param>
    /// <param name="candidate">候補ベクトル JA: candidate パラメーターです。</param>
    /// <returns>類似度スコア（0.0 ~ 1.0、1.0が最も類似） JA: 結果を返します。</returns>
    float CalculateSimilarity(ModelCapacityVector required, ModelCapacityVector candidate);

    /// <summary>
    /// 2つのベクトル間の距離を計算します。
    /// JA: CalculateDistance 操作を実行します。
    /// </summary>
    /// <param name="required">要求ベクトル JA: required パラメーターです。</param>
    /// <param name="candidate">候補ベクトル JA: candidate パラメーターです。</param>
    /// <returns>距離スコア（0.0以上、0.0が最も近い） JA: 結果を返します。</returns>
    float CalculateDistance(ModelCapacityVector required, ModelCapacityVector candidate);

    /// <summary>
    /// 候補ベクトルが要求ベクトルを満たしているかチェックします。
    /// JA: IsSatisfied 操作を実行します。
    /// </summary>
    /// <param name="required">要求ベクトル JA: required パラメーターです。</param>
    /// <param name="candidate">候補ベクトル JA: candidate パラメーターです。</param>
    /// <returns>すべてのディメンションで候補が要求以上の場合は true JA: 結果を返します。</returns>
    bool IsSatisfied(ModelCapacityVector required, ModelCapacityVector candidate);
}

