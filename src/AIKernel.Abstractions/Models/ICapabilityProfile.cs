namespace AIKernel.Abstractions.Models;

/// <summary>
/// モデルの能力を「基数の関数」として表現するプロファイルです。
/// 単一のベクトル（点）ではなく、基数やメモリなどのパラメータに対する
/// 性能関数 F(N) を定義することで、NPU環境での動的基数対応を実現します。
/// </summary>
public interface ICapabilityProfile
{
    /// <summary>
    /// このプロファイルの一意識別子を取得します。
    /// </summary>
    string ProfileId { get; }

    /// <summary>
    /// このプロファイルが対応するモデルタイプを取得します。
    /// </summary>
    ModelType ModelType { get; }

    /// <summary>
    /// 指定された基数での能力ベクトルを計算します。
    /// </summary>
    /// <param name="cardinality">基数（シーケンス長、バッチサイズ等）</param>
    /// <returns>その基数での能力ベクトル</returns>
    IDynamicCapacityVector GetCapacityAtCardinality(int cardinality);

    /// <summary>
    /// 指定された実行制約での能力ベクトルを計算します。
    /// </summary>
    /// <param name="constraints">実行制約</param>
    /// <returns>その制約下での能力ベクトル</returns>
    IDynamicCapacityVector GetCapacityUnderConstraints(IExecutionConstraints constraints);

    /// <summary>
    /// このモデルが効率的に処理できる基数の範囲を取得します。
    /// </summary>
    /// <returns>最小基数と最大基数のペア</returns>
    (int MinCardinality, int MaxCardinality) GetOptimalCardinalityRange();

    /// <summary>
    /// 指定された基数での推定スループット（tokens/sec）を取得します。
    /// </summary>
    /// <param name="cardinality">基数</param>
    /// <param name="quantizationLevel">量子化レベル</param>
    /// <returns>推定スループット（トークン/秒）</returns>
    float GetEstimatedThroughput(int cardinality, string quantizationLevel);

    /// <summary>
    /// 指定された基数でのメモリ使用量（MB）を取得します。
    /// </summary>
    /// <param name="cardinality">基数</param>
    /// <param name="quantizationLevel">量子化レベル</param>
    /// <returns>推定メモリ使用量（MB）</returns>
    long GetEstimatedMemoryUsageMb(int cardinality, string quantizationLevel);

    /// <summary>
    /// 複数の基数でのプロファイルデータポイントを取得します。
    /// グラフ表示やプロファイリングに利用。
    /// </summary>
    /// <param name="cardinalityStep">基数のステップサイズ</param>
    /// <returns>基数とその時点での能力値のペア列挙</returns>
    IEnumerable<(int Cardinality, IDictionary<string, float> Capacities)> GetProfileCurve(int cardinalityStep = 64);

    /// <summary>
    /// 指定されたメモリバジェット内で最適な基数を提案します。
    /// </summary>
    /// <param name="availableMemoryMb">利用可能メモリ（MB）</param>
    /// <param name="quantizationLevel">量子化レベル</param>
    /// <returns>推奨基数</returns>
    int RecommendCardinalityForMemoryBudget(long availableMemoryMb, string quantizationLevel);
}
