namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs クエリのインターフェースを定義します。
/// データのクエリと検索を行うクエリ。
/// EN: UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// EN: Documentation for public API. JA: IVfsQuery の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsQuery']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsQuery']" />
public interface IVfsQuery
{
    /// <summary>
    /// EN: クエリの種類を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string QueryType { get; }

    /// <summary>
    /// EN: クエリのフィルター条件を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, string>? Filters { get; }

    /// <summary>
    /// EN: クエリの結果制限を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    int? Limit { get; }

    /// <summary>
    /// EN: クエリのオフセットを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    int? Offset { get; }

    /// <summary>
    /// EN: クエリの並べ替えを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<VfsQuerySort>? Sort { get; }
}

