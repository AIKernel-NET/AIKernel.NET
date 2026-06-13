namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーの識別情報を公開する capability interface です。
/// JA: IProviderIdentity の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderIdentity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderIdentity']" />
public interface IProviderIdentity
{
    /// <summary>
    /// プロバイダーの一意識別子を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string ProviderId { get; }

    /// <summary>
    /// プロバイダーの名前を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// プロバイダーのバージョンを取得します。
    /// JA: IProviderCapabilitySource の公開契約を定義します。
    /// </summary>
    string Version { get; }
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーの能力情報を公開する capability interface です。
/// JA: IProviderCapabilitySource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCapabilitySource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCapabilitySource']" />
public interface IProviderCapabilitySource
{
    /// <summary>
    /// プロバイダーの機能情報を取得します。
    /// JA: GetCapabilities 操作を実行します。
    /// </summary>
    IProviderCapabilities GetCapabilities();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーの可用性を確認する capability interface です。
/// JA: IProviderAvailabilityProbe の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderAvailabilityProbe']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderAvailabilityProbe']" />
public interface IProviderAvailabilityProbe
{
    /// <summary>
    /// プロバイダーが利用可能かどうかを確認します。
    /// JA: IsAvailableAsync 操作を実行します。
    /// </summary>
    /// <returns>利用可能な場合は true JA: 結果を返します。</returns>
    Task<bool> IsAvailableAsync();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーのライフサイクルを制御する capability interface です。
/// JA: IProviderLifecycle の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderLifecycle']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderLifecycle']" />
public interface IProviderLifecycle
{
    /// <summary>
    /// プロバイダーを初期化します。
    /// JA: InitializeAsync 操作を実行します。
    /// </summary>
    Task InitializeAsync();

    /// <summary>
    /// プロバイダーを終了します。
    /// JA: ShutdownAsync 操作を実行します。
    /// </summary>
    Task ShutdownAsync();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーのヘルスチェックを実行する capability interface です。
/// JA: IProviderHealthProbe の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderHealthProbe']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderHealthProbe']" />
public interface IProviderHealthProbe
{
    /// <summary>
    /// プロバイダーのヘルスチェックを実行します。
    /// JA: GetHealthAsync 操作を実行します。
    /// </summary>
    /// <returns>ヘルスチェック結果 JA: 結果を返します。</returns>
    Task<ProviderHealthStatus> GetHealthAsync();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// AIKernel のプロバイダーを定義する互換合成インターフェースです。
/// 外部サービスやリソースへのアクセスを提供する基盤です。
/// JA: IProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProvider']" />
public interface IProvider :
    IProviderIdentity,
    IProviderCapabilitySource,
    IProviderAvailabilityProbe,
    IProviderLifecycle,
    IProviderHealthProbe
{
}
