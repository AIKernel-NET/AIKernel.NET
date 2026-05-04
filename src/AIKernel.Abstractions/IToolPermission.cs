namespace AIKernel.Abstractions;

/// <summary>
/// ツール実行権限を定義します。
/// セキュリティコンテキストに基づいた権限管理を行います。
/// </summary>
public interface IToolPermission
{
    /// <summary>
    /// 権限の一意識別子を取得します。
    /// </summary>
    string PermissionId { get; }

    /// <summary>
    /// ツール実行を許可しているかどうかを確認します。
    /// </summary>
    bool CanExecuteTool { get; }

    /// <summary>
    /// ファイル読み取り権限があるかどうかを確認します。
    /// </summary>
    bool CanReadFiles { get; }

    /// <summary>
    /// ファイル書き込み権限があるかどうかを確認します。
    /// </summary>
    bool CanWriteFiles { get; }

    /// <summary>
    /// ネットワークアクセス権限があるかどうかを確認します。
    /// </summary>
    bool CanAccessNetwork { get; }

    /// <summary>
    /// 環境変数アクセス権限があるかどうかを確認します。
    /// </summary>
    bool CanAccessEnvironment { get; }

    /// <summary>
    /// システムコマンド実行権限があるかどうかを確認します。
    /// </summary>
    bool CanExecuteSystemCommands { get; }

    /// <summary>
    /// 特定のリソースへのアクセス権限を確認します。
    /// </summary>
    /// <param name="resourcePath">リソースパス</param>
    /// <returns>アクセス権限がある場合は true</returns>
    bool HasResourceAccess(string resourcePath);

    /// <summary>
    /// 権限の有効期限を取得します。
    /// </summary>
    DateTime? ExpiresAt { get; }

    /// <summary>
    /// 権限の有効期限が切れているかどうかを確認します。
    /// </summary>
    bool IsExpired { get; }

    /// <summary>
    /// 権限の制約条件を取得します。
    /// </summary>
    IReadOnlyList<PermissionConstraint> Constraints { get; }
}
