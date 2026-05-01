namespace AIKernel.Enums;

/// <summary>
/// ポリシー決定ポイント（PDP）の決定結果を定義します。
/// アクセス制御の最終判定を表現します。
/// </summary>
public enum PdpDecision
{
    /// <summary>
    /// アクセスが許可されました
    /// </summary>
    Allow = 1,

    /// <summary>
    /// アクセスが拒否されました
    /// </summary>
    Deny = 2,

    /// <summary>
    /// 決定が不確定（追加情報が必要）
    /// </summary>
    Undecided = 3
}

/// <summary>
/// 拒否理由コードを定義します。
/// アクセス拒否の詳細な理由を提供します。
/// </summary>
public enum RejectCode
{
    /// <summary>
    /// 認証失敗
    /// </summary>
    AuthenticationFailed = 1,

    /// <summary>
    /// 認可失敗
    /// </summary>
    AuthorizationFailed = 2,

    /// <summary>
    /// リソースが見つかりません
    /// </summary>
    ResourceNotFound = 3,

    /// <summary>
    /// ポリシー違反
    /// </summary>
    PolicyViolation = 4,

    /// <summary>
    /// レート制限に達しました
    /// </summary>
    RateLimitExceeded = 5,

    /// <summary>
    /// リソースが利用不可です
    /// </summary>
    ResourceUnavailable = 6,

    /// <summary>
    /// 権限が不足しています
    /// </summary>
    InsufficientPermissions = 7,

    /// <summary>
    /// セッションが期限切れです
    /// </summary>
    SessionExpired = 8
}
