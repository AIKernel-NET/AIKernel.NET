namespace AIKernel.Enums.Profiles;

/// <summary>
/// EN: Describes profile kinds.
/// EN: Documentation for public API. JA: ProfileKind の公開契約を定義します。
/// </summary>
public enum ProfileKind
{
    /// <summary>EN: Unknown profile kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Operator profile. JA: Operator 値を表します。</summary>
    Operator = 1,

    /// <summary>EN: Perception profile. JA: Perception 値を表します。</summary>
    Perception = 2,

    /// <summary>EN: Routing profile. JA: Routing 値を表します。</summary>
    Routing = 3,

    /// <summary>EN: Governance profile. JA: Governance 値を表します。</summary>
    Governance = 4,

    /// <summary>EN: Runtime profile. JA: Runtime 値を表します。</summary>
    Runtime = 5
}

/// <summary>
/// EN: Describes profile formats.
/// EN: Documentation for public API. JA: ProfileFormat の公開契約を定義します。
/// </summary>
public enum ProfileFormat
{
    /// <summary>EN: Unknown profile format. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: JSON profile. JA: Json 値を表します。</summary>
    Json = 1,

    /// <summary>EN: YAML profile. JA: Yaml 値を表します。</summary>
    Yaml = 2,

    /// <summary>EN: Binary profile. JA: Binary 値を表します。</summary>
    Binary = 3
}

/// <summary>
/// EN: Describes profile optimization goals.
/// EN: Documentation for public API. JA: ProfileOptimizationGoal の公開契約を定義します。
/// </summary>
public enum ProfileOptimizationGoal
{
    /// <summary>EN: Unknown optimization goal. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Improve latency. JA: Latency 値を表します。</summary>
    Latency = 1,

    /// <summary>EN: Improve accuracy. JA: Accuracy 値を表します。</summary>
    Accuracy = 2,

    /// <summary>EN: Reduce cost. JA: Cost 値を表します。</summary>
    Cost = 3,

    /// <summary>EN: Reduce risk. JA: Risk 値を表します。</summary>
    Risk = 4,

    /// <summary>EN: Improve stability. JA: Stability 値を表します。</summary>
    Stability = 5
}

/// <summary>
/// EN: Describes profile optimization decisions.
/// EN: Documentation for public API. JA: ProfileOptimizationDecision の公開契約を定義します。
/// </summary>
public enum ProfileOptimizationDecision
{
    /// <summary>EN: Unknown optimization decision. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Accept the optimization. JA: Accept 値を表します。</summary>
    Accept = 1,

    /// <summary>EN: Reject the optimization. JA: Reject 値を表します。</summary>
    Reject = 2,

    /// <summary>EN: Requires review. JA: Review 値を表します。</summary>
    Review = 3
}
