namespace AIKernel.Contracts;

/// <summary>
/// Kernel コンテキスト契約を定義します。
/// カーネルレベルの実行コンテキスト管理を行います。
/// EN: UC-14（Kernel Module による動的構成）
/// [EN] Documents this public package API member. [JA] IKernelContextContract の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IKernelContextContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IKernelContextContract']" />
public interface IKernelContextContract
{
    /// <summary>
    /// EN: コンテキストの一意識別子を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string ContextId { get; }

    /// <summary>
    /// EN: コンテキスト作成時刻を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// EN: コンテキストの有効期限を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    DateTime ExpiresAt { get; }

    /// <summary>
    /// EN: リクエスト元の識別子を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string RequesterId { get; }

    /// <summary>
    /// EN: コンテキストの状態を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string State { get; }

    /// <summary>
    /// EN: コンテキストに関連するメタデータを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, object>? Metadata { get; }
}

