namespace AIKernel.KernelContext;

/// <summary>
/// 実行権限を表現します。
/// ユーザーが実行できる操作を定義します。
/// </summary>
public sealed class Permission
{
    /// <summary>
    /// 権限の一意識別子を取得または設定します。
    /// </summary>
    public required string PermissionId { get; init; }

    /// <summary>
    /// 権限の説明を取得または設定します。
    /// </summary>
    public required string Description { get; init; }

    /// <summary>
    /// スコープを取得または設定します。
    /// </summary>
    public required string Scope { get; init; }

    /// <summary>
    /// 権限の有効期限を取得または設定します。
    /// </summary>
    public DateTime? ExpiresAt { get; init; }

    /// <summary>
    /// 権限がアクティブかどうかを取得または設定します。
    /// </summary>
    public bool IsActive { get; init; } = true;

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Metadata { get; init; }
}
