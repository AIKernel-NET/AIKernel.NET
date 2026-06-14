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
/// EN: Identifies a council vote value. Numeric values are serialization discriminants, not CTG mathematical vote weights. JA: 評議会投票値を識別します。数値はシリアライズ識別子であり、CTG の数学的投票重みではありません。
/// </summary>
public enum CouncilVoteValue
{
    /// <summary>EN: Gets the unknown vote value. JA: 未知の投票値を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the approve vote value. JA: 承認投票値を取得します。</summary>
    Approve = 1,

    /// <summary>EN: Gets the abstain vote value. JA: 棄権投票値を取得します。</summary>
    Abstain = 2,

    /// <summary>EN: Gets the reject vote value. JA: 拒否投票値を取得します。</summary>
    Reject = 3
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

    /// <summary>EN: Gets the allow gate decision value. JA: 許可ゲート決定値を取得します。</summary>
    Allow = 1,

    /// <summary>EN: Gets the deny gate decision value. JA: 拒否ゲート決定値を取得します。</summary>
    Deny = 2
}

/// <summary>
/// EN: Identifies a trajectory-level gate decision. JA: 軌道レベルゲート決定を識別します。
/// </summary>
public enum TrajectoryGateDecisionKind
{
    /// <summary>EN: Gets the unknown trajectory decision value. JA: 未知の軌道決定値を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the continue trajectory decision value. JA: 継続軌道決定値を取得します。</summary>
    Continue = 1,

    /// <summary>EN: Gets the halt trajectory decision value. JA: 停止軌道決定値を取得します。</summary>
    Halt = 2
}

/// <summary>
/// EN: Identifies a rejection reason category. JA: 拒否理由カテゴリを識別します。
/// </summary>
public enum RejectReasonKind
{
    /// <summary>EN: Gets the unknown rejection reason value. JA: 未知の拒否理由値を取得します。</summary>
    Unknown = 0,

    /// <summary>EN: Gets the safety violation rejection reason value. JA: 安全違反の拒否理由値を取得します。</summary>
    SafetyViolation = 1,

    /// <summary>EN: Gets the logical inconsistency rejection reason value. JA: 論理的不整合の拒否理由値を取得します。</summary>
    LogicalInconsistency = 2,

    /// <summary>EN: Gets the context misalignment rejection reason value. JA: 文脈不整合の拒否理由値を取得します。</summary>
    ContextMisalignment = 3,

    /// <summary>EN: Gets the irreversible action rejection reason value. JA: 不可逆操作の拒否理由値を取得します。</summary>
    IrreversibleAction = 4,

    /// <summary>EN: Gets the insufficient information rejection reason value. JA: 情報不足の拒否理由値を取得します。</summary>
    InsufficientInformation = 5,

    /// <summary>EN: Gets the opaque reasoning rejection reason value. JA: 不透明な推論の拒否理由値を取得します。</summary>
    OpaqueReasoning = 6,

    /// <summary>EN: Gets the ethos veto rejection reason value. JA: Ethos 拒否権の拒否理由値を取得します。</summary>
    EthosVeto = 7,

    /// <summary>EN: Gets the fail-closed rejection reason value. JA: fail-closed の拒否理由値を取得します。</summary>
    FailClosed = 8,

    /// <summary>EN: Gets the step-denied rejection reason value. JA: step denied の拒否理由値を取得します。</summary>
    StepDenied = 9,

    /// <summary>EN: Gets the implicit-deny rejection reason value. JA: implicit deny の拒否理由値を取得します。</summary>
    ImplicitDeny = 10
}
