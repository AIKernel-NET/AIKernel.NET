namespace AIKernel.Vfs;

/// <summary>
/// Vfs 認証情報を定義します。
/// EN: UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// EN: Documentation for public API. JA: IVfsCredentials の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsCredentials']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsCredentials']" />
public interface IVfsCredentials
{
    /// <summary>
    /// EN: ユーザー名を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string? Username { get; }

    /// <summary>
    /// EN: API キーを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string? ApiKey { get; }

    /// <summary>
    /// EN: トークンを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string? Token { get; }

    /// <summary>
    /// EN: その他の認証パラメータを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, object>? Parameters { get; }
}

