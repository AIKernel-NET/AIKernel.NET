namespace AIKernel.Enums.Operators;

/// <summary>
/// Describes operator mode.
/// JA: OperatorMode の公開契約を定義します。
/// </summary>
public enum OperatorMode
{
    /// <summary>Unknown operator mode. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Observation only. JA: Observe 値を表します。</summary>
    Observe = 1,

    /// <summary>Suggest actions without executing them. JA: Suggest 値を表します。</summary>
    Suggest = 2,

    /// <summary>Assist with bounded control. JA: Assist 値を表します。</summary>
    Assist = 3,

    /// <summary>Manual override mode. JA: ManualOverride 値を表します。</summary>
    ManualOverride = 4
}

/// <summary>
/// Describes operator decisions.
/// JA: OperatorDecisionKind の公開契約を定義します。
/// </summary>
public enum OperatorDecisionKind
{
    /// <summary>Unknown decision. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>No safe action was selected. JA: NoAction 値を表します。</summary>
    NoAction = 1,

    /// <summary>An action was proposed. JA: Proposed 値を表します。</summary>
    Proposed = 2,

    /// <summary>The operator needs clarification. JA: Clarify 値を表します。</summary>
    Clarify = 3,

    /// <summary>The operator deferred to governance. JA: Defer 値を表します。</summary>
    Defer = 4
}

/// <summary>
/// Describes action proposal kinds.
/// JA: ActionProposalKind の公開契約を定義します。
/// </summary>
public enum ActionProposalKind
{
    /// <summary>Unknown proposal kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Input action proposal. JA: Input 値を表します。</summary>
    Input = 1,

    /// <summary>Runtime action proposal. JA: Runtime 値を表します。</summary>
    Runtime = 2,

    /// <summary>Profile action proposal. JA: Profile 値を表します。</summary>
    Profile = 3,

    /// <summary>Observation action proposal. JA: Observation 値を表します。</summary>
    Observation = 4
}
