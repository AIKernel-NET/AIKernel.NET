namespace AIKernel.Dtos.Telemetry;

/// <summary>
/// Carries runtime telemetry data.
/// JA: RuntimeTelemetrySnapshot の公開契約を定義します。
/// </summary>
public sealed record RuntimeTelemetrySnapshot
{
    /// <summary>Gets the telemetry identifier. JA: TelemetryId を取得します。</summary>
    public required string TelemetryId { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets telemetry values. JA: Values を取得します。</summary>
    public IReadOnlyDictionary<string, string> Values { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime telemetry request.
/// JA: RuntimeTelemetryRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeTelemetryRequest
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets optional telemetry request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an evidence capture request.
/// JA: EvidenceCaptureRequest の公開契約を定義します。
/// </summary>
public sealed record EvidenceCaptureRequest
{
    /// <summary>Gets the evidence request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the replay trace identifier. JA: ReplayTraceId を取得します。</summary>
    public string? ReplayTraceId { get; init; }

    /// <summary>Gets optional evidence metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a replayable evidence bundle.
/// JA: EvidenceBundle の公開契約を定義します。
/// </summary>
public sealed record EvidenceBundle
{
    /// <summary>Gets the evidence bundle identifier. JA: EvidenceId を取得します。</summary>
    public required string EvidenceId { get; init; }

    /// <summary>Gets a deterministic evidence hash. JA: EvidenceHash を取得します。</summary>
    public string? EvidenceHash { get; init; }

    /// <summary>Gets an optional screenshot artifact. JA: Screenshot を取得します。</summary>
    public AiImageRef? Screenshot { get; init; }

    /// <summary>Gets optional runtime telemetry. JA: Telemetry を取得します。</summary>
    public RuntimeTelemetrySnapshot? Telemetry { get; init; }

    /// <summary>Gets captured log entries. JA: Logs を取得します。</summary>
    public IReadOnlyList<LogEntry> Logs { get; init; } = [];

    /// <summary>Gets captured artifacts. JA: Artifacts を取得します。</summary>
    public IReadOnlyList<AiArtifactRef> Artifacts { get; init; } = [];

    /// <summary>Gets evidence metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// References an image artifact without owning image bytes.
/// JA: AiImageRef の公開契約を定義します。
/// </summary>
public sealed record AiImageRef
{
    /// <summary>Gets the image reference identifier. JA: ImageId を取得します。</summary>
    public required string ImageId { get; init; }

    /// <summary>Gets an optional content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets optional image metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// References a generic AI artifact.
/// JA: AiArtifactRef の公開契約を定義します。
/// </summary>
public sealed record AiArtifactRef
{
    /// <summary>Gets the artifact identifier. JA: ArtifactId を取得します。</summary>
    public required string ArtifactId { get; init; }

    /// <summary>Gets the artifact kind. JA: Kind を取得します。</summary>
    public string? Kind { get; init; }

    /// <summary>Gets an optional content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets optional artifact metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a captured log entry.
/// JA: LogEntry の公開契約を定義します。
/// </summary>
public sealed record LogEntry
{
    /// <summary>Gets the log level. JA: Level を取得します。</summary>
    public string? Level { get; init; }

    /// <summary>Gets the log message. JA: Message を取得します。</summary>
    public required string Message { get; init; }

    /// <summary>Gets optional log metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a replay evidence request.
/// JA: ReplayEvidenceRequest の公開契約を定義します。
/// </summary>
public sealed record ReplayEvidenceRequest
{
    /// <summary>Gets the replay request identifier. JA: RequestId を取得します。</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the evidence bundle to record. JA: Evidence を取得します。</summary>
    public required EvidenceBundle Evidence { get; init; }

    /// <summary>Gets optional replay metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a recorded replay evidence entry.
/// JA: ReplayEvidenceRecord の公開契約を定義します。
/// </summary>
public sealed record ReplayEvidenceRecord
{
    /// <summary>Gets the replay record identifier. JA: RecordId を取得します。</summary>
    public required string RecordId { get; init; }

    /// <summary>Gets the evidence hash. JA: EvidenceHash を取得します。</summary>
    public string? EvidenceHash { get; init; }

    /// <summary>Gets the replay log hash. JA: ReplayLogHash を取得します。</summary>
    public string? ReplayLogHash { get; init; }

    /// <summary>Gets optional replay record metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
