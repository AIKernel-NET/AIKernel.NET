namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs クエリのインターフェースを定義します。
/// データのクエリと検索を行うクエリ。
/// UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// JA: IVfsQuery の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsQuery']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsQuery']" />
public interface IVfsQuery
{
    /// <summary>
    /// クエリの種類を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string QueryType { get; }

    /// <summary>
    /// クエリのフィルター条件を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, string>? Filters { get; }

    /// <summary>
    /// クエリの結果制限を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    int? Limit { get; }

    /// <summary>
    /// クエリのオフセットを取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    int? Offset { get; }

    /// <summary>
    /// クエリの並べ替えを取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<VfsQuerySort>? Sort { get; }
}

