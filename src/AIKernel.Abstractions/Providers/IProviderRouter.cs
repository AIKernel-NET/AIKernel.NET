namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: Material Context を取得する capability interface です。
/// EN: Documentation for public API. JA: IProviderMaterialRetriever の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderMaterialRetriever']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderMaterialRetriever']" />
public interface IProviderMaterialRetriever
{
    /// <summary>
    /// EN: ソースからデータを取得します。
    /// EN: Documentation for public API. JA: RetrieveAsync 操作を実行します。
    /// </summary>
    /// <param name="source">EN: Documentation for public API. JA: 取得元ソース source パラメーターです。</param>
    /// <param name="query">EN: Documentation for public API. JA: クエリ query パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 取得したデータ 結果を返します。</returns>
    Task<MaterialContextDto> RetrieveAsync(string source, string query);

    /// <summary>
    /// EN: 複数のソースから並列でデータを取得します。
    /// EN: Documentation for public API. JA: RetrieveMultipleAsync 操作を実行します。
    /// </summary>
    /// <param name="sources">EN: Documentation for public API. JA: 取得元ソースのリスト sources パラメーターです。</param>
    /// <param name="query">EN: Documentation for public API. JA: クエリ query パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 取得したデータのリスト 結果を返します。</returns>
    Task<IReadOnlyList<MaterialContextDto>> RetrieveMultipleAsync(IReadOnlyList<string> sources, string query);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: Material Context をキャッシュから取得する capability interface です。
/// EN: Documentation for public API. JA: IMaterialCacheReader の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IMaterialCacheReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IMaterialCacheReader']" />
public interface IMaterialCacheReader
{
    /// <summary>
    /// EN: データをキャッシュから取得します。
    /// EN: Documentation for public API. JA: GetFromCacheAsync 操作を実行します。
    /// </summary>
    /// <param name="cacheKey">EN: Documentation for public API. JA: キャッシュキー cacheKey パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: キャッシュされたデータ、存在しない場合は null 結果を返します。</returns>
    Task<MaterialContextDto?> GetFromCacheAsync(string cacheKey);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: Material Context をキャッシュに保存する capability interface です。
/// EN: Documentation for public API. JA: IMaterialCacheWriter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IMaterialCacheWriter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IMaterialCacheWriter']" />
public interface IMaterialCacheWriter
{
    /// <summary>
    /// EN: データをキャッシュに保存します。
    /// EN: Documentation for public API. JA: CacheMaterialAsync 操作を実行します。
    /// </summary>
    /// <param name="cacheKey">EN: Documentation for public API. JA: キャッシュキー cacheKey パラメーターです。</param>
    /// <param name="data">EN: Documentation for public API. JA: 保存するデータ data パラメーターです。</param>
    Task CacheMaterialAsync(string cacheKey, MaterialContextDto data);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: Provider 登録を管理する capability interface です。
/// EN: Documentation for public API. JA: IProviderRegistry の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderRegistry']" />
public interface IProviderRegistry
{
    /// <summary>
    /// EN: プロバイダーを登録します。
    /// EN: Documentation for public API. JA: RegisterProvider 操作を実行します。
    /// </summary>
    /// <param name="name">EN: Documentation for public API. JA: プロバイダー名 name パラメーターです。</param>
    /// <param name="provider">EN: Documentation for public API. JA: プロバイダーインスタンス provider パラメーターです。</param>
    void RegisterProvider(string name, IProvider provider);

    /// <summary>
    /// EN: プロバイダーの登録を解除します。
    /// EN: Documentation for public API. JA: UnregisterProvider 操作を実行します。
    /// </summary>
    /// <param name="name">EN: Documentation for public API. JA: プロバイダー名 name パラメーターです。</param>
    bool UnregisterProvider(string name);

    /// <summary>
    /// EN: 登録されているプロバイダーを取得します。
    /// EN: Documentation for public API. JA: GetRegisteredProviders 操作を実行します。
    /// </summary>
    IReadOnlyList<string> GetRegisteredProviders();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーのルーティングと管理を行う互換合成インターフェースです。
/// EN: Material Context の取得・変換・キャッシングを管理します。
/// EN: Documentation for public API. JA: IProviderRouter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderRouter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderRouter']" />
public interface IProviderRouter :
    IProviderMaterialRetriever,
    IMaterialCacheReader,
    IMaterialCacheWriter,
    IProviderRegistry
{
}
