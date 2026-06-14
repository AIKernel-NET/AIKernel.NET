namespace AIKernel.Enums.Profiles;

/// <summary>
/// Describes profile kinds.
/// JA: ProfileKind の公開契約を定義します。
/// </summary>
public enum ProfileKind
{
    /// <summary>Unknown profile kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Operator profile. JA: Operator 値を表します。</summary>
    Operator = 1,

    /// <summary>Perception profile. JA: Perception 値を表します。</summary>
    Perception = 2,

    /// <summary>Routing profile. JA: Routing 値を表します。</summary>
    Routing = 3,

    /// <summary>Governance profile. JA: Governance 値を表します。</summary>
    Governance = 4,

    /// <summary>Runtime profile. JA: Runtime 値を表します。</summary>
    Runtime = 5
}

/// <summary>
/// Describes profile formats.
/// JA: ProfileFormat の公開契約を定義します。
/// </summary>
public enum ProfileFormat
{
    /// <summary>Unknown profile format. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>JSON profile. JA: Json 値を表します。</summary>
    Json = 1,

    /// <summary>YAML profile. JA: Yaml 値を表します。</summary>
    Yaml = 2,

    /// <summary>Binary profile. JA: Binary 値を表します。</summary>
    Binary = 3
}

/// <summary>
/// Describes profile optimization goals.
/// JA: ProfileOptimizationGoal の公開契約を定義します。
/// </summary>
public enum ProfileOptimizationGoal
{
    /// <summary>Unknown optimization goal. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Improve latency. JA: Latency 値を表します。</summary>
    Latency = 1,

    /// <summary>Improve accuracy. JA: Accuracy 値を表します。</summary>
    Accuracy = 2,

    /// <summary>Reduce cost. JA: Cost 値を表します。</summary>
    Cost = 3,

    /// <summary>Reduce risk. JA: Risk 値を表します。</summary>
    Risk = 4,

    /// <summary>Improve stability. JA: Stability 値を表します。</summary>
    Stability = 5
}

/// <summary>
/// Describes profile optimization decisions.
/// JA: ProfileOptimizationDecision の公開契約を定義します。
/// </summary>
public enum ProfileOptimizationDecision
{
    /// <summary>Unknown optimization decision. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Accept the optimization. JA: Accept 値を表します。</summary>
    Accept = 1,

    /// <summary>Reject the optimization. JA: Reject 値を表します。</summary>
    Reject = 2,

    /// <summary>Requires review. JA: Review 値を表します。</summary>
    Review = 3
}
