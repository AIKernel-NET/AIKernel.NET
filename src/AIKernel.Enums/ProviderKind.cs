namespace AIKernel.Enums;

/// <summary>
/// EN: Classifies a provider by its architectural responsibility.
/// [EN] Documents this public package API member. [JA] ProviderKind の公開契約を定義します。
/// </summary>
public enum ProviderKind
{
    /// <summary>EN: Provider kind is not specified. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Side-effecting provider boundary. JA: Provider 値を表します。</summary>
    Provider = 1,

    /// <summary>EN: Read-only observation and evidence boundary. JA: Observer 値を表します。</summary>
    Observer = 2,

    /// <summary>EN: Bounded action-proposal boundary. JA: Operator 値を表します。</summary>
    Operator = 3,

    /// <summary>EN: Governance-approved input execution boundary. JA: ActionProvider 値を表します。</summary>
    ActionProvider = 4
}
