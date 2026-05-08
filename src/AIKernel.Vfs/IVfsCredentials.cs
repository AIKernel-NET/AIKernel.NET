namespace AIKernel.VFS;

/// <summary>
/// VFS 認証情報を定義します。
/// UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// </summary>
public interface IVfsCredentials
{
    /// <summary>
    /// ユーザー名を取得します。
    /// </summary>
    string? Username { get; }

    /// <summary>
    /// API キーを取得します。
    /// </summary>
    string? ApiKey { get; }

    /// <summary>
    /// トークンを取得します。
    /// </summary>
    string? Token { get; }

    /// <summary>
    /// その他の認証パラメータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, object>? Parameters { get; }
}

