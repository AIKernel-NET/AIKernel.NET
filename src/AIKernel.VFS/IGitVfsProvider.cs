namespace AIKernel.VFS;

/// <summary>
/// Git リポジトリへの VFS アクセスを提供するインターフェース。
/// </summary>
public interface IGitVfsProvider : IVfsProvider
{
    /// <summary>
    /// Git リポジトリをクローンします。
    /// </summary>
    /// <param name="repositoryUrl">リポジトリ URL</param>
    /// <param name="branch">ブランチ名</param>
    Task<IVfsSession> CloneAsync(string repositoryUrl, string branch = "main");

    /// <summary>
    /// 特定のコミットをチェックアウトします。
    /// </summary>
    /// <param name="session">VFS セッション</param>
    /// <param name="commitHash">コミットハッシュ</param>
    Task CheckoutCommitAsync(IVfsSession session, string commitHash);
}
