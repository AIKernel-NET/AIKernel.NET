namespace AIKernel.Abstractions.Events;

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// 監査イベントを定義します。
/// セキュリティ監査とアクティビティログの基盤です。
/// </summary>
public interface IAuditEvent
{
    /// <summary>
    /// 監査イベントの一意識別子を取得します。
    /// </summary>
    string EventId { get; }

    /// <summary>
    /// イベントの種類を取得します。
    /// </summary>
    string EventType { get; }

    /// <summary>
    /// イベントが発生した日時を取得します。
    /// </summary>
    DateTime Timestamp { get; }

    /// <summary>
    /// イベントの対象を取得します。
    /// </summary>
    string Subject { get; }

    /// <summary>
    /// イベントの内容を取得します。
    /// </summary>
    string Description { get; }

    /// <summary>
    /// イベントの重要度を取得します。
    /// </summary>
    AuditSeverity Severity { get; }

    /// <summary>
    /// イベントに関連するメタデータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, string> Metadata { get; }
}


