namespace AIKernel.Enums;

/// <summary>
/// EN: Describes provider capability risk level.
/// EN: Documentation for public API. JA: ProviderRiskLevel の公開契約を定義します。
/// </summary>
public enum ProviderRiskLevel
{
    /// <summary>EN: Risk is unknown. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Read-only or observation-only capability. JA: ReadOnly 値を表します。</summary>
    ReadOnly = 1,

    /// <summary>EN: Low-risk bounded capability. JA: Low 値を表します。</summary>
    Low = 2,

    /// <summary>EN: Medium-risk capability requiring policy review. JA: Medium 値を表します。</summary>
    Medium = 3,

    /// <summary>EN: High-risk capability requiring explicit governance approval. JA: High 値を表します。</summary>
    High = 4,

    /// <summary>EN: Privileged capability with external side effects. JA: Privileged 値を表します。</summary>
    Privileged = 5
}
