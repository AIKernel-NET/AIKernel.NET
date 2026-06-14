namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// 実行制約に基づいて動的に能力ベクトルを解決するインターフェースです。
/// これは指示書で提案された、NPU対応の中核となるコンポーネントです。
/// JA: IDynamicCapacityProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityProvider']" />
public interface IDynamicCapacityProvider
{
    /// <summary>
    /// 実行制約の下で、モデルの能力ベクトルを動的に解決します。
    /// 基数、量子化レベル、デバイスタイプなどの要因を考慮します。
    /// JA: ResolveCapacity 操作を実行します。
    /// </summary>
    /// <param name="constraints">実行制約条件 JA: constraints パラメーターです。</param>
    /// <returns>制約下での能力ベクトル（Dictionary形式） JA: 結果を返します。</returns>
    IDictionary<string, float> ResolveCapacity(IExecutionConstraints constraints);

    /// <summary>
    /// 複数のモデル候補から、指定された制約下で最適なモデルを選定します。
    /// JA: SelectOptimalModelForConstraints 操作を実行します。
    /// </summary>
    /// <param name="candidates">候補モデルタイプのリスト JA: candidates パラメーターです。</param>
    /// <param name="constraints">実行制約条件 JA: constraints パラメーターです。</param>
    /// <param name="requirement">要求される能力ベクトル JA: requirement パラメーターです。</param>
    /// <returns>最適なモデルタイプ JA: 結果を返します。</returns>
    ModelType SelectOptimalModelForConstraints(
        IEnumerable<ModelType> candidates,
        IExecutionConstraints constraints,
        IDictionary<string, float> requirement);

    /// <summary>
    /// 指定されたモデルとプロバイダーの能力プロファイルを登録します。
    /// JA: RegisterCapabilityProfile 操作を実行します。
    /// </summary>
    /// <param name="modelType">モデルタイプ JA: modelType パラメーターです。</param>
    /// <param name="profile">能力プロファイル JA: profile パラメーターです。</param>
    void RegisterCapabilityProfile(ModelType modelType, ICapabilityProfile profile);

    /// <summary>
    /// 指定されたモデルの能力プロファイルを取得します。
    /// JA: GetCapabilityProfile 操作を実行します。
    /// </summary>
    /// <param name="modelType">モデルタイプ JA: modelType パラメーターです。</param>
    /// <returns>能力プロファイル JA: 結果を返します。</returns>
    ICapabilityProfile GetCapabilityProfile(ModelType modelType);

    /// <summary>
    /// 実行可能なすべてのモデルタイプを取得します。
    /// JA: GetRegisteredModels 操作を実行します。
    /// </summary>
    /// <returns>登録済みモデルタイプの列挙 JA: 結果を返します。</returns>
    IEnumerable<ModelType> GetRegisteredModels();
}

