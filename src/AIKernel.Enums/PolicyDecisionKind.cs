namespace AIKernel.Enums;

/// <summary>
/// EN: Describes a policy decision category.
/// EN: Documentation for public API. JA: PolicyDecisionKind の公開契約を定義します。
/// </summary>
public enum PolicyDecisionKind
{
    /// <summary>EN: No decision was made. JA: None 値を表します。</summary>
    None = 0,

    /// <summary>EN: The request is allowed. JA: Allow 値を表します。</summary>
    Allow = 1,

    /// <summary>EN: The request is denied. JA: Deny 値を表します。</summary>
    Deny = 2,

    /// <summary>EN: The request needs clarification. JA: Clarify 値を表します。</summary>
    Clarify = 3,

    /// <summary>EN: The request is conditionally allowed. JA: Conditional 値を表します。</summary>
    Conditional = 4
}
