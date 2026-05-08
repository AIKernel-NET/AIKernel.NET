namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs（Virtual File System）プロバイダーのインターフェースを定義します。
/// 外部データソースへの統一的なアクセスを提供します。
/// </summary>
/// <remarks>
/// UC-08（コンテキストスナップショットと永続化）および UC-18（Chat Persistence）で利用される永続化境界です。
/// </remarks>
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
    /// <returns>Vfs セッション</returns>
    /// <exception cref="ArgumentNullException">credentials が null の場合にスローされます。</exception>
    /// <exception cref="UnauthorizedAccessException">認証に失敗した場合にスローされます。</exception>
    Task<IVfsSession> OpenSessionAsync(IVfsCredentials credentials);

    /// <summary>
    /// プロバイダーが利用可能かどうかを確認します。
    /// </summary>
    /// <returns>利用可能な場合は true。</returns>
    Task<bool> IsAvailableAsync();

    /// <summary>
    /// プロバイダーのヘルスチェックを実行します。
    /// </summary>
    /// <returns>ヘルスチェック結果</returns>
    Task<VfsProviderHealth> GetHealthAsync();
}

