namespace AIKernel.Enums.Operators;

/// <summary>
/// EN: Describes operator mode.
/// [EN] Documents this public package API member. [JA] OperatorMode の公開契約を定義します。
/// </summary>
public enum OperatorMode
{
    /// <summary>EN: Unknown operator mode. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Observation only. JA: Observe 値を表します。</summary>
    Observe = 1,

    /// <summary>EN: Suggest actions without executing them. JA: Suggest 値を表します。</summary>
    Suggest = 2,

    /// <summary>EN: Assist with bounded control. JA: Assist 値を表します。</summary>
    Assist = 3,

    /// <summary>EN: Manual override mode. JA: ManualOverride 値を表します。</summary>
    ManualOverride = 4
}

/// <summary>
/// EN: Describes operator decisions.
/// [EN] Documents this public package API member. [JA] OperatorDecisionKind の公開契約を定義します。
/// </summary>
public enum OperatorDecisionKind
{
    /// <summary>EN: Unknown decision. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: No safe action was selected. JA: NoAction 値を表します。</summary>
    NoAction = 1,

    /// <summary>EN: An action was proposed. JA: Proposed 値を表します。</summary>
    Proposed = 2,

    /// <summary>EN: The operator needs clarification. JA: Clarify 値を表します。</summary>
    Clarify = 3,

    /// <summary>EN: The operator deferred to governance. JA: Defer 値を表します。</summary>
    Defer = 4
}

/// <summary>
/// EN: Describes action proposal kinds.
/// [EN] Documents this public package API member. [JA] ActionProposalKind の公開契約を定義します。
/// </summary>
public enum ActionProposalKind
{
    /// <summary>EN: Unknown proposal kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Input action proposal. JA: Input 値を表します。</summary>
    Input = 1,

    /// <summary>EN: Runtime action proposal. JA: Runtime 値を表します。</summary>
    Runtime = 2,

    /// <summary>EN: Profile action proposal. JA: Profile 値を表します。</summary>
    Profile = 3,

    /// <summary>EN: Observation action proposal. JA: Observation 値を表します。</summary>
    Observation = 4
}
