namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs クエリのインターフェースを定義します。
/// データのクエリと検索を行うクエリ。
/// UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// </summary>
public interface IVfsQuery
{
    /// <summary>
    /// クエリの種類を取得します。
    /// </summary>
    string QueryType { get; }

    /// <summary>
    /// クエリのフィルター条件を取得します。
    /// </summary>
    IReadOnlyDictionary<string, string>? Filters { get; }

    /// <summary>
    /// クエリの結果制限を取得します。
    /// </summary>
    int? Limit { get; }

    /// <summary>
    /// クエリのオフセットを取得します。
    /// </summary>
    int? Offset { get; }

    /// <summary>
    /// クエリの並べ替えを取得します。
    /// </summary>
    IReadOnlyList<VfsQuerySort>? Sort { get; }
}

