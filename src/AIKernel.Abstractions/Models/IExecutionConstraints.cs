namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// 実行直前コンテキストの制約を表現するインターフェースです。
/// SGS-007 Dynamic Scope Binding の `allowed_tools` / `max_token_budget` / `scopes` と
/// EN: 実行環境制約を統合して表現します。
/// EN: Documentation for public API. JA: IExecutionConstraints の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IExecutionConstraints']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IExecutionConstraints']" />
public interface IExecutionConstraints
{
    /// <summary>
    /// コンテキストの基数（Cardinality）を取得します。
    /// EN: 例：シーケンス長、バッチサイズ、テンソルの次元数
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    int ContextCardinality { get; }

    /// <summary>
    /// SGS-007: `allowed_tools`
    /// EN: 許可されたツール ID の一覧。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<string> AllowedTools { get; }

    /// <summary>
    /// SGS-007: `scopes`
    /// EN: 実行時に有効なスコープ一覧。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<string> Scopes { get; }

    /// <summary>
    /// SGS-007: `max_token_budget`
    /// EN: 実行時に許可された最大トークン予算。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    int MaxTokenBudget { get; }

    /// <summary>
    /// EN: 利用可能なメモリ（MB）。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    long AvailableMemoryMb { get; }

    /// <summary>
    /// EN: 最大遅延制約（ミリ秒）。null の場合は制約なし。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    int? MaxLatencyMs { get; }

    /// <summary>
    /// EN: 実行対象のコンピュートデバイスタイプ。例: "CPU", "GPU", "NPU", "TPU"。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string ComputeDeviceType { get; }

    /// <summary>
    /// EN: 実行対象のコンピュートデバイス名。例: "NVIDIA_A100"。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string ComputeDeviceName { get; }

    /// <summary>
    /// EN: 量子化レベル。例: "FP32", "FP16", "INT8", "INT4"。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string QuantizationLevel { get; }

    /// <summary>
    /// EN: 利用可能な計算スループット（TFLOPS）。
    /// EN: Documentation for public API. JA: GetContextValue 操作を実行します。
    /// </summary>
    float ComputeThroughputTflops { get; }

    /// <summary>
    /// EN: 追加のコンテキスト情報をカスタムキーで取得します。
    /// EN: Documentation for public API. JA: GetContextValue 操作を実行します。
    /// </summary>
    /// <param name="key">EN: Documentation for public API. JA: キー key パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 値、キーが存在しない場合は null 結果を返します。</returns>
    string? GetContextValue(string key);

    /// <summary>
    /// EN: すべてのコンテキスト情報を取得します。
    /// EN: Documentation for public API. JA: GetAllContextValues 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: キー-値ペアの読み取り専用辞書 結果を返します。</returns>
    IReadOnlyDictionary<string, string> GetAllContextValues();
}

