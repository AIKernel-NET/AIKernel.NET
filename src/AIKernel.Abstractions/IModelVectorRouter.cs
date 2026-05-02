namespace AIKernel.Abstractions;

using AIKernel.Abstractions.Models;
using AIKernel.Enums;

/// <summary>
/// ベクトル演算を用いて最適なモデルを決定するエンジンです。
/// コサイン類似度やユークリッド距離などのアルゴリズムを自由に実装できます。
/// </summary>
public interface IModelVectorRouter
{
    /// <summary>
    /// 要求ベクトルに最も近い、あるいは要求を満たす最小のモデルを選定します。
    /// </summary>
    /// <param name="requirement">タスクの要求ベクトル</param>
    /// <param name="candidates">候補となるモデルの列挙</param>
    /// <returns>最適なモデルタイプ</returns>
    /// <exception cref="ArgumentException">候補が空の場合、または要求を満たすモデルがない場合</exception>
    /// <exception cref="ArgumentNullException">requirement または candidates が null の場合</exception>
    ModelType SelectOptimalModel(ModelCapacityVector requirement, IEnumerable<ModelType> candidates);

    /// <summary>
    /// 要求ベクトルを満たすすべてのモデルをスコア順にランク付けして返します。
    /// </summary>
    /// <param name="requirement">タスクの要求ベクトル</param>
    /// <param name="candidates">候補となるモデルの列挙</param>
    /// <returns>スコアとモデルのペアを降順で返す列挙</returns>
    /// <exception cref="ArgumentNullException">requirement または candidates が null の場合</exception>
    IEnumerable<(ModelType Model, float Score)> RankModels(
        ModelCapacityVector requirement,
        IEnumerable<ModelType> candidates);
}
