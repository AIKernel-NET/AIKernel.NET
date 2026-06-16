namespace AIKernel.Enums.Adapters;

/// <summary>
/// EN: Identifies the broad adapter boundary.
/// [EN] Documents this public package API member. [JA] AdapterKind の公開契約を定義します。
/// </summary>
public enum AdapterKind
{
    /// <summary>EN: Unknown adapter kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Provider adapter. JA: Provider 値を表します。</summary>
    Provider = 1,

    /// <summary>EN: Runtime adapter. JA: Runtime 値を表します。</summary>
    Runtime = 2,

    /// <summary>EN: Process adapter. JA: Process 値を表します。</summary>
    Process = 3,

    /// <summary>EN: Observability adapter. JA: Observability 値を表します。</summary>
    Observability = 4
}

/// <summary>
/// EN: Describes adapter binding state.
/// [EN] Documents this public package API member. [JA] AdapterBindingState の公開契約を定義します。
/// </summary>
public enum AdapterBindingState
{
    /// <summary>EN: Unknown binding state. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: The adapter is unbound. JA: Unbound 値を表します。</summary>
    Unbound = 1,

    /// <summary>EN: The adapter is binding. JA: Binding 値を表します。</summary>
    Binding = 2,

    /// <summary>EN: The adapter is bound. JA: Bound 値を表します。</summary>
    Bound = 3,

    /// <summary>EN: The adapter is failed. JA: Failed 値を表します。</summary>
    Failed = 4
}

/// <summary>
/// EN: Describes adapter validation severity.
/// [EN] Documents this public package API member. [JA] AdapterValidationSeverity の公開契約を定義します。
/// </summary>
public enum AdapterValidationSeverity
{
    /// <summary>EN: Unknown severity. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Informational validation finding. JA: Info 値を表します。</summary>
    Info = 1,

    /// <summary>EN: Warning validation finding. JA: Warning 値を表します。</summary>
    Warning = 2,

    /// <summary>EN: Error validation finding. JA: Error 値を表します。</summary>
    Error = 3
}
