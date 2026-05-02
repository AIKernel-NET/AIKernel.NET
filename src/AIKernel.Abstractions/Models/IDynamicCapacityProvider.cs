namespace AIKernel.Abstractions.Models;

using AIKernel.Enums;

/// <summary>
/// 実行制約に基づいて動的に能力ベクトルを解決するインターフェースです。
/// これは指示書で提案された、NPU対応の中核となるコンポーネントです。
/// </summary>
public interface IDynamicCapacityProvider
{
    /// <summary>
    /// 実行制約の下で、モデルの能力ベクトルを動的に解決します。
    /// 基数、量子化レベル、デバイスタイプなどの要因を考慮します。
    /// </summary>
    /// <param name="constraints">実行制約条件</param>
    /// <returns>制約下での能力ベクトル（Dictionary形式）</returns>
    IDictionary<string, float> ResolveCapacity(IExecutionConstraints constraints);

    /// <summary>
    /// 複数のモデル候補から、指定された制約下で最適なモデルを選定します。
    /// </summary>
    /// <param name="candidates">候補モデルタイプのリスト</param>
    /// <param name="constraints">実行制約条件</param>
    /// <param name="requirement">要求される能力ベクトル</param>
    /// <returns>最適なモデルタイプ</returns>
    /// <exception cref="ArgumentException">候補が空、または要求を満たすモデルがない場合</exception>
    ModelType SelectOptimalModelForConstraints(
        IEnumerable<ModelType> candidates,
        IExecutionConstraints constraints,
        IDictionary<string, float> requirement);

    /// <summary>
    /// 指定されたモデルとプロバイダーの能力プロファイルを登録します。
    /// </summary>
    /// <param name="modelType">モデルタイプ</param>
    /// <param name="profile">能力プロファイル</param>
    void RegisterCapabilityProfile(ModelType modelType, ICapabilityProfile profile);

    /// <summary>
    /// 指定されたモデルの能力プロファイルを取得します。
    /// </summary>
    /// <param name="modelType">モデルタイプ</param>
    /// <returns>能力プロファイル</returns>
    /// <exception cref="ArgumentException">モデルが登録されていない場合</exception>
    ICapabilityProfile GetCapabilityProfile(ModelType modelType);

    /// <summary>
    /// 実行可能なすべてのモデルタイプを取得します。
    /// </summary>
    /// <returns>登録済みモデルタイプの列挙</returns>
    IEnumerable<ModelType> GetRegisteredModels();
}
