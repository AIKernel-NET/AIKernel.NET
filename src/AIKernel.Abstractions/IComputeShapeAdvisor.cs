namespace AIKernel.Abstractions;

using AIKernel.Abstractions.Models;

/// <summary>
/// NPUなどのハードウェアに最適化された物理基数（テンソル形状）を提案するインターフェースです。
/// コンテキスト長が450の場合、NPU最適化のために512に切り上げるべきか、
/// あるいは他の値が最適かといった、物理計算リソースへのマッピングを司ります。
/// </summary>
public interface IComputeShapeAdvisor
{
    /// <summary>
    /// 論理的なコンテキスト長（シーケンス長）から、
    /// ハードウェアに最適化された物理基数を計算します。
    /// </summary>
    /// <param name="logicalLength">論理的なコンテキスト長</param>
    /// <param name="deviceType">デバイスタイプ（例："NPU", "GPU", "CPU"）</param>
    /// <returns>推奨される物理基数</returns>
    int AdvisedPhysicalCardinality(int logicalLength, string deviceType);

    /// <summary>
    /// 複数の候補基数の中から、指定されたデバイスに最適なものを選択します。
    /// </summary>
    /// <param name="candidates">候補基数のリスト</param>
    /// <param name="deviceType">デバイスタイプ</param>
    /// <returns>最適な基数</returns>
    int SelectOptimalCardinality(IEnumerable<int> candidates, string deviceType);

    /// <summary>
    /// 指定された基数に対して必要なパディング戦略を提案します。
    /// </summary>
    /// <param name="logicalLength">論理的なコンテキスト長</param>
    /// <param name="deviceType">デバイスタイプ</param>
    /// <returns>パディング戦略</returns>
    PaddingStrategy GetPaddingStrategy(int logicalLength, string deviceType);

    /// <summary>
    /// 指定された基数に対して推奨される量子化レベルを提案します。
    /// </summary>
    /// <param name="cardinality">基数</param>
    /// <param name="deviceType">デバイスタイプ</param>
    /// <param name="targetThroughputTflops">目標スループット（TFLOPS）</param>
    /// <returns>推奨される量子化レベル</returns>
    string AdvisedQuantizationLevel(int cardinality, string deviceType, float targetThroughputTflops);

    /// <summary>
    /// 指定された実行制約下での最適なテンソル形状を計算します。
    /// </summary>
    /// <param name="constraints">実行制約</param>
    /// <returns>推奨されるテンソル形状</returns>
    ComputeShape GetOptimalShape(IExecutionConstraints constraints);

    /// <summary>
    /// パディング後のオーバーヘッド（追加メモリ、計算コスト）を見積ります。
    /// </summary>
    /// <param name="logicalLength">論理的なコンテキスト長</param>
    /// <param name="physicalLength">パディング後の物理基数</param>
    /// <returns>オーバーヘッド見積り</returns>
    ComputeOverhead EstimatePaddingOverhead(int logicalLength, int physicalLength);

    /// <summary>
    /// 指定されたデバイスでサポートされている基数アライメントを取得します。
    /// 例：NPUが256の倍数のみをサポートしている場合、256を返す。
    /// </summary>
    /// <param name="deviceType">デバイスタイプ</param>
    /// <returns>基数アライメント</returns>
    int GetCardinalityAlignment(string deviceType);
}

/// <summary>
/// パディング戦略を表現する値型です。
/// </summary>
public class PaddingStrategy
{
    /// <summary>
    /// パディング方式を取得します。
    /// 例："ZeroPadding", "ReflectPadding", "ReplicatePadding"
    /// </summary>
    public required string PaddingType { get; init; }

    /// <summary>
    /// パディング後の物理基数を取得します。
    /// </summary>
    public required int PhysicalCardinality { get; init; }

    /// <summary>
    /// パディング量（追加トークン数）を取得します。
    /// </summary>
    public int PaddingAmount => PhysicalCardinality - LogicalCardinality;

    /// <summary>
    /// 論理的なコンテキスト長を取得します。
    /// </summary>
    public required int LogicalCardinality { get; init; }

    /// <summary>
    /// このパディング戦略が採用されるべき理由を取得します。
    /// </summary>
    public string? Rationale { get; init; }

    /// <summary>
    /// パディング後のメモリオーバーヘッド（%）を取得します。
    /// </summary>
    public float MemoryOverheadPercent => LogicalCardinality > 0 
        ? (PaddingAmount * 100.0f) / LogicalCardinality 
        : 0.0f;
}

/// <summary>
/// 計算形状（テンソル形状）を表現するクラスです。
/// </summary>
public class ComputeShape
{
    /// <summary>
    /// バッチサイズを取得します。
    /// </summary>
    public required int BatchSize { get; init; }

    /// <summary>
    /// シーケンス長を取得します。
    /// </summary>
    public required int SequenceLength { get; init; }

    /// <summary>
    /// 隠れ層ディメンションを取得します。
    /// </summary>
    public required int HiddenDimension { get; init; }

    /// <summary>
    /// 総要素数を取得します。
    /// </summary>
    public int TotalElements => BatchSize * SequenceLength * HiddenDimension;

    /// <summary>
    /// テンソル形状を文字列表現で取得します。
    /// </summary>
    public override string ToString() => $"[{BatchSize}, {SequenceLength}, {HiddenDimension}]";
}

/// <summary>
/// 計算オーバーヘッドを表現するクラスです。
/// </summary>
public class ComputeOverhead
{
    /// <summary>
    /// メモリオーバーヘッド（MB）を取得します。
    /// </summary>
    public required long MemoryOverheadMb { get; init; }

    /// <summary>
    /// 計算オーバーヘッド（追加FLOPs）を取得します。
    /// </summary>
    public required long AdditionalFlops { get; init; }

    /// <summary>
    /// 推定実行時間オーバーヘッド（ミリ秒）を取得します。
    /// </summary>
    public required float LatencyOverheadMs { get; init; }

    /// <summary>
    /// オーバーヘッドが許容範囲内か判定します。
    /// </summary>
    /// <param name="maxMemoryMb">最大許容メモリオーバーヘッド</param>
    /// <param name="maxLatencyMs">最大許容遅延オーバーヘッド</param>
    /// <returns>両方の制約を満たす場合は true</returns>
    public bool IsAcceptable(long maxMemoryMb, float maxLatencyMs)
    {
        return MemoryOverheadMb <= maxMemoryMb && LatencyOverheadMs <= maxLatencyMs;
    }
}
