namespace AIKernel.Enums;

/// <summary>
/// Describes the maximum side-effect mode allowed for a runtime loop.
/// JA: RuntimeControlMode の公開契約を定義します。
/// </summary>
public enum RuntimeControlMode
{
    /// <summary>Normal governed runtime operation. JA: Normal 値を表します。</summary>
    Normal = 0,

    /// <summary>Observation is allowed but input execution is blocked. JA: ObserveOnly 値を表します。</summary>
    ObserveOnly = 1,

    /// <summary>Manual movement or input override is allowed. JA: ManualOverride 値を表します。</summary>
    ManualOverride = 2,

    /// <summary>Assisted governed control is allowed. JA: AssistedControl 値を表します。</summary>
    AssistedControl = 3,

    /// <summary>Replay-only operation is allowed. JA: ReplayOnly 値を表します。</summary>
    ReplayOnly = 4
}
