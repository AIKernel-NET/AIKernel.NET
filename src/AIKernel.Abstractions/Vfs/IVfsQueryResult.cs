namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs クエリ結果のインターフェースを定義します。
/// EN: UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// [EN] Documents this public package API member. [JA] IVfsQueryResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsQueryResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsQueryResult']" />
public interface IVfsQueryResult
{
    /// <summary>
    /// EN: クエリ実行が成功したかどうかを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// EN: 取得された行数を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    int RowCount { get; }

    /// <summary>
    /// EN: クエリ結果の列名を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<string> ColumnNames { get; }

    /// <summary>
    /// EN: クエリ結果の行を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<VfsQueryRow> Rows { get; }

    /// <summary>
    /// EN: エラーメッセージを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string? ErrorMessage { get; }
}

