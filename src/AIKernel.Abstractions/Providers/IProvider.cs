namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: プロバイダーの識別情報を公開する capability interface です。
/// [EN] Documents this public package API member. [JA] IProviderIdentity の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderIdentity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderIdentity']" />
public interface IProviderIdentity
{
    /// <summary>
    /// EN: プロバイダーの一意識別子を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string ProviderId { get; }

    /// <summary>
    /// EN: プロバイダーの名前を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// EN: プロバイダーのバージョンを取得します。
    /// [EN] Documents this public package API member. [JA] IProviderCapabilitySource の公開契約を定義します。
    /// </summary>
    string Version { get; }
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: プロバイダーの能力情報を公開する capability interface です。
/// [EN] Documents this public package API member. [JA] IProviderCapabilitySource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCapabilitySource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCapabilitySource']" />
public interface IProviderCapabilitySource
{
    /// <summary>
    /// EN: プロバイダーの機能情報を取得します。
    /// [EN] Documents this public package API member. [JA] GetCapabilities 操作を実行します。
    /// </summary>
    IProviderCapabilities GetCapabilities();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: プロバイダーの可用性を確認する capability interface です。
/// [EN] Documents this public package API member. [JA] IProviderAvailabilityProbe の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderAvailabilityProbe']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderAvailabilityProbe']" />
public interface IProviderAvailabilityProbe
{
    /// <summary>
    /// EN: プロバイダーが利用可能かどうかを確認します。
    /// [EN] Documents this public package API member. [JA] IsAvailableAsync 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 利用可能な場合は true 結果を返します。</returns>
    Task<bool> IsAvailableAsync();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: プロバイダーのライフサイクルを制御する capability interface です。
/// [EN] Documents this public package API member. [JA] IProviderLifecycle の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderLifecycle']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderLifecycle']" />
public interface IProviderLifecycle
{
    /// <summary>
    /// EN: プロバイダーを初期化します。
    /// [EN] Documents this public package API member. [JA] InitializeAsync 操作を実行します。
    /// </summary>
    Task InitializeAsync();

    /// <summary>
    /// EN: プロバイダーを終了します。
    /// [EN] Documents this public package API member. [JA] ShutdownAsync 操作を実行します。
    /// </summary>
    Task ShutdownAsync();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: プロバイダーのヘルスチェックを実行する capability interface です。
/// [EN] Documents this public package API member. [JA] IProviderHealthProbe の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderHealthProbe']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderHealthProbe']" />
public interface IProviderHealthProbe
{
    /// <summary>
    /// EN: プロバイダーのヘルスチェックを実行します。
    /// [EN] Documents this public package API member. [JA] GetHealthAsync 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] ヘルスチェック結果 結果を返します。</returns>
    Task<ProviderHealthStatus> GetHealthAsync();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// AIKernel のプロバイダーを定義する互換合成インターフェースです。
/// EN: 外部サービスやリソースへのアクセスを提供する基盤です。
/// [EN] Documents this public package API member. [JA] IProvider の公開契約を定義します。
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
