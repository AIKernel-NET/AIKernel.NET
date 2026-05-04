namespace AIKernel.Abstractions;

using AIKernel.Abstractions.Models;

/// <summary>
/// プロバイダーの機能情報を定義します。
/// 静的な能力情報と、実行制約に基づく動的能力に対応します。
/// </summary>
public interface IProviderCapabilities
{
    /// <summary>
    /// サポートされている操作の一覧を取得します。
    /// </summary>
    IReadOnlyList<string> SupportedOperations { get; }

    /// <summary>
    /// サポートされているデータタイプの一覧を取得します。
    /// </summary>
    IReadOnlyList<string> SupportedDataTypes { get; }

    /// <summary>
    /// 最大同時接続数を取得します。
    /// </summary>
    int MaxConcurrentConnections { get; }

    /// <summary>
    /// レート制限情報を取得します。
    /// </summary>
    RateLimitInfo? RateLimit { get; }

    /// <summary>
    /// プロバイダー（特にモデル）の能力ベクトルを取得します。
    /// このベクトルはプロバイダー自体の「能力の履歴書」として機能します。
    /// 静的な環境での能力を表します。
    /// </summary>
    ModelCapacityVector Vector { get; }

    /// <summary>
    /// 実行制約に基づいて動的に能力ベクトルを取得します。
    /// NPU環境など、基数やメモリが非線形に性能に影響する場合に使用。
    /// </summary>
    /// <param name="constraints">実行制約条件</param>
    /// <returns>制約下での動的能力ベクトル</returns>
    IDictionary<string, float>? GetDynamicCapacities(IExecutionConstraints constraints);

    /// <summary>
    /// このプロバイダーの能力プロファイルを取得します。
    /// 基数による性能変化をプロファイル曲線として取得できます。
    /// </summary>
    /// <returns>能力プロファイル、有効でない場合は null</returns>
    ICapabilityProfile? GetCapabilityProfile();

    /// <summary>
    /// 特定の操作をサポートしているかどうかを確認します。
    /// </summary>
    /// <param name="operation">操作名</param>
    /// <returns>サポートしている場合は true</returns>
    bool SupportsOperation(string operation);

    /// <summary>
    /// 特定のデータタイプをサポートしているかどうかを確認します。
    /// </summary>
    /// <param name="dataType">データタイプ</param>
    /// <returns>サポートしている場合は true</returns>
    bool SupportsDataType(string dataType);

    /// <summary>
    /// 指定された量子化レベルをサポートしているか確認します。
    /// </summary>
    /// <param name="quantizationLevel">量子化レベル（例："INT8", "FP16", "FP32"）</param>
    /// <returns>サポートしている場合は true</returns>
    bool SupportsQuantization(string quantizationLevel);
}
