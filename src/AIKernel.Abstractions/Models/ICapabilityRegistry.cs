namespace AIKernel.Abstractions.Models;

using AIKernel.Enums;

/// <summary>
/// 各モデルのベクトルデータを管理するレジストリです。
/// RAG/カタログ参照を通じてモデルの能力情報を提供します。
/// </summary>
public interface ICapabilityRegistry
{
    /// <summary>
    /// 指定されたモデルの既定ベクトルを取得します。
    /// </summary>
    /// <param name="modelType">モデルタイプ</param>
    /// <returns>モデルの能力ベクトル</returns>
    /// <exception cref="ArgumentException">指定されたモデルタイプが登録されていない場合</exception>
    ModelCapacityVector GetCapacity(ModelType modelType);

    /// <summary>
    /// 特定の閾値をすべて超えるモデルを検索します。
    /// </summary>
    /// <param name="threshold">検索の閾値ベクトル</param>
    /// <returns>すべてのディメンションで閾値以上の能力を持つモデルの列挙</returns>
    IEnumerable<ModelType> FindModelsAbove(ModelCapacityVector threshold);

    /// <summary>
    /// すべての登録済みモデルを取得します。
    /// </summary>
    /// <returns>登録済みモデルタイプの列挙</returns>
    IEnumerable<ModelType> GetAllRegisteredModels();

    /// <summary>
    /// モデルの能力ベクトルを登録または更新します。
    /// </summary>
    /// <param name="modelType">モデルタイプ</param>
    /// <param name="capacity">能力ベクトル</param>
    void RegisterCapacity(ModelType modelType, ModelCapacityVector capacity);
}
