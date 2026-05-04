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
