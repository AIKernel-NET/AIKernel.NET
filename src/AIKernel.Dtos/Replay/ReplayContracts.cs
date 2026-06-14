using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Replay;

namespace AIKernel.Dtos.Replay;

/// <summary>
/// Carries a replay timeline create request.
/// JA: ReplayTimelineCreateRequest の公開契約を定義します。
/// </summary>
public sealed record ReplayTimelineCreateRequest
{
    /// <summary>Gets the requested timeline identifier. JA: TimelineId を取得します。</summary>
    public string? TimelineId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay timeline create result.
/// JA: ReplayTimelineCreateResult の公開契約を定義します。
/// </summary>
public sealed record ReplayTimelineCreateResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether creation succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets creation diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when creation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay frame append request.
/// JA: ReplayFrameAppendRequest の公開契約を定義します。
/// </summary>
public sealed record ReplayFrameAppendRequest
{
    /// <summary>Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>Gets the replay frame. JA: Frame を取得します。</summary>
    public ReplayFrame Frame { get; init; } = new();

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay event append request.
/// JA: ReplayEventAppendRequest の公開契約を定義します。
/// </summary>
public sealed record ReplayEventAppendRequest
{
    /// <summary>Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>Gets the replay event. JA: Event を取得します。</summary>
    public ReplayEvent Event { get; init; } = new();

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay append result.
/// JA: ReplayAppendResult の公開契約を定義します。
/// </summary>
public sealed record ReplayAppendResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether append succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the appended item identifier. JA: AppendedId を取得します。</summary>
    public string? AppendedId { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets append diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when append was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay timeline query.
/// JA: ReplayTimelineQuery の公開契約を定義します。
/// </summary>
public sealed record ReplayTimelineQuery
{
    /// <summary>Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay timeline.
/// JA: ReplayTimeline の公開契約を定義します。
/// </summary>
public sealed record ReplayTimeline
{
    /// <summary>Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>Gets whether timeline retrieval succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets replay frames. JA: Frames を取得します。</summary>
    public IReadOnlyList<ReplayFrame> Frames { get; init; } = [];

    /// <summary>Gets replay events. JA: Events を取得します。</summary>
    public IReadOnlyList<ReplayEvent> Events { get; init; } = [];

    /// <summary>Gets the seal state. JA: SealState を取得します。</summary>
    public ReplaySealState SealState { get; init; } = ReplaySealState.Unknown;

    /// <summary>Gets timeline diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when the timeline was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets timeline metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay frame.
/// JA: ReplayFrame の公開契約を定義します。
/// </summary>
public sealed record ReplayFrame
{
    /// <summary>Gets the replay frame identifier. JA: FrameId を取得します。</summary>
    public string FrameId { get; init; } = string.Empty;

    /// <summary>Gets the frame kind. JA: Kind を取得します。</summary>
    public ReplayFrameKind Kind { get; init; } = ReplayFrameKind.Unknown;

    /// <summary>Gets the frame index. JA: Index を取得します。</summary>
    public long Index { get; init; }

    /// <summary>Gets when the frame was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets frame metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay event.
/// JA: ReplayEvent の公開契約を定義します。
/// </summary>
public sealed record ReplayEvent
{
    /// <summary>Gets the replay event identifier. JA: EventId を取得します。</summary>
    public string EventId { get; init; } = string.Empty;

    /// <summary>Gets the event kind. JA: Kind を取得します。</summary>
    public ReplayEventKind Kind { get; init; } = ReplayEventKind.Unknown;

    /// <summary>Gets the associated frame identifier. JA: FrameId を取得します。</summary>
    public string? FrameId { get; init; }

    /// <summary>Gets when the event was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets event metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay event query.
/// JA: ReplayEventQuery の公開契約を定義します。
/// </summary>
public sealed record ReplayEventQuery
{
    /// <summary>Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>Gets the event kind filter. JA: Kind を取得します。</summary>
    public ReplayEventKind Kind { get; init; } = ReplayEventKind.Unknown;

    /// <summary>Gets the replay cursor. JA: Cursor を取得します。</summary>
    public ReplayCursor? Cursor { get; init; }

    /// <summary>Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a replay seal request.
/// JA: ReplaySealRequest の公開契約を定義します。
/// </summary>
public sealed record ReplaySealRequest
{
    /// <summary>Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>Gets the requested hash algorithm. JA: HashAlgorithm を取得します。</summary>
    public string? HashAlgorithm { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries replay seal hash and signature references.
/// JA: ReplaySealResult の公開契約を定義します。
/// </summary>
public sealed record ReplaySealResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether seal succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the replay timeline identifier. JA: ReplayTimelineId を取得します。</summary>
    public string ReplayTimelineId { get; init; } = string.Empty;

    /// <summary>Gets the seal state. JA: SealState を取得します。</summary>
    public ReplaySealState SealState { get; init; } = ReplaySealState.Unknown;

    /// <summary>Gets the content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets the hash algorithm. JA: HashAlgorithm を取得します。</summary>
    public string? HashAlgorithm { get; init; }

    /// <summary>Gets the signature reference. JA: SignatureRef を取得します。</summary>
    public string? SignatureRef { get; init; }

    /// <summary>Gets the signer identifier. JA: SignerId を取得します。</summary>
    public string? SignerId { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets seal diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when seal was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries replay cursor state.
/// JA: ReplayCursor の公開契約を定義します。
/// </summary>
public sealed record ReplayCursor
{
    /// <summary>Gets the cursor token. JA: Token を取得します。</summary>
    public string? Token { get; init; }

    /// <summary>Gets the maximum result count. JA: Limit を取得します。</summary>
    public int? Limit { get; init; }

    /// <summary>Gets cursor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
