namespace AIKernel.Enums;

/// <summary>
/// EN: Describes an operator action arbitration outcome.
/// [EN] Documents this public package API member. [JA] ActionArbitrationDecisionKind の公開契約を定義します。
/// </summary>
public enum ActionArbitrationDecisionKind
{
    /// <summary>EN: No decision was made. JA: None 値を表します。</summary>
    None = 0,

    /// <summary>EN: The proposal is approved for governance review or execution. JA: Approve 値を表します。</summary>
    Approve = 1,

    /// <summary>EN: The proposal is denied. JA: Deny 値を表します。</summary>
    Deny = 2,

    /// <summary>EN: The proposal requires clarification. JA: Clarify 値を表します。</summary>
    Clarify = 3,

    /// <summary>EN: The proposal is conditionally approved. JA: Conditional 値を表します。</summary>
    Conditional = 4
}
