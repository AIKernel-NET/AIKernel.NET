namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// モデルの能力を「基数の関数」として表現するプロファイルです。
/// 単一のベクトル（点）ではなく、基数やメモリなどのパラメータに対する
/// EN: 性能関数 F(N) を定義することで、NPU環境での動的基数対応を実現します。
/// EN: Documentation for public API. JA: ICapabilityProfile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.ICapabilityProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.ICapabilityProfile']" />
public interface ICapabilityProfile
{
    /// <summary>
    /// EN: このプロファイルの一意識別子を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string ProfileId { get; }

    /// <summary>
    /// EN: このプロファイルが対応するモデルタイプを取得します。
    /// EN: Documentation for public API. JA: GetCapacityAtCardinality 操作を実行します。
    /// </summary>
    ModelType ModelType { get; }

    /// <summary>
    /// EN: 指定された基数での能力ベクトルを計算します。
    /// EN: Documentation for public API. JA: GetCapacityAtCardinality 操作を実行します。
    /// </summary>
    /// <param name="cardinality">EN: Documentation for public API. JA: 基数（シーケンス長、バッチサイズ等） cardinality パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: その基数での能力ベクトル 結果を返します。</returns>
    IDynamicCapacityVector GetCapacityAtCardinality(int cardinality);

    /// <summary>
    /// EN: 指定された実行制約での能力ベクトルを計算します。
    /// EN: Documentation for public API. JA: GetCapacityUnderConstraints 操作を実行します。
    /// </summary>
    /// <param name="constraints">EN: Documentation for public API. JA: 実行制約 constraints パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: その制約下での能力ベクトル 結果を返します。</returns>
    IDynamicCapacityVector GetCapacityUnderConstraints(IExecutionConstraints constraints);

    /// <summary>
    /// EN: このモデルが効率的に処理できる基数の範囲を取得します。
    /// EN: Documentation for public API. JA: GetOptimalCardinalityRange 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: 最小基数と最大基数のペア 結果を返します。</returns>
    (int MinCardinality, int MaxCardinality) GetOptimalCardinalityRange();

    /// <summary>
    /// EN: 指定された基数での推定スループット（tokens/sec）を取得します。
    /// EN: Documentation for public API. JA: GetEstimatedThroughput 操作を実行します。
    /// </summary>
    /// <param name="cardinality">EN: Documentation for public API. JA: 基数 cardinality パラメーターです。</param>
    /// <param name="quantizationLevel">EN: Documentation for public API. JA: 量子化レベル quantizationLevel パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 推定スループット（トークン/秒） 結果を返します。</returns>
    float GetEstimatedThroughput(int cardinality, string quantizationLevel);

    /// <summary>
    /// EN: 指定された基数でのメモリ使用量（MB）を取得します。
    /// EN: Documentation for public API. JA: GetEstimatedMemoryUsageMb 操作を実行します。
    /// </summary>
    /// <param name="cardinality">EN: Documentation for public API. JA: 基数 cardinality パラメーターです。</param>
    /// <param name="quantizationLevel">EN: Documentation for public API. JA: 量子化レベル quantizationLevel パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 推定メモリ使用量（MB） 結果を返します。</returns>
    long GetEstimatedMemoryUsageMb(int cardinality, string quantizationLevel);

    /// <summary>
    /// 複数の基数でのプロファイルデータポイントを取得します。
    /// EN: グラフ表示やプロファイリングに利用。
    /// EN: Documentation for public API. JA: GetProfileCurve 操作を実行します。
    /// </summary>
    /// <param name="cardinalityStep">EN: Documentation for public API. JA: 基数のステップサイズ cardinalityStep パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 基数とその時点での能力値のペア列挙 結果を返します。</returns>
    IEnumerable<(int Cardinality, IDictionary<string, float> Capacities)> GetProfileCurve(int cardinalityStep = 64);

    /// <summary>
    /// EN: 指定されたメモリバジェット内で最適な基数を提案します。
    /// EN: Documentation for public API. JA: RecommendCardinalityForMemoryBudget 操作を実行します。
    /// </summary>
    /// <param name="availableMemoryMb">EN: Documentation for public API. JA: 利用可能メモリ（MB） availableMemoryMb パラメーターです。</param>
    /// <param name="quantizationLevel">EN: Documentation for public API. JA: 量子化レベル quantizationLevel パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 推奨基数 結果を返します。</returns>
    int RecommendCardinalityForMemoryBudget(long availableMemoryMb, string quantizationLevel);
}

