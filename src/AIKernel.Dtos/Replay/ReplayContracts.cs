using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Replay;

namespace AIKernel.Dtos.Replay;

/// <summary>
/// EN: Carries a replay timeline create request.
/// EN: Documentation for public API. JA: ReplayTimelineCreateRequest の公開契約を定義します。
/// </summary>
public sealed record ReplayTimelineCreateRequest
{
    /// <summary>EN: Gets the requested timeline identifier. JA: TimelineId を取得します。</summary>
    public string? TimelineId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay timeline create result.
/// EN: Documentation for public API. JA: ReplayTimelineCreateResult の公開契約を定義します。
/// </summary>
public sealed record ReplayTimelineCreateResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether creation succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets creation diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when creation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay frame append request.
/// EN: Documentation for public API. JA: ReplayFrameAppendRequest の公開契約を定義します。
/// </summary>
public sealed record ReplayFrameAppendRequest
{
    /// <summary>EN: Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>EN: Gets the replay frame. JA: Frame を取得します。</summary>
    public ReplayFrame Frame { get; init; } = new();

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay event append request.
/// EN: Documentation for public API. JA: ReplayEventAppendRequest の公開契約を定義します。
/// </summary>
public sealed record ReplayEventAppendRequest
{
    /// <summary>EN: Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>EN: Gets the replay event. JA: Event を取得します。</summary>
    public ReplayEvent Event { get; init; } = new();

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay append result.
/// EN: Documentation for public API. JA: ReplayAppendResult の公開契約を定義します。
/// </summary>
public sealed record ReplayAppendResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether append succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the appended item identifier. JA: AppendedId を取得します。</summary>
    public string? AppendedId { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets append diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when append was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay timeline query.
/// EN: Documentation for public API. JA: ReplayTimelineQuery の公開契約を定義します。
/// </summary>
public sealed record ReplayTimelineQuery
{
    /// <summary>EN: Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>EN: Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay timeline.
/// EN: Documentation for public API. JA: ReplayTimeline の公開契約を定義します。
/// </summary>
public sealed record ReplayTimeline
{
    /// <summary>EN: Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether timeline retrieval succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets replay frames. JA: Frames を取得します。</summary>
    public IReadOnlyList<ReplayFrame> Frames { get; init; } = [];

    /// <summary>EN: Gets replay events. JA: Events を取得します。</summary>
    public IReadOnlyList<ReplayEvent> Events { get; init; } = [];

    /// <summary>EN: Gets the seal state. JA: SealState を取得します。</summary>
    public ReplaySealState SealState { get; init; } = ReplaySealState.Unknown;

    /// <summary>EN: Gets timeline diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when the timeline was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets timeline metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay frame.
/// EN: Documentation for public API. JA: ReplayFrame の公開契約を定義します。
/// </summary>
public sealed record ReplayFrame
{
    /// <summary>EN: Gets the replay frame identifier. JA: FrameId を取得します。</summary>
    public string FrameId { get; init; } = string.Empty;

    /// <summary>EN: Gets the frame kind. JA: Kind を取得します。</summary>
    public ReplayFrameKind Kind { get; init; } = ReplayFrameKind.Unknown;

    /// <summary>EN: Gets the frame index. JA: Index を取得します。</summary>
    public long Index { get; init; }

    /// <summary>EN: Gets when the frame was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets frame metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay event.
/// EN: Documentation for public API. JA: ReplayEvent の公開契約を定義します。
/// </summary>
public sealed record ReplayEvent
{
    /// <summary>EN: Gets the replay event identifier. JA: EventId を取得します。</summary>
    public string EventId { get; init; } = string.Empty;

    /// <summary>EN: Gets the event kind. JA: Kind を取得します。</summary>
    public ReplayEventKind Kind { get; init; } = ReplayEventKind.Unknown;

    /// <summary>EN: Gets the associated frame identifier. JA: FrameId を取得します。</summary>
    public string? FrameId { get; init; }

    /// <summary>EN: Gets when the event was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets event metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay event query.
/// EN: Documentation for public API. JA: ReplayEventQuery の公開契約を定義します。
/// </summary>
public sealed record ReplayEventQuery
{
    /// <summary>EN: Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>EN: Gets the event kind filter. JA: Kind を取得します。</summary>
    public ReplayEventKind Kind { get; init; } = ReplayEventKind.Unknown;

    /// <summary>EN: Gets the replay cursor. JA: Cursor を取得します。</summary>
    public ReplayCursor? Cursor { get; init; }

    /// <summary>EN: Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a replay seal request.
/// EN: Documentation for public API. JA: ReplaySealRequest の公開契約を定義します。
/// </summary>
public sealed record ReplaySealRequest
{
    /// <summary>EN: Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>EN: Gets the requested hash algorithm. JA: HashAlgorithm を取得します。</summary>
    public string? HashAlgorithm { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries replay seal hash and signature references.
/// EN: Documentation for public API. JA: ReplaySealResult の公開契約を定義します。
/// </summary>
public sealed record ReplaySealResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether seal succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>EN: Gets the seal state. JA: SealState を取得します。</summary>
    public ReplaySealState SealState { get; init; } = ReplaySealState.Unknown;

    /// <summary>EN: Gets the content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>EN: Gets the hash algorithm. JA: HashAlgorithm を取得します。</summary>
    public string? HashAlgorithm { get; init; }

    /// <summary>EN: Gets the signature reference. JA: SignatureRef を取得します。</summary>
    public string? SignatureRef { get; init; }

    /// <summary>EN: Gets the signer identifier. JA: SignerId を取得します。</summary>
    public string? SignerId { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets seal diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when seal was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries replay cursor state.
/// EN: Documentation for public API. JA: ReplayCursor の公開契約を定義します。
/// </summary>
public sealed record ReplayCursor
{
    /// <summary>EN: Gets the cursor token. JA: Token を取得します。</summary>
    public string? Token { get; init; }

    /// <summary>EN: Gets the maximum result count. JA: Limit を取得します。</summary>
    public int? Limit { get; init; }

    /// <summary>EN: Gets cursor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
