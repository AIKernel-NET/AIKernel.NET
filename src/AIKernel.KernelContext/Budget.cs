namespace AIKernel.KernelContext;

/// <summary>
/// 予算制限を表現します。
/// リソース使用量の制限を管理します。
/// </summary>
public sealed class Budget
{
    /// <summary>
    /// 予算の一意識別子を取得または設定します。
    /// </summary>
    public required string BudgetId { get; init; }

    /// <summary>
    /// 予算のタイプを取得または設定します。
    /// （例: "tokens", "requests", "compute"）
    /// </summary>
    public required string BudgetType { get; init; }

    /// <summary>
    /// 予算の上限を取得または設定します。
    /// </summary>
    public required double Limit { get; init; }

    /// <summary>
    /// 現在の使用量を取得または設定します。
    /// </summary>
    public double Used { get; init; }

    /// <summary>
    /// 予算の単位を取得または設定します。
    /// </summary>
    public string? Unit { get; init; }

    /// <summary>
    /// 予算のリセット周期を取得または設定します。
    /// </summary>
    public string? ResetPeriod { get; init; }

    /// <summary>
    /// 最終リセット日時を取得または設定します。
    /// </summary>
    public DateTime? LastResetAt { get; init; }
}
