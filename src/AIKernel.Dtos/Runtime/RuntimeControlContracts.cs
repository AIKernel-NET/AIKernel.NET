using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Runtime;

namespace AIKernel.Dtos.Runtime;

/// <summary>
/// Identifies a runtime boundary.
/// JA: RuntimeHandle の公開契約を定義します。
/// </summary>
public sealed record RuntimeHandle
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;

    /// <summary>Gets the runtime instance identifier. JA: InstanceId を取得します。</summary>
    public string? InstanceId { get; init; }

    /// <summary>Gets handle metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Describes a runtime.
/// JA: RuntimeDescriptor の公開契約を定義します。
/// </summary>
public sealed record RuntimeDescriptor
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;

    /// <summary>Gets the runtime display name. JA: Name を取得します。</summary>
    public string? Name { get; init; }

    /// <summary>Gets the runtime state. JA: State を取得します。</summary>
    public RuntimeState State { get; init; } = RuntimeState.Unknown;

    /// <summary>Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a runtime attach request.
/// JA: RuntimeAttachRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeAttachRequest
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;

    /// <summary>Gets the attachment mode. JA: Mode を取得します。</summary>
    public RuntimeAttachmentMode Mode { get; init; } = RuntimeAttachmentMode.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a runtime attach result.
/// JA: RuntimeAttachResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeAttachResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether attach succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the runtime handle. JA: Handle を取得します。</summary>
    public RuntimeHandle? Handle { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets attach diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when attach was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a runtime detach request.
/// JA: RuntimeDetachRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeDetachRequest
{
    /// <summary>Gets the runtime handle. JA: Handle を取得します。</summary>
    public RuntimeHandle? Handle { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a runtime detach result.
/// JA: RuntimeDetachResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeDetachResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether detach succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resulting runtime state. JA: State を取得します。</summary>
    public RuntimeState State { get; init; } = RuntimeState.Unknown;

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets detach diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when detach was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a runtime control request.
/// JA: RuntimeControlRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeControlRequest
{
    /// <summary>Gets the runtime handle. JA: Handle を取得します。</summary>
    public RuntimeHandle? Handle { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets the requested operation. JA: Operation を取得します。</summary>
    public RuntimeControlOperation Operation { get; init; } = RuntimeControlOperation.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a runtime control result.
/// JA: RuntimeControlResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeControlResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether control succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resulting runtime state. JA: State を取得します。</summary>
    public RuntimeState State { get; init; } = RuntimeState.Unknown;

    /// <summary>Gets the runtime failure kind. JA: FailureKind を取得します。</summary>
    public RuntimeFailureKind FailureKind { get; init; } = RuntimeFailureKind.Unknown;

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets control diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when control was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a runtime snapshot request.
/// JA: RuntimeSnapshotRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeSnapshotRequest
{
    /// <summary>Gets the runtime handle. JA: Handle を取得します。</summary>
    public RuntimeHandle? Handle { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a runtime probe request.
/// JA: RuntimeProbeRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeProbeRequest
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets probe metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a runtime probe result.
/// JA: RuntimeProbeResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeProbeResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether probe succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets whether the runtime is available. JA: IsAvailable を取得します。</summary>
    public bool IsAvailable { get; init; }

    /// <summary>Gets the runtime descriptor. JA: Runtime を取得します。</summary>
    public RuntimeDescriptor? Runtime { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets probe diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when probe was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Identifies a process boundary.
/// JA: ProcessHandle の公開契約を定義します。
/// </summary>
public sealed record ProcessHandle
{
    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string ProcessId { get; init; } = string.Empty;

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets handle metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a process list request.
/// JA: ProcessListRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessListRequest
{
    /// <summary>Gets the runtime handle. JA: Runtime を取得します。</summary>
    public RuntimeHandle? Runtime { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a process list result.
/// JA: ProcessListResult の公開契約を定義します。
/// </summary>
public sealed record ProcessListResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether list succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets process descriptors. JA: Processes を取得します。</summary>
    public IReadOnlyList<ProcessDescriptor> Processes { get; init; } = [];

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when the result was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a process query request.
/// JA: ProcessQueryRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessQueryRequest
{
    /// <summary>Gets the process handle. JA: Process を取得します。</summary>
    public ProcessHandle? Process { get; init; }

    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Describes a runtime process.
/// JA: ProcessDescriptor の公開契約を定義します。
/// </summary>
public sealed record ProcessDescriptor
{
    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string ProcessId { get; init; } = string.Empty;

    /// <summary>Gets whether process description succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets the process display name. JA: Name を取得します。</summary>
    public string? Name { get; init; }

    /// <summary>Gets the process state. JA: State を取得します。</summary>
    public ProcessStateKind State { get; init; } = ProcessStateKind.Unknown;

    /// <summary>Gets when the descriptor was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets process diagnostics. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a process control request.
/// JA: ProcessControlRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessControlRequest
{
    /// <summary>Gets the process handle. JA: Process を取得します。</summary>
    public ProcessHandle? Process { get; init; }

    /// <summary>Gets the requested operation. JA: Operation を取得します。</summary>
    public ProcessControlOperation Operation { get; init; } = ProcessControlOperation.Unknown;

    /// <summary>Gets the process signal. JA: Signal を取得します。</summary>
    public ProcessSignalKind Signal { get; init; } = ProcessSignalKind.Unknown;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a process control result.
/// JA: ProcessControlResult の公開契約を定義します。
/// </summary>
public sealed record ProcessControlResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether process control succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resulting process state. JA: State を取得します。</summary>
    public ProcessStateKind State { get; init; } = ProcessStateKind.Unknown;

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets process diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when control was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a process attach request.
/// JA: ProcessAttachRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessAttachRequest
{
    /// <summary>Gets the runtime handle. JA: Runtime を取得します。</summary>
    public RuntimeHandle? Runtime { get; init; }

    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>Gets attach metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a process attach result.
/// JA: ProcessAttachResult の公開契約を定義します。
/// </summary>
public sealed record ProcessAttachResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether attach succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the process handle. JA: Handle を取得します。</summary>
    public ProcessHandle? Handle { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets attach diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when attach was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a process detach request.
/// JA: ProcessDetachRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessDetachRequest
{
    /// <summary>Gets the process handle. JA: Process を取得します。</summary>
    public ProcessHandle? Process { get; init; }

    /// <summary>Gets detach metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a process detach result.
/// JA: ProcessDetachResult の公開契約を定義します。
/// </summary>
public sealed record ProcessDetachResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether detach succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets detach diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when detach was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
