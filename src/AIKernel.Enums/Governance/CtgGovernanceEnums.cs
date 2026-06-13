namespace AIKernel.Enums.Governance;

/// <summary>
/// EN: Identifies the council participating in triadic governance. JA: 三分統治に参加する評議会を識別します。
/// </summary>
public enum CouncilKind
{
    /// <summary>EN: Gets the unknown council value. JA: 未知の評議会値を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the logos council value. JA: Logos 評議会値を取得します。</summary>
    Logos = 1,

    /// <summary>EN: Gets the ethos council value. JA: Ethos 評議会値を取得します。</summary>
    Ethos = 2,

    /// <summary>EN: Gets the pathos council value. JA: Pathos 評議会値を取得します。</summary>
    Pathos = 3
}

/// <summary>
/// EN: Identifies a council vote kind. Numeric values are serialization discriminants, not CTG mathematical vote weights. JA: 評議会投票種別を識別します。数値はシリアライズ識別子であり、CTG の数学的投票重みではありません。
/// </summary>
public enum CouncilVoteKind
{
    /// <summary>EN: Gets the unknown vote value. JA: 未知の投票値を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the approve vote kind. JA: 承認投票種別を取得します。</summary>
    Approve = 1,

    /// <summary>EN: Gets the reject vote kind. JA: 拒否投票種別を取得します。</summary>
    Reject = 2,

    /// <summary>EN: Gets the abstain vote kind. JA: 棄権投票種別を取得します。</summary>
    Abstain = 3,

    /// <summary>EN: Gets the explicit veto vote kind. JA: 明示的な拒否権投票種別を取得します。</summary>
    Veto = 4
}

/// <summary>
/// EN: Identifies a council decision value. JA: 評議会決定値を識別します。
/// </summary>
public enum CouncilDecisionKind
{
    /// <summary>EN: Gets the unknown decision value. JA: 未知の決定値を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the approved decision value. JA: 承認済み決定値を取得します。</summary>
    Approved = 1,

    /// <summary>EN: Gets the rejected decision value. JA: 拒否済み決定値を取得します。</summary>
    Rejected = 2,

    /// <summary>EN: Gets the vetoed decision value. JA: 拒否権適用済み決定値を取得します。</summary>
    Vetoed = 3,

    /// <summary>EN: Gets the inconclusive decision value. JA: 不確定決定値を取得します。</summary>
    Inconclusive = 4
}

/// <summary>
/// EN: Identifies a single-step gate decision. JA: 単一ステップゲート決定を識別します。
/// </summary>
public enum GateDecisionKind
{
    /// <summary>EN: Gets the unknown gate decision value. JA: 未知のゲート決定値を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the accepted gate decision value. JA: 受理ゲート決定値を取得します。</summary>
    Accepted = 1,

    /// <summary>EN: Gets the rejected gate decision value. JA: 拒否ゲート決定値を取得します。</summary>
    Rejected = 2,

    /// <summary>EN: Gets the vetoed gate decision value. JA: 拒否権適用済みゲート決定値を取得します。</summary>
    Vetoed = 3,

    /// <summary>EN: Gets the inconclusive gate decision value. JA: 不確定ゲート決定値を取得します。</summary>
    Inconclusive = 4
}

/// <summary>
/// EN: Identifies a trajectory-level gate decision. JA: 軌道レベルゲート決定を識別します。
/// </summary>
public enum TrajectoryGateDecisionKind
{
    /// <summary>EN: Gets the unknown trajectory decision value. JA: 未知の軌道決定値を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the accepted trajectory decision value. JA: 受理軌道決定値を取得します。</summary>
    Accepted = 1,

    /// <summary>EN: Gets the rejected trajectory decision value. JA: 拒否軌道決定値を取得します。</summary>
    Rejected = 2,

    /// <summary>EN: Gets the vetoed trajectory decision value. JA: 拒否権適用済み軌道決定値を取得します。</summary>
    Vetoed = 3,

    /// <summary>EN: Gets the inconclusive trajectory decision value. JA: 不確定軌道決定値を取得します。</summary>
    Inconclusive = 4
}

/// <summary>
/// EN: Identifies a rejection reason category. JA: 拒否理由カテゴリを識別します。
/// </summary>
public enum RejectReasonKind
{
    /// <summary>EN: Gets the unknown rejection reason value. JA: 未知の拒否理由値を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the missing canon rejection reason value. JA: 正典不足の拒否理由値を取得します。</summary>
    CanonMissing = 1,

    /// <summary>EN: Gets the canon veto rejection reason value. JA: 正典拒否権の拒否理由値を取得します。</summary>
    CanonVeto = 2,

    /// <summary>EN: Gets the council rejection reason value. JA: 評議会拒否の理由値を取得します。</summary>
    CouncilRejected = 3,

    /// <summary>EN: Gets the gate rejection reason value. JA: ゲート拒否の理由値を取得します。</summary>
    GateRejected = 4,

    /// <summary>EN: Gets the trajectory rejection reason value. JA: 軌道拒否の理由値を取得します。</summary>
    TrajectoryRejected = 5,

    /// <summary>EN: Gets the inconclusive rejection reason value. JA: 不確定の拒否理由値を取得します。</summary>
    Inconclusive = 6,

    /// <summary>EN: Gets the invalid input rejection reason value. JA: 無効入力の拒否理由値を取得します。</summary>
    InvalidInput = 7
}
