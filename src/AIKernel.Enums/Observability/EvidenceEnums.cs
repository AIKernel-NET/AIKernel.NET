namespace AIKernel.Enums.Observability;

/// <summary>
/// Describes evidence kinds.
/// JA: EvidenceKind の公開契約を定義します。
/// </summary>
public enum EvidenceKind
{
    /// <summary>Unknown evidence kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Screenshot evidence. JA: Screenshot 値を表します。</summary>
    Screenshot = 1,

    /// <summary>Telemetry evidence. JA: Telemetry 値を表します。</summary>
    Telemetry = 2,

    /// <summary>Metrics evidence. JA: Metrics 値を表します。</summary>
    Metrics = 3,

    /// <summary>Log evidence. JA: Logs 値を表します。</summary>
    Logs = 4,

    /// <summary>Diagnostic evidence. JA: Diagnostics 値を表します。</summary>
    Diagnostics = 5,

    /// <summary>Artifact evidence. JA: Artifact 値を表します。</summary>
    Artifact = 6,

    /// <summary>Profile evidence. JA: Profile 値を表します。</summary>
    Profile = 7
}

/// <summary>
/// Describes evidence capture mode.
/// JA: EvidenceCaptureMode の公開契約を定義します。
/// </summary>
public enum EvidenceCaptureMode
{
    /// <summary>Unknown capture mode. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Capture a snapshot. JA: Snapshot 値を表します。</summary>
    Snapshot = 1,

    /// <summary>Capture a bounded range. JA: Range 値を表します。</summary>
    Range = 2,

    /// <summary>Capture incrementally. JA: Incremental 値を表します。</summary>
    Incremental = 3
}
