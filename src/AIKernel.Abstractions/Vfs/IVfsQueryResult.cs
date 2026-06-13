namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs クエリ結果のインターフェースを定義します。
/// UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// JA: IVfsQueryResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsQueryResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsQueryResult']" />
public interface IVfsQueryResult
{
    /// <summary>
    /// クエリ実行が成功したかどうかを取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// 取得された行数を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    int RowCount { get; }

    /// <summary>
    /// クエリ結果の列名を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<string> ColumnNames { get; }

    /// <summary>
    /// クエリ結果の行を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<VfsQueryRow> Rows { get; }

    /// <summary>
    /// エラーメッセージを取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string? ErrorMessage { get; }
}

