namespace AIKernel.Abstractions.Tooling;

/// <summary>
/// UC-31 に基づく契約です。
/// ツール実行権限を定義します。
/// セキュリティコンテキストに基づいた権限管理を行います。
/// JA: IToolPermission の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolPermission']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolPermission']" />
public interface IToolPermission
{
    /// <summary>
    /// 権限の一意識別子を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string PermissionId { get; }

    /// <summary>
    /// ツール実行を許可しているかどうかを確認します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool CanExecuteTool { get; }

    /// <summary>
    /// ファイル読み取り権限があるかどうかを確認します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool CanReadFiles { get; }

    /// <summary>
    /// ファイル書き込み権限があるかどうかを確認します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool CanWriteFiles { get; }

    /// <summary>
    /// ネットワークアクセス権限があるかどうかを確認します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool CanAccessNetwork { get; }

    /// <summary>
    /// 環境変数アクセス権限があるかどうかを確認します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool CanAccessEnvironment { get; }

    /// <summary>
    /// システムコマンド実行権限があるかどうかを確認します。
    /// JA: HasResourceAccess 操作を実行します。
    /// </summary>
    bool CanExecuteSystemCommands { get; }

    /// <summary>
    /// 特定のリソースへのアクセス権限を確認します。
    /// JA: HasResourceAccess 操作を実行します。
    /// </summary>
    /// <param name="resourcePath">リソースパス JA: resourcePath パラメーターです。</param>
    /// <returns>アクセス権限がある場合は true JA: 結果を返します。</returns>
    bool HasResourceAccess(string resourcePath);

    /// <summary>
    /// 権限の有効期限を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    DateTime? ExpiresAt { get; }

    /// <summary>
    /// 権限の有効期限が切れているかどうかを確認します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool IsExpired { get; }

    /// <summary>
    /// 権限の制約条件を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<PermissionConstraint> Constraints { get; }
}


