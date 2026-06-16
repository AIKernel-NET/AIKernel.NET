namespace AIKernel.Dtos.Telemetry;

/// <summary>
/// EN: Carries runtime telemetry data.
/// EN: Documentation for public API. JA: RuntimeTelemetrySnapshot の公開契約を定義します。
/// </summary>
public sealed record RuntimeTelemetrySnapshot
{
    /// <summary>EN: Gets the telemetry identifier. JA: TelemetryId を取得します。</summary>
    public required string TelemetryId { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>EN: Gets telemetry values. JA: Values を取得します。</summary>
    public IReadOnlyDictionary<string, string> Values { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a runtime telemetry request.
/// EN: Documentation for public API. JA: RuntimeTelemetryRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeTelemetryRequest
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>EN: Gets optional telemetry request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries an evidence capture request.
/// EN: Documentation for public API. JA: EvidenceCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceCaptureRequest
{
    /// <summary>EN: Gets the evidence request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>EN: Gets the replay trace identifier. JA: ReplayTraceId を取得します。</summary>
    public string? ReplayTraceId { get; init; }

    /// <summary>EN: Gets optional evidence metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a replayable evidence bundle.
/// EN: Documentation for public API. JA: EvidenceBundle の公開契約を定義します。
/// </summary>
public sealed record EvidenceBundle
{
    /// <summary>EN: Gets the evidence bundle identifier. JA: EvidenceId を取得します。</summary>
    public required string EvidenceId { get; init; }

    /// <summary>EN: Gets a deterministic evidence hash. JA: EvidenceHash を取得します。</summary>
    public string? EvidenceHash { get; init; }

    /// <summary>EN: Gets an optional screenshot artifact. JA: Screenshot を取得します。</summary>
    public AiImageRef? Screenshot { get; init; }

    /// <summary>EN: Gets optional runtime telemetry. JA: Telemetry を取得します。</summary>
    public RuntimeTelemetrySnapshot? Telemetry { get; init; }

    /// <summary>EN: Gets captured log entries. JA: Logs を取得します。</summary>
    public IReadOnlyList<LogEntry> Logs { get; init; } = [];

    /// <summary>EN: Gets captured artifacts. JA: Artifacts を取得します。</summary>
    public IReadOnlyList<AiArtifactRef> Artifacts { get; init; } = [];

    /// <summary>EN: Gets evidence metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: References an image artifact without owning image bytes.
/// EN: Documentation for public API. JA: AiImageRef の公開契約を定義します。
/// </summary>
public sealed record AiImageRef
{
    /// <summary>EN: Gets the image reference identifier. JA: ImageId を取得します。</summary>
    public required string ImageId { get; init; }

    /// <summary>EN: Gets an optional content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>EN: Gets optional image metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: References a generic AI artifact.
/// EN: Documentation for public API. JA: AiArtifactRef の公開契約を定義します。
/// </summary>
public sealed record AiArtifactRef
{
    /// <summary>EN: Gets the artifact identifier. JA: ArtifactId を取得します。</summary>
    public required string ArtifactId { get; init; }

    /// <summary>EN: Gets the artifact kind. JA: Kind を取得します。</summary>
    public string? Kind { get; init; }

    /// <summary>EN: Gets an optional content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>EN: Gets optional artifact metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a captured log entry.
/// EN: Documentation for public API. JA: LogEntry の公開契約を定義します。
/// </summary>
public sealed record LogEntry
{
    /// <summary>EN: Gets the log level. JA: Level を取得します。</summary>
    public string? Level { get; init; }

    /// <summary>EN: Gets the log message. JA: Message を取得します。</summary>
    public required string Message { get; init; }

    /// <summary>EN: Gets optional log metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a replay evidence request.
/// EN: Documentation for public API. JA: ReplayEvidenceRequest の公開契約を定義します。
/// </summary>
public sealed record ReplayEvidenceRequest
{
    /// <summary>EN: Gets the replay request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>EN: Gets the evidence bundle to record. JA: Evidence を取得します。</summary>
    public required EvidenceBundle Evidence { get; init; }

    /// <summary>EN: Gets optional replay metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a recorded replay evidence entry.
/// EN: Documentation for public API. JA: ReplayEvidenceRecord の公開契約を定義します。
/// </summary>
public sealed record ReplayEvidenceRecord
{
    /// <summary>EN: Gets the replay record identifier. JA: RecordId を取得します。</summary>
    public required string RecordId { get; init; }

    /// <summary>EN: Gets the evidence hash. JA: EvidenceHash を取得します。</summary>
    public string? EvidenceHash { get; init; }

    /// <summary>EN: Gets the replay log hash. JA: ReplayLogHash を取得します。</summary>
    public string? ReplayLogHash { get; init; }

    /// <summary>EN: Gets optional replay record metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
