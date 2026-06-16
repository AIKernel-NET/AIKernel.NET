namespace AIKernel.Enums.Observability;

/// <summary>
/// EN: Describes evidence kinds.
/// EN: Documentation for public API. JA: EvidenceKind の公開契約を定義します。
/// </summary>
public enum EvidenceKind
{
    /// <summary>EN: Unknown evidence kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Screenshot evidence. JA: Screenshot 値を表します。</summary>
    Screenshot = 1,

    /// <summary>EN: Telemetry evidence. JA: Telemetry 値を表します。</summary>
    Telemetry = 2,

    /// <summary>EN: Metrics evidence. JA: Metrics 値を表します。</summary>
    Metrics = 3,

    /// <summary>EN: Log evidence. JA: Logs 値を表します。</summary>
    Logs = 4,

    /// <summary>EN: Diagnostic evidence. JA: Diagnostics 値を表します。</summary>
    Diagnostics = 5,

    /// <summary>EN: Artifact evidence. JA: Artifact 値を表します。</summary>
    Artifact = 6,

    /// <summary>EN: Profile evidence. JA: Profile 値を表します。</summary>
    Profile = 7
}

/// <summary>
/// EN: Describes evidence capture mode.
/// EN: Documentation for public API. JA: EvidenceCaptureMode の公開契約を定義します。
/// </summary>
public enum EvidenceCaptureMode
{
    /// <summary>EN: Unknown capture mode. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Capture a snapshot. JA: Snapshot 値を表します。</summary>
    Snapshot = 1,

    /// <summary>EN: Capture a bounded range. JA: Range 値を表します。</summary>
    Range = 2,

    /// <summary>EN: Capture incrementally. JA: Incremental 値を表します。</summary>
    Incremental = 3
}
