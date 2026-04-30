using AIKernel.Dtos;
using AIKernel.Enums;

namespace AIKernel.Abstractions;

/// <summary>
/// プロバイダーのルーティングと管理を行うインターフェースを定義します。
/// Material Context の取得・変換・キャッシングを管理します。
/// </summary>
public interface IProviderRouter
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

    /// <summary>
    /// データをキャッシュから取得します。
    /// </summary>
    /// <param name="cacheKey">キャッシュキー</param>
    /// <returns>キャッシュされたデータ、存在しない場合は null</returns>
    Task<MaterialContextDto?> GetFromCacheAsync(string cacheKey);

    /// <summary>
    /// データをキャッシュに保存します。
    /// </summary>
    /// <param name="cacheKey">キャッシュキー</param>
    /// <param name="data">保存するデータ</param>
    Task CacheMaterialAsync(string cacheKey, MaterialContextDto data);

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
/// 個別のプロバイダーを定義します。
/// </summary>
public interface IProvider
{
    /// <summary>
    /// プロバイダーの名前を取得します。
    /// </summary>
    string GetName();

    /// <summary>
    /// データを非同期に取得します。
    /// </summary>
    /// <param name="query">クエリ</param>
    /// <returns>取得したデータ</returns>
    Task<string> GetDataAsync(string query);

    /// <summary>
    /// プロバイダーが利用可能かどうかを確認します。
    /// </summary>
    Task<bool> IsAvailableAsync();

    /// <summary>
    /// プロバイダーの優先度を取得します。
    /// 値が大きいほど優先度が高い。
    /// </summary>
    int GetPriority();
}
