namespace AIKernel.Dtos.Telemetry;

/// <summary>
/// Carries runtime telemetry data.
/// </summary>
public sealed record RuntimeTelemetrySnapshot
{
    /// <summary>Gets the telemetry identifier.</summary>
    public required string TelemetryId { get; init; }

    /// <summary>Gets the runtime identifier.</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets telemetry values.</summary>
    public IReadOnlyDictionary<string, string> Values { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime telemetry request.
/// </summary>
public sealed record RuntimeTelemetryRequest
{
    /// <summary>Gets the runtime identifier.</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets optional telemetry request metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries an evidence capture request.
/// </summary>
public sealed record EvidenceCaptureRequest
{
    /// <summary>Gets the evidence request identifier.</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the replay trace identifier.</summary>
    public string? ReplayTraceId { get; init; }

    /// <summary>Gets optional evidence metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a replayable evidence bundle.
/// </summary>
public sealed record EvidenceBundle
{
    /// <summary>Gets the evidence bundle identifier.</summary>
    public required string EvidenceId { get; init; }

    /// <summary>Gets a deterministic evidence hash.</summary>
    public string? EvidenceHash { get; init; }

    /// <summary>Gets an optional screenshot artifact.</summary>
    public AiImageRef? Screenshot { get; init; }

    /// <summary>Gets optional runtime telemetry.</summary>
    public RuntimeTelemetrySnapshot? Telemetry { get; init; }

    /// <summary>Gets captured log entries.</summary>
    public IReadOnlyList<LogEntry> Logs { get; init; } = [];

    /// <summary>Gets captured artifacts.</summary>
    public IReadOnlyList<AiArtifactRef> Artifacts { get; init; } = [];

    /// <summary>Gets evidence metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// References an image artifact without owning image bytes.
/// </summary>
public sealed record AiImageRef
{
    /// <summary>Gets the image reference identifier.</summary>
    public required string ImageId { get; init; }

    /// <summary>Gets an optional content hash.</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets optional image metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// References a generic AI artifact.
/// </summary>
public sealed record AiArtifactRef
{
    /// <summary>Gets the artifact identifier.</summary>
    public required string ArtifactId { get; init; }

    /// <summary>Gets the artifact kind.</summary>
    public string? Kind { get; init; }

    /// <summary>Gets an optional content hash.</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets optional artifact metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a captured log entry.
/// </summary>
public sealed record LogEntry
{
    /// <summary>Gets the log level.</summary>
    public string? Level { get; init; }

    /// <summary>Gets the log message.</summary>
    public required string Message { get; init; }

    /// <summary>Gets optional log metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a replay evidence request.
/// </summary>
public sealed record ReplayEvidenceRequest
{
    /// <summary>Gets the replay request identifier.</summary>
    public required string RequestId { get; init; }

    /// <summary>Gets the evidence bundle to record.</summary>
    public required EvidenceBundle Evidence { get; init; }

    /// <summary>Gets optional replay metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a recorded replay evidence entry.
/// </summary>
public sealed record ReplayEvidenceRecord
{
    /// <summary>Gets the replay record identifier.</summary>
    public required string RecordId { get; init; }

    /// <summary>Gets the evidence hash.</summary>
    public string? EvidenceHash { get; init; }

    /// <summary>Gets the replay log hash.</summary>
    public string? ReplayLogHash { get; init; }

    /// <summary>Gets optional replay record metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
