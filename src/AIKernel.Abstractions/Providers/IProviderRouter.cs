namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Material Context を取得する capability interface です。
/// </summary>
public interface IProviderMaterialRetriever
{
    /// <summary>
    /// ソースからデータを取得します。
    /// </summary>
    /// <param name="source">取得元ソース</param>
    /// <param name="query">クエリ</param>
    /// <returns>取得したデータ</returns>
    Task<MaterialContextDto> RetrieveAsync(string source, string query);

    /// <summary>
    /// 複数のソースから並列でデータを取得します。
    /// </summary>
    /// <param name="sources">取得元ソースのリスト</param>
    /// <param name="query">クエリ</param>
    /// <returns>取得したデータのリスト</returns>
    Task<IReadOnlyList<MaterialContextDto>> RetrieveMultipleAsync(IReadOnlyList<string> sources, string query);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Material Context をキャッシュから取得する capability interface です。
/// </summary>
public interface IMaterialCacheReader
{
    /// <summary>
    /// データをキャッシュから取得します。
    /// </summary>
    /// <param name="cacheKey">キャッシュキー</param>
    /// <returns>キャッシュされたデータ、存在しない場合は null</returns>
    Task<MaterialContextDto?> GetFromCacheAsync(string cacheKey);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Material Context をキャッシュに保存する capability interface です。
/// </summary>
public interface IMaterialCacheWriter
{
    /// <summary>
    /// データをキャッシュに保存します。
    /// </summary>
    /// <param name="cacheKey">キャッシュキー</param>
    /// <param name="data">保存するデータ</param>
    Task CacheMaterialAsync(string cacheKey, MaterialContextDto data);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// Provider 登録を管理する capability interface です。
/// </summary>
public interface IProviderRegistry
{
    /// <summary>
    /// プロバイダーを登録します。
    /// </summary>
    /// <param name="name">プロバイダー名</param>
    /// <param name="provider">プロバイダーインスタンス</param>
    void RegisterProvider(string name, IProvider provider);

    /// <summary>
    /// プロバイダーの登録を解除します。
    /// </summary>
    /// <param name="name">プロバイダー名</param>
    bool UnregisterProvider(string name);

    /// <summary>
    /// 登録されているプロバイダーを取得します。
    /// </summary>
    IReadOnlyList<string> GetRegisteredProviders();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーのルーティングと管理を行う互換合成インターフェースです。
/// Material Context の取得・変換・キャッシングを管理します。
/// </summary>
public interface IProviderRouter :
    IProviderMaterialRetriever,
    IMaterialCacheReader,
    IMaterialCacheWriter,
    IProviderRegistry
{
}
