namespace AIKernel.Enums;

/// <summary>
/// Describes provider capability risk level.
/// JA: ProviderRiskLevel の公開契約を定義します。
/// </summary>
public enum ProviderRiskLevel
{
    /// <summary>Risk is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Read-only or observation-only capability. JA: ReadOnly 値を表します。</summary>
    ReadOnly = 1,

    /// <summary>Low-risk bounded capability. JA: Low 値を表します。</summary>
    Low = 2,

    /// <summary>Medium-risk capability requiring policy review. JA: Medium 値を表します。</summary>
    Medium = 3,

    /// <summary>High-risk capability requiring explicit governance approval. JA: High 値を表します。</summary>
    High = 4,

    /// <summary>Privileged capability with external side effects. JA: Privileged 値を表します。</summary>
    Privileged = 5
}
