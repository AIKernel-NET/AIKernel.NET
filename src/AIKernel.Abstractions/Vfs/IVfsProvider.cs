namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs（Virtual File System）プロバイダーのインターフェースを定義します。
/// 外部データソースへの統一的なアクセスを提供します。
/// JA: IVfsProvider の公開契約を定義します。
/// </summary>
/// <remarks>
/// UC-08（コンテキストスナップショットと永続化）および UC-18（Chat Persistence）で利用される永続化境界です。
/// </remarks>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsProvider']" />
public interface IVfsProvider
{
    /// <summary>
    /// プロバイダーの識別子を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string ProviderId { get; }

    /// <summary>
    /// プロバイダーの名前を取得します。
    /// JA: OpenSessionAsync 操作を実行します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// セッションを開きます。
    /// JA: OpenSessionAsync 操作を実行します。
    /// </summary>
    /// <param name="credentials">認証情報 JA: credentials パラメーターです。</param>
    /// <returns>Vfs セッション JA: 結果を返します。</returns>
    Task<IVfsSession> OpenSessionAsync(IVfsCredentials credentials);

    /// <summary>
    /// プロバイダーが利用可能かどうかを確認します。
    /// JA: IsAvailableAsync 操作を実行します。
    /// </summary>
    /// <returns>利用可能な場合は true。 JA: 結果を返します。</returns>
    Task<bool> IsAvailableAsync();

    /// <summary>
    /// プロバイダーのヘルスチェックを実行します。
    /// JA: GetHealthAsync 操作を実行します。
    /// </summary>
    /// <returns>ヘルスチェック結果 JA: 結果を返します。</returns>
    Task<VfsProviderHealth> GetHealthAsync();
}

