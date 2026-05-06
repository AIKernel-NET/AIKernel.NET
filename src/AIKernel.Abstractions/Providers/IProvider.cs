namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// AIKernel のプロバイダーインターフェースを定義します。
/// 外部サービスやリソースへのアクセスを提供する基盤です。
/// </summary>
public interface IProvider
{
    /// <summary>
    /// プロバイダーの一意識別子を取得します。
    /// </summary>
    string ProviderId { get; }

    /// <summary>
    /// プロバイダーの名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// プロバイダーのバージョンを取得します。
    /// </summary>
    string Version { get; }

    /// <summary>
    /// プロバイダーの機能情報を取得します。
    /// </summary>
    IProviderCapabilities GetCapabilities();

    /// <summary>
    /// プロバイダーが利用可能かどうかを確認します。
    /// </summary>
    /// <returns>利用可能な場合は true</returns>
    Task<bool> IsAvailableAsync();

    /// <summary>
    /// プロバイダーを初期化します。
    /// </summary>
    Task InitializeAsync();

    /// <summary>
    /// プロバイダーを終了します。
    /// </summary>
    Task ShutdownAsync();

    /// <summary>
    /// プロバイダーのヘルスチェックを実行します。
    /// </summary>
    /// <returns>ヘルスチェック結果</returns>
    Task<ProviderHealthStatus> GetHealthAsync();
}


