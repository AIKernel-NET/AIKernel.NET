namespace AIKernel.Enums;

/// <summary>
/// Describes an operator action arbitration outcome.
/// JA: ActionArbitrationDecisionKind の公開契約を定義します。
/// </summary>
public enum ActionArbitrationDecisionKind
{
    /// <summary>No decision was made. JA: None 値を表します。</summary>
    None = 0,

    /// <summary>The proposal is approved for governance review or execution. JA: Approve 値を表します。</summary>
    Approve = 1,

    /// <summary>The proposal is denied. JA: Deny 値を表します。</summary>
    Deny = 2,

    /// <summary>The proposal requires clarification. JA: Clarify 値を表します。</summary>
    Clarify = 3,

    /// <summary>The proposal is conditionally approved. JA: Conditional 値を表します。</summary>
    Conditional = 4
}
