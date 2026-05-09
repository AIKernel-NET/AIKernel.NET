namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーの識別情報を公開する capability interface です。
/// </summary>
public interface IProviderIdentity
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
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーの能力情報を公開する capability interface です。
/// </summary>
public interface IProviderCapabilitySource
{
    /// <summary>
    /// プロバイダーの機能情報を取得します。
    /// </summary>
    IProviderCapabilities GetCapabilities();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーの可用性を確認する capability interface です。
/// </summary>
public interface IProviderAvailabilityProbe
{
    /// <summary>
    /// プロバイダーが利用可能かどうかを確認します。
    /// </summary>
    /// <returns>利用可能な場合は true</returns>
    Task<bool> IsAvailableAsync();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーのライフサイクルを制御する capability interface です。
/// </summary>
public interface IProviderLifecycle
{
    /// <summary>
    /// プロバイダーを初期化します。
    /// </summary>
    Task InitializeAsync();

    /// <summary>
    /// プロバイダーを終了します。
    /// </summary>
    Task ShutdownAsync();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーのヘルスチェックを実行する capability interface です。
/// </summary>
public interface IProviderHealthProbe
{
    /// <summary>
    /// プロバイダーのヘルスチェックを実行します。
    /// </summary>
    /// <returns>ヘルスチェック結果</returns>
    Task<ProviderHealthStatus> GetHealthAsync();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// AIKernel のプロバイダーを定義する互換合成インターフェースです。
/// 外部サービスやリソースへのアクセスを提供する基盤です。
/// </summary>
public interface IProvider :
    IProviderIdentity,
    IProviderCapabilitySource,
    IProviderAvailabilityProbe,
    IProviderLifecycle,
    IProviderHealthProbe
{
}
