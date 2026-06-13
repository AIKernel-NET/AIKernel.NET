namespace AIKernel.Contracts;

/// <summary>
/// Kernel コンテキスト契約を定義します。
/// カーネルレベルの実行コンテキスト管理を行います。
/// UC-14（Kernel Module による動的構成）
/// JA: IKernelContextContract の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IKernelContextContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IKernelContextContract']" />
public interface IKernelContextContract
{
    /// <summary>
    /// コンテキストの一意識別子を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string ContextId { get; }

    /// <summary>
    /// コンテキスト作成時刻を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// コンテキストの有効期限を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    DateTime ExpiresAt { get; }

    /// <summary>
    /// リクエスト元の識別子を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string RequesterId { get; }

    /// <summary>
    /// コンテキストの状態を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string State { get; }

    /// <summary>
    /// コンテキストに関連するメタデータを取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, object>? Metadata { get; }
}

