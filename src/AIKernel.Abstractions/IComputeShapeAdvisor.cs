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
