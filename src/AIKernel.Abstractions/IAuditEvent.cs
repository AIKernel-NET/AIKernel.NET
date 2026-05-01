namespace AIKernel.Abstractions;

/// <summary>
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
    IReadOnlyDictionary<string, object> Metadata { get; }
}

/// <summary>
/// 監査イベントの重要度を定義します。
/// </summary>
public enum AuditSeverity
{
    /// <summary>
    /// 情報レベル
    /// </summary>
    Information = 1,

    /// <summary>
    /// 警告レベル
    /// </summary>
    Warning = 2,

    /// <summary>
    /// エラーレベル
    /// </summary>
    Error = 3,

    /// <summary>
    /// 重大エラーレベル
    /// </summary>
    Critical = 4
}
