namespace AIKernel.Enums.Adapters;

/// <summary>
/// Identifies the broad adapter boundary.
/// JA: AdapterKind の公開契約を定義します。
/// </summary>
public enum AdapterKind
{
    /// <summary>Unknown adapter kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Provider adapter. JA: Provider 値を表します。</summary>
    Provider = 1,

    /// <summary>Runtime adapter. JA: Runtime 値を表します。</summary>
    Runtime = 2,

    /// <summary>Process adapter. JA: Process 値を表します。</summary>
    Process = 3,

    /// <summary>Observability adapter. JA: Observability 値を表します。</summary>
    Observability = 4
}

/// <summary>
/// Describes adapter binding state.
/// JA: AdapterBindingState の公開契約を定義します。
/// </summary>
public enum AdapterBindingState
{
    /// <summary>Unknown binding state. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>The adapter is unbound. JA: Unbound 値を表します。</summary>
    Unbound = 1,

    /// <summary>The adapter is binding. JA: Binding 値を表します。</summary>
    Binding = 2,

    /// <summary>The adapter is bound. JA: Bound 値を表します。</summary>
    Bound = 3,

    /// <summary>The adapter is failed. JA: Failed 値を表します。</summary>
    Failed = 4
}

/// <summary>
/// Describes adapter validation severity.
/// JA: AdapterValidationSeverity の公開契約を定義します。
/// </summary>
public enum AdapterValidationSeverity
{
    /// <summary>Unknown severity. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Informational validation finding. JA: Info 値を表します。</summary>
    Info = 1,

    /// <summary>Warning validation finding. JA: Warning 値を表します。</summary>
    Warning = 2,

    /// <summary>Error validation finding. JA: Error 値を表します。</summary>
    Error = 3
}
