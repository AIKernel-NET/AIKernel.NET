namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Material Context を取得する capability interface です。
/// JA: IProviderMaterialRetriever の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderMaterialRetriever']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderMaterialRetriever']" />
public interface IProviderMaterialRetriever
{
    /// <summary>
    /// ソースからデータを取得します。
    /// JA: RetrieveAsync 操作を実行します。
    /// </summary>
    /// <param name="source">取得元ソース JA: source パラメーターです。</param>
    /// <param name="query">クエリ JA: query パラメーターです。</param>
    /// <returns>取得したデータ JA: 結果を返します。</returns>
    Task<MaterialContextDto> RetrieveAsync(string source, string query);

    /// <summary>
    /// 複数のソースから並列でデータを取得します。
    /// JA: RetrieveMultipleAsync 操作を実行します。
    /// </summary>
    /// <param name="sources">取得元ソースのリスト JA: sources パラメーターです。</param>
    /// <param name="query">クエリ JA: query パラメーターです。</param>
    /// <returns>取得したデータのリスト JA: 結果を返します。</returns>
    Task<IReadOnlyList<MaterialContextDto>> RetrieveMultipleAsync(IReadOnlyList<string> sources, string query);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Material Context をキャッシュから取得する capability interface です。
/// JA: IMaterialCacheReader の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IMaterialCacheReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IMaterialCacheReader']" />
public interface IMaterialCacheReader
{
    /// <summary>
    /// データをキャッシュから取得します。
    /// JA: GetFromCacheAsync 操作を実行します。
    /// </summary>
    /// <param name="cacheKey">キャッシュキー JA: cacheKey パラメーターです。</param>
    /// <returns>キャッシュされたデータ、存在しない場合は null JA: 結果を返します。</returns>
    Task<MaterialContextDto?> GetFromCacheAsync(string cacheKey);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Material Context をキャッシュに保存する capability interface です。
/// JA: IMaterialCacheWriter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IMaterialCacheWriter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IMaterialCacheWriter']" />
public interface IMaterialCacheWriter
{
    /// <summary>
    /// データをキャッシュに保存します。
    /// JA: CacheMaterialAsync 操作を実行します。
    /// </summary>
    /// <param name="cacheKey">キャッシュキー JA: cacheKey パラメーターです。</param>
    /// <param name="data">保存するデータ JA: data パラメーターです。</param>
    Task CacheMaterialAsync(string cacheKey, MaterialContextDto data);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Provider 登録を管理する capability interface です。
/// JA: IProviderRegistry の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderRegistry']" />
public interface IProviderRegistry
{
    /// <summary>
    /// プロバイダーを登録します。
    /// JA: RegisterProvider 操作を実行します。
    /// </summary>
    /// <param name="name">プロバイダー名 JA: name パラメーターです。</param>
    /// <param name="provider">プロバイダーインスタンス JA: provider パラメーターです。</param>
    void RegisterProvider(string name, IProvider provider);

    /// <summary>
    /// プロバイダーの登録を解除します。
    /// JA: UnregisterProvider 操作を実行します。
    /// </summary>
    /// <param name="name">プロバイダー名 JA: name パラメーターです。</param>
    bool UnregisterProvider(string name);

    /// <summary>
    /// 登録されているプロバイダーを取得します。
    /// JA: GetRegisteredProviders 操作を実行します。
    /// </summary>
    IReadOnlyList<string> GetRegisteredProviders();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーのルーティングと管理を行う互換合成インターフェースです。
/// Material Context の取得・変換・キャッシングを管理します。
/// JA: IProviderRouter の公開契約を定義します。
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
