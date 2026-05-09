namespace AIKernel.Abstractions.Execution;

using AIKernel.Abstractions.Models;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// 計算用 cardinality を提案する capability interface です。
/// </summary>
public interface IComputeCardinalityAdvisor
{
    /// <summary>
    /// 論理的なコンテキスト長（シーケンス長）から、
    /// ハードウェアに最適化された物理基数を計算します。
    /// </summary>
    int AdvisedPhysicalCardinality(int logicalLength, string deviceType);

    /// <summary>
    /// 複数の候補基数の中から、指定されたデバイスに最適なものを選択します。
    /// </summary>
    int SelectOptimalCardinality(IEnumerable<int> candidates, string deviceType);

    /// <summary>
    /// 指定されたデバイスでサポートされている基数アライメントを取得します。
    /// </summary>
    int GetCardinalityAlignment(string deviceType);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// Padding strategy と overhead を扱う capability interface です。
/// </summary>
public interface IComputePaddingAdvisor
{
    /// <summary>
    /// 指定された基数に対して必要なパディング戦略を提案します。
    /// </summary>
    PaddingStrategy GetPaddingStrategy(int logicalLength, string deviceType);

    /// <summary>
    /// パディング後のオーバーヘッド（追加メモリ、計算コスト）を見積ります。
    /// </summary>
    ComputeOverhead EstimatePaddingOverhead(int logicalLength, int physicalLength);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// Quantization level を提案する capability interface です。
/// </summary>
public interface IQuantizationAdvisor
{
    /// <summary>
    /// 指定された基数に対して推奨される量子化レベルを提案します。
    /// </summary>
    string AdvisedQuantizationLevel(int cardinality, string deviceType, float targetThroughputTflops);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// 実行制約下の最適な tensor shape を計算する capability interface です。
/// </summary>
public interface IComputeShapeOptimizer
{
    /// <summary>
    /// 指定された実行制約下での最適なテンソル形状を計算します。
    /// </summary>
    ComputeShape GetOptimalShape(IExecutionConstraints constraints);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// NPUなどのハードウェアに最適化された物理基数（テンソル形状）を提案する互換合成インターフェースです。
/// </summary>
public interface IComputeShapeAdvisor :
    IComputeCardinalityAdvisor,
    IComputePaddingAdvisor,
    IQuantizationAdvisor,
    IComputeShapeOptimizer
{
}
