namespace AIKernel.Abstractions.Models;

/// <summary>
/// 実行直前コンテキストの制約を表現するインターフェースです。
/// SGS-007 Dynamic Scope Binding の `allowed_tools` / `max_token_budget` / `scopes` と
/// 実行環境制約を統合して表現します。
/// </summary>
public interface IExecutionConstraints
{
    /// <summary>
    /// コンテキストの基数（Cardinality）を取得します。
    /// 例：シーケンス長、バッチサイズ、テンソルの次元数
    /// </summary>
    int ContextCardinality { get; }

    /// <summary>
    /// SGS-007: `allowed_tools`
    /// 許可されたツール ID の一覧。
    /// </summary>
    IReadOnlyList<string> AllowedTools { get; }

    /// <summary>
    /// SGS-007: `scopes`
    /// 実行時に有効なスコープ一覧。
    /// </summary>
    IReadOnlyList<string> Scopes { get; }

    /// <summary>
    /// SGS-007: `max_token_budget`
    /// 実行時に許可された最大トークン予算。
    /// </summary>
    int MaxTokenBudget { get; }

    /// <summary>
    /// 利用可能なメモリ（MB）。
    /// </summary>
    long AvailableMemoryMb { get; }

    /// <summary>
    /// 最大遅延制約（ミリ秒）。null の場合は制約なし。
    /// </summary>
    int? MaxLatencyMs { get; }

    /// <summary>
    /// 実行対象のコンピュートデバイスタイプ。例: "CPU", "GPU", "NPU", "TPU"。
    /// </summary>
    string ComputeDeviceType { get; }

    /// <summary>
    /// 実行対象のコンピュートデバイス名。例: "NVIDIA_A100"。
    /// </summary>
    string ComputeDeviceName { get; }

    /// <summary>
    /// 量子化レベル。例: "FP32", "FP16", "INT8", "INT4"。
    /// </summary>
    string QuantizationLevel { get; }

    /// <summary>
    /// 利用可能な計算スループット（TFLOPS）。
    /// </summary>
    float ComputeThroughputTflops { get; }

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
