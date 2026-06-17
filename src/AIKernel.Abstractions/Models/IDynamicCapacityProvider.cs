namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// 実行制約に基づいて動的に能力ベクトルを解決するインターフェースです。
/// EN: これは指示書で提案された、NPU対応の中核となるコンポーネントです。
/// [EN] Documents this public package API member. [JA] IDynamicCapacityProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityProvider']" />
public interface IDynamicCapacityProvider
{
    /// <summary>
    /// 実行制約の下で、モデルの能力ベクトルを動的に解決します。
    /// EN: 基数、量子化レベル、デバイスタイプなどの要因を考慮します。
    /// [EN] Documents this public package API member. [JA] ResolveCapacity 操作を実行します。
    /// </summary>
    /// <param name="constraints">[EN] Documents this public package API member. [JA] 実行制約条件 constraints パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 制約下での能力ベクトル（Dictionary形式） 結果を返します。</returns>
    IDictionary<string, float> ResolveCapacity(IExecutionConstraints constraints);

    /// <summary>
    /// EN: 複数のモデル候補から、指定された制約下で最適なモデルを選定します。
    /// [EN] Documents this public package API member. [JA] SelectOptimalModelForConstraints 操作を実行します。
    /// </summary>
    /// <param name="candidates">[EN] Documents this public package API member. [JA] 候補モデルタイプのリスト candidates パラメーターです。</param>
    /// <param name="constraints">[EN] Documents this public package API member. [JA] 実行制約条件 constraints パラメーターです。</param>
    /// <param name="requirement">[EN] Documents this public package API member. [JA] 要求される能力ベクトル requirement パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 最適なモデルタイプ 結果を返します。</returns>
    ModelType SelectOptimalModelForConstraints(
        IEnumerable<ModelType> candidates,
        IExecutionConstraints constraints,
        IDictionary<string, float> requirement);

    /// <summary>
    /// EN: 指定されたモデルとプロバイダーの能力プロファイルを登録します。
    /// [EN] Documents this public package API member. [JA] RegisterCapabilityProfile 操作を実行します。
    /// </summary>
    /// <param name="modelType">[EN] Documents this public package API member. [JA] モデルタイプ modelType パラメーターです。</param>
    /// <param name="profile">[EN] Documents this public package API member. [JA] 能力プロファイル profile パラメーターです。</param>
    void RegisterCapabilityProfile(ModelType modelType, ICapabilityProfile profile);

    /// <summary>
    /// EN: 指定されたモデルの能力プロファイルを取得します。
    /// [EN] Documents this public package API member. [JA] GetCapabilityProfile 操作を実行します。
    /// </summary>
    /// <param name="modelType">[EN] Documents this public package API member. [JA] モデルタイプ modelType パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 能力プロファイル 結果を返します。</returns>
    ICapabilityProfile GetCapabilityProfile(ModelType modelType);

    /// <summary>
    /// EN: 実行可能なすべてのモデルタイプを取得します。
    /// [EN] Documents this public package API member. [JA] GetRegisteredModels 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 登録済みモデルタイプの列挙 結果を返します。</returns>
    IEnumerable<ModelType> GetRegisteredModels();
}

