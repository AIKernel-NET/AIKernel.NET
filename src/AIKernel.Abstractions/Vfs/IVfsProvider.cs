namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs（Virtual File System）プロバイダーのインターフェースを定義します。
/// EN: 外部データソースへの統一的なアクセスを提供します。
/// EN: Documentation for public API. JA: IVfsProvider の公開契約を定義します。
/// </summary>
/// <remarks>
/// UC-08（コンテキストスナップショットと永続化）および UC-18（Chat Persistence）で利用される永続化境界です。
/// </remarks>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsProvider']" />
public interface IVfsProvider
{
    /// <summary>
    /// EN: プロバイダーの識別子を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string ProviderId { get; }

    /// <summary>
    /// EN: プロバイダーの名前を取得します。
    /// EN: Documentation for public API. JA: OpenSessionAsync 操作を実行します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// EN: セッションを開きます。
    /// EN: Documentation for public API. JA: OpenSessionAsync 操作を実行します。
    /// </summary>
    /// <param name="credentials">EN: Documentation for public API. JA: 認証情報 credentials パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: Vfs セッション 結果を返します。</returns>
    Task<IVfsSession> OpenSessionAsync(IVfsCredentials credentials);

    /// <summary>
    /// EN: プロバイダーが利用可能かどうかを確認します。
    /// EN: Documentation for public API. JA: IsAvailableAsync 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: 利用可能な場合は true。 結果を返します。</returns>
    Task<bool> IsAvailableAsync();

    /// <summary>
    /// EN: プロバイダーのヘルスチェックを実行します。
    /// EN: Documentation for public API. JA: GetHealthAsync 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: ヘルスチェック結果 結果を返します。</returns>
    Task<VfsProviderHealth> GetHealthAsync();
}

