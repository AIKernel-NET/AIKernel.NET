namespace AIKernel.Abstractions.Providers;

using AIKernel.Abstractions.Models;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Provider の静的な操作・データ種別 capability を公開します。
/// </summary>
public interface IProviderOperationCapabilities
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
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Provider の接続・レート制限 capability を公開します。
/// </summary>
public interface IProviderConnectionCapabilities
{
    /// <summary>
    /// 最大同時接続数を取得します。
    /// </summary>
    int MaxConcurrentConnections { get; }

    /// <summary>
    /// レート制限情報を取得します。
    /// </summary>
    RateLimitInfo? RateLimit { get; }
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Provider の静的能力ベクトルを公開します。
/// </summary>
public interface IProviderCapacityVectorSource
{
    /// <summary>
    /// プロバイダー（特にモデル）の能力ベクトルを取得します。
    /// このベクトルはプロバイダー自体の「能力の履歴書」として機能します。
    /// 静的な環境での能力を表します。
    /// </summary>
    ModelCapacityVector Vector { get; }
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 実行制約に基づく動的能力を公開します。
/// </summary>
public interface IDynamicProviderCapacitySource
{
    /// <summary>
    /// 実行制約に基づいて動的に能力ベクトルを取得します。
    /// NPU環境など、基数やメモリが非線形に性能に影響する場合に使用。
    /// </summary>
    /// <param name="constraints">実行制約条件</param>
    /// <returns>制約下での動的能力ベクトル</returns>
    IDictionary<string, float>? GetDynamicCapacities(IExecutionConstraints constraints);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Provider の能力プロファイルを公開します。
/// </summary>
public interface IProviderProfileSource
{
    /// <summary>
    /// このプロバイダーの能力プロファイルを取得します。
    /// 基数による性能変化をプロファイル曲線として取得できます。
    /// </summary>
    /// <returns>能力プロファイル、有効でない場合は null</returns>
    ICapabilityProfile? GetCapabilityProfile();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 量子化サポート情報を公開します。
/// </summary>
public interface IQuantizationSupport
{
    /// <summary>
    /// 指定された量子化レベルをサポートしているか確認します。
    /// </summary>
    /// <param name="quantizationLevel">量子化レベル（例："INT8", "FP16", "FP32"）</param>
    /// <returns>サポートしている場合は true</returns>
    bool SupportsQuantization(string quantizationLevel);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーの機能情報を定義する互換合成インターフェースです。
/// 静的な能力情報と、実行制約に基づく動的能力に対応します。
/// </summary>
public interface IProviderCapabilities :
    IProviderOperationCapabilities,
    IProviderConnectionCapabilities,
    IProviderCapacityVectorSource,
    IDynamicProviderCapacitySource,
    IProviderProfileSource,
    IQuantizationSupport
{
}
