namespace AIKernel.Contracts;

/// <summary>
/// 監査イベント契約を定義します。
/// セキュリティイベントのログ記録と追跡を行います。
/// UC-24（監査イベント出力）
/// JA: IAuditEventContract の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IAuditEventContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IAuditEventContract']" />
public interface IAuditEventContract
{
    /// <summary>
    /// 監査イベントの一意識別子を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string EventId { get; }

    /// <summary>
    /// イベント発生の日時を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    DateTime EventTime { get; }

    /// <summary>
    /// イベントのアクター（実行者）を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string Actor { get; }

    /// <summary>
    /// イベントのアクション（実行内容）を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string Action { get; }

    /// <summary>
    /// イベントのリソース（対象）を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string Resource { get; }

    /// <summary>
    /// イベントの結果を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string Result { get; }

    /// <summary>
    /// イベントに関連するメタデータを取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, object>? Metadata { get; }
}

