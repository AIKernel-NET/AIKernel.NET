namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs クエリ結果のインターフェースを定義します。
/// UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// </summary>
public interface IVfsQueryResult
{
    /// <summary>
    /// クエリ実行が成功したかどうかを取得します。
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// 取得された行数を取得します。
    /// </summary>
    int RowCount { get; }

    /// <summary>
    /// クエリ結果の列名を取得します。
    /// </summary>
    IReadOnlyList<string> ColumnNames { get; }

    /// <summary>
    /// クエリ結果の行を取得します。
    /// </summary>
    IReadOnlyList<VfsQueryRow> Rows { get; }

    /// <summary>
    /// エラーメッセージを取得します。
    /// </summary>
    string? ErrorMessage { get; }
}

