namespace AIKernel.Abstractions;

using AIKernel.Abstractions.Models;

/// <summary>
/// プロバイダーの機能情報を定義します。
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
    /// </summary>
    ModelCapacityVector Vector { get; }

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
