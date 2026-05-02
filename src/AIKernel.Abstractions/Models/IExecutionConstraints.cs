namespace AIKernel.Abstractions.Models;

/// <summary>
/// 実行時のハードウェアおよび計算リソース制約を表現するインターフェースです。
/// NPU/GPU環境など、動的基数やメモリ制約に対応した能力評価に用いられます。
/// </summary>
public interface IExecutionConstraints
{
    /// <summary>
    /// コンテキストの基数（Cardinality）を取得します。
    /// 例：シーケンス長、バッチサイズ、テンソルの次元数
    /// </summary>
    int ContextCardinality { get; }

    /// <summary>
    /// 利用可能なメモリ（MB）を取得します。
    /// </summary>
    long AvailableMemoryMb { get; }

    /// <summary>
    /// 実行対象のコンピュートデバイスタイプを取得します。
    /// 例："CPU", "GPU", "NPU", "TPU"
    /// </summary>
    string ComputeDeviceType { get; }

    /// <summary>
    /// 実行対象のコンピュートデバイス名を取得します。
    /// 例："NVIDIA_A100", "Google_TPUv4", "Qualcomm_Hexagon"
    /// </summary>
    string ComputeDeviceName { get; }

    /// <summary>
    /// 最大遅延制約（ミリ秒）を取得します。
    /// null の場合は制約なし。
    /// </summary>
    int? MaxLatencyMs { get; }

    /// <summary>
    /// 量子化レベルを取得します。
    /// 例："FP32", "FP16", "INT8", "INT4"
    /// </summary>
    string QuantizationLevel { get; }

    /// <summary>
    /// 利用可能な計算スループット（TFLOPS）を取得します。
    /// 概算値；実際の性能はモデルと操作に依存します。
    /// </summary>
    float ComputeThroughputTflops { get; }

    /// <summary>
    /// バッチサイズを取得します。
    /// 0 または負の値は可変バッチサイズを示唆します。
    /// </summary>
    int BatchSize { get; }

    /// <summary>
    /// シーケンス長を取得します。
    /// </summary>
    int SequenceLength { get; }

    /// <summary>
    /// 物理基数（パディング後の基数）を取得します。
    /// 多くのNPUは2のべき乗やアライメント倍数を要求します。
    /// </summary>
    int PhysicalCardinality { get; }

    /// <summary>
    /// 追加のコンテキスト情報をカスタムキーで取得します。
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>値、キーが存在しない場合は null</returns>
    object? GetContextValue(string key);

    /// <summary>
    /// すべてのコンテキスト情報を取得します。
    /// </summary>
    /// <returns>キー-値ペアの読み取り専用辞書</returns>
    IReadOnlyDictionary<string, object> GetAllContextValues();
}
