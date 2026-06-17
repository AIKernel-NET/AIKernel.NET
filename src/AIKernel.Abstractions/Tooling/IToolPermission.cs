namespace AIKernel.Abstractions.Tooling;

/// <summary>
/// UC-31 に基づく契約です。
/// ツール実行権限を定義します。
/// EN: セキュリティコンテキストに基づいた権限管理を行います。
/// [EN] Documents this public package API member. [JA] IToolPermission の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolPermission']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tooling.IToolPermission']" />
public interface IToolPermission
{
    /// <summary>
    /// EN: 権限の一意識別子を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string PermissionId { get; }

    /// <summary>
    /// EN: ツール実行を許可しているかどうかを確認します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    bool CanExecuteTool { get; }

    /// <summary>
    /// EN: ファイル読み取り権限があるかどうかを確認します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    bool CanReadFiles { get; }

    /// <summary>
    /// EN: ファイル書き込み権限があるかどうかを確認します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    bool CanWriteFiles { get; }

    /// <summary>
    /// EN: ネットワークアクセス権限があるかどうかを確認します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    bool CanAccessNetwork { get; }

    /// <summary>
    /// EN: 環境変数アクセス権限があるかどうかを確認します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    bool CanAccessEnvironment { get; }

    /// <summary>
    /// EN: システムコマンド実行権限があるかどうかを確認します。
    /// [EN] Documents this public package API member. [JA] HasResourceAccess 操作を実行します。
    /// </summary>
    bool CanExecuteSystemCommands { get; }

    /// <summary>
    /// EN: 特定のリソースへのアクセス権限を確認します。
    /// [EN] Documents this public package API member. [JA] HasResourceAccess 操作を実行します。
    /// </summary>
    /// <param name="resourcePath">[EN] Documents this public package API member. [JA] リソースパス resourcePath パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] アクセス権限がある場合は true 結果を返します。</returns>
    bool HasResourceAccess(string resourcePath);

    /// <summary>
    /// EN: 権限の有効期限を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    DateTime? ExpiresAt { get; }

    /// <summary>
    /// EN: 権限の有効期限が切れているかどうかを確認します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    bool IsExpired { get; }

    /// <summary>
    /// EN: 権限の制約条件を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<PermissionConstraint> Constraints { get; }
}


