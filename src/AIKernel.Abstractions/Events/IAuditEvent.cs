namespace AIKernel.Abstractions.Events;

/// <summary>
/// UC-20/UC-24/UC-25 に基づく契約です。
/// 監査イベントを定義します。
/// EN: セキュリティ監査とアクティビティログの基盤です。
/// [EN] Documents this public package API member. [JA] IAuditEvent の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IAuditEvent']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IAuditEvent']" />
public interface IAuditEvent
{
    /// <summary>
    /// EN: 監査イベントの一意識別子を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string EventId { get; }

    /// <summary>
    /// EN: イベントの種類を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string EventType { get; }

    /// <summary>
    /// EN: イベントが発生した日時を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    DateTime Timestamp { get; }

    /// <summary>
    /// EN: イベントの対象を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string Subject { get; }

    /// <summary>
    /// EN: イベントの内容を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string Description { get; }

    /// <summary>
    /// EN: イベントの重要度を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    AuditSeverity Severity { get; }

    /// <summary>
    /// EN: イベントに関連するメタデータを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, string> Metadata { get; }
}


