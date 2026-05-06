namespace AIKernel.Contracts;

/// <summary>
/// 監査イベント契約を定義します。
/// セキュリティイベントのログ記録と追跡を行います。
/// UC-24（監査イベント出力）
/// </summary>
public interface IAuditEventContract
{
    /// <summary>
    /// 監査イベントの一意識別子を取得します。
    /// </summary>
    string EventId { get; }

    /// <summary>
    /// イベント発生の日時を取得します。
    /// </summary>
    DateTime EventTime { get; }

    /// <summary>
    /// イベントのアクター（実行者）を取得します。
    /// </summary>
    string Actor { get; }

    /// <summary>
    /// イベントのアクション（実行内容）を取得します。
    /// </summary>
    string Action { get; }

    /// <summary>
    /// イベントのリソース（対象）を取得します。
    /// </summary>
    string Resource { get; }

    /// <summary>
    /// イベントの結果を取得します。
    /// </summary>
    string Result { get; }

    /// <summary>
    /// イベントに関連するメタデータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, object>? Metadata { get; }
}

