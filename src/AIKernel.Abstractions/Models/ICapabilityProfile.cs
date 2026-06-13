namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// モデルの能力を「基数の関数」として表現するプロファイルです。
/// 単一のベクトル（点）ではなく、基数やメモリなどのパラメータに対する
/// 性能関数 F(N) を定義することで、NPU環境での動的基数対応を実現します。
/// JA: ICapabilityProfile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.ICapabilityProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.ICapabilityProfile']" />
public interface ICapabilityProfile
{
    /// <summary>
    /// このプロファイルの一意識別子を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string ProfileId { get; }

    /// <summary>
    /// このプロファイルが対応するモデルタイプを取得します。
    /// JA: GetCapacityAtCardinality 操作を実行します。
    /// </summary>
    ModelType ModelType { get; }

    /// <summary>
    /// 指定された基数での能力ベクトルを計算します。
    /// JA: GetCapacityAtCardinality 操作を実行します。
    /// </summary>
    /// <param name="cardinality">基数（シーケンス長、バッチサイズ等） JA: cardinality パラメーターです。</param>
    /// <returns>その基数での能力ベクトル JA: 結果を返します。</returns>
    IDynamicCapacityVector GetCapacityAtCardinality(int cardinality);

    /// <summary>
    /// 指定された実行制約での能力ベクトルを計算します。
    /// JA: GetCapacityUnderConstraints 操作を実行します。
    /// </summary>
    /// <param name="constraints">実行制約 JA: constraints パラメーターです。</param>
    /// <returns>その制約下での能力ベクトル JA: 結果を返します。</returns>
    IDynamicCapacityVector GetCapacityUnderConstraints(IExecutionConstraints constraints);

    /// <summary>
    /// このモデルが効率的に処理できる基数の範囲を取得します。
    /// JA: GetOptimalCardinalityRange 操作を実行します。
    /// </summary>
    /// <returns>最小基数と最大基数のペア JA: 結果を返します。</returns>
    (int MinCardinality, int MaxCardinality) GetOptimalCardinalityRange();

    /// <summary>
    /// 指定された基数での推定スループット（tokens/sec）を取得します。
    /// JA: GetEstimatedThroughput 操作を実行します。
    /// </summary>
    /// <param name="cardinality">基数 JA: cardinality パラメーターです。</param>
    /// <param name="quantizationLevel">量子化レベル JA: quantizationLevel パラメーターです。</param>
    /// <returns>推定スループット（トークン/秒） JA: 結果を返します。</returns>
    float GetEstimatedThroughput(int cardinality, string quantizationLevel);

    /// <summary>
    /// 指定された基数でのメモリ使用量（MB）を取得します。
    /// JA: GetEstimatedMemoryUsageMb 操作を実行します。
    /// </summary>
    /// <param name="cardinality">基数 JA: cardinality パラメーターです。</param>
    /// <param name="quantizationLevel">量子化レベル JA: quantizationLevel パラメーターです。</param>
    /// <returns>推定メモリ使用量（MB） JA: 結果を返します。</returns>
    long GetEstimatedMemoryUsageMb(int cardinality, string quantizationLevel);

    /// <summary>
    /// 複数の基数でのプロファイルデータポイントを取得します。
    /// グラフ表示やプロファイリングに利用。
    /// JA: GetProfileCurve 操作を実行します。
    /// </summary>
    /// <param name="cardinalityStep">基数のステップサイズ JA: cardinalityStep パラメーターです。</param>
    /// <returns>基数とその時点での能力値のペア列挙 JA: 結果を返します。</returns>
    IEnumerable<(int Cardinality, IDictionary<string, float> Capacities)> GetProfileCurve(int cardinalityStep = 64);

    /// <summary>
    /// 指定されたメモリバジェット内で最適な基数を提案します。
    /// JA: RecommendCardinalityForMemoryBudget 操作を実行します。
    /// </summary>
    /// <param name="availableMemoryMb">利用可能メモリ（MB） JA: availableMemoryMb パラメーターです。</param>
    /// <param name="quantizationLevel">量子化レベル JA: quantizationLevel パラメーターです。</param>
    /// <returns>推奨基数 JA: 結果を返します。</returns>
    int RecommendCardinalityForMemoryBudget(long availableMemoryMb, string quantizationLevel);
}

