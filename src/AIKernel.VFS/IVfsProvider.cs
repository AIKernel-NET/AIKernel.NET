namespace AIKernel.VFS;

/// <summary>
/// VFS（Virtual File System）プロバイダーのインターフェースを定義します。
/// 外部データソースへの統一的なアクセスを提供します。
/// </summary>
public interface IVfsProvider
{
    /// <summary>
    /// プロバイダーの識別子を取得します。
    /// </summary>
    string ProviderId { get; }

    /// <summary>
    /// プロバイダーの名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// セッションを開きます。
    /// </summary>
    /// <param name="credentials">認証情報</param>
    /// <returns>VFS セッション</returns>
    Task<IVfsSession> OpenSessionAsync(IVfsCredentials credentials);

    /// <summary>
    /// プロバイダーが利用可能かどうかを確認します。
    /// </summary>
    Task<bool> IsAvailableAsync();

    /// <summary>
    /// プロバイダーのヘルスチェックを実行します。
    /// </summary>
    Task<VfsProviderHealth> GetHealthAsync();
}
