namespace AIKernel.KernelContext;

/// <summary>
/// データ分類を表現します。
/// セキュリティレベルと取扱方針を定義します。
/// </summary>
public sealed class DataClassification
{
    /// <summary>
    /// 分類レベルを取得または設定します。
    /// </summary>
    public required string Level { get; init; }

    /// <summary>
    /// 分類の理由を取得または設定します。
    /// </summary>
    public string? Reason { get; init; }

    /// <summary>
    /// 取扱方針を取得または設定します。
    /// </summary>
    public List<string> HandlingPolicies { get; init; } = new();

    /// <summary>
    /// 暗号化が必須かどうかを取得または設定します。
    /// </summary>
    public bool RequiresEncryption { get; init; }

    /// <summary>
    /// 監査ログが必須かどうかを取得または設定します。
    /// </summary>
    public bool RequiresAuditLog { get; init; }

    /// <summary>
    /// 分類日時を取得または設定します。
    /// </summary>
    public DateTime ClassifiedAt { get; init; } = DateTime.UtcNow;
}
